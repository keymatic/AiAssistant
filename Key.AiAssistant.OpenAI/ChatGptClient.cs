using Key.AiAssistant.Application.Contracts.ChatBot;
using Key.AiAssistant.ChatGPT.Configuration;
using Key.AiAssistant.Domain;
using Microsoft.Extensions.Options;
using OpenAI_API;
using OpenAI_API.Models;

namespace Key.AiAssistant.ChatGPT
{
    public class ChatGptClient : IChatBotClient
    {
        private readonly ChatGptSettings _settings;
        private string _separator = "###";
        
        public ChatGptClient(IOptions<ChatGptSettings> options)
        {
            _settings = options.Value;
        }

        private async Task<List<Message>> GetResponse(string model = "gpt-3.5-turbo", int maxTokens = 2000, params string[] prompts)
        {
            var result = prompts.Select(s => new Message { Text = s }).ToList();
            
            var api = new OpenAIAPI(new APIAuthentication(_settings.ApiKey));
            api.Completions.DefaultCompletionRequestArgs.MaxTokens = maxTokens;
            api.Completions.DefaultCompletionRequestArgs.Model = model;

            var completionResult = await api.Chat.CreateChatCompletionAsync(prompts);

            foreach (var choice in completionResult.Choices)
            {
                result.Add(new Message{Text = choice.Message.Content, FromAi = true});
            }

            return result;
        }

        public async Task<Conversation> OptimizeResumeAsync(string resume, string vacancy)
        {
            var conversation = new Conversation
            {
                Title = BuildConversationTitle(vacancy)
            };

            var provideVacancyMessage = string.Format(Resources.OptimizeResume_ProvideVacancy, vacancy, _separator);
            conversation.Messages.AddRange(await GetResponse(Model.GPT4, 4000, Resources.OptimizeResume_SetupAssistant, provideVacancyMessage));

            var requiredSkills = conversation.Messages.Last().Text.Split(_separator)[1];
            var provideResumeMessage = string.Format(Resources.OptimizeResume_ProvideResume, resume, requiredSkills);
            conversation.Messages.AddRange(await GetResponse(Model.GPT4, 4000, prompts:provideResumeMessage));

            return conversation;
        }

        public async Task<Conversation> SendAsync(string[] promptMessages, CancellationToken cancellationToken = default)
        {
            var response = await GetResponse(prompts:promptMessages);
            return new Conversation
            {
                Messages = response
            };
        }

        private string BuildConversationTitle(string vacancy)
        {
            return vacancy.Length < 50 ? vacancy : vacancy.Substring(0, 47) + "...";
        }
    }
}