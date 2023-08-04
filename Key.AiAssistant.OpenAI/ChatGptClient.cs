using Key.AiAssistant.Application.Contracts.ChatBot;
using Key.AiAssistant.ChatGPT.Configuration;
using Key.AiAssistant.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace Key.AiAssistant.ChatGPT
{
    public class ChatGptClient : IChatBotClient
    {
        private readonly ChatGptSettings _settings;
        private readonly ILogger<ChatGptClient> _logger;

        public ChatGptClient(IOptions<ChatGptSettings> options, ILogger<ChatGptClient> logger)
        {
            _settings = options.Value;
            _logger = logger;
        }

        public async Task<List<Message>> GetResponse(params string[] prompts)
        {
            var result = prompts.Select(s => new Message { Text = s }).ToList();
            
            var api = new OpenAIAPI(new APIAuthentication(_settings.ApiKey));
            api.Completions.DefaultCompletionRequestArgs.MaxTokens = 2000;
            api.Completions.DefaultCompletionRequestArgs.Model = "gpt-3.5-turbo-16k";

            var completionResult = await api.Chat.CreateChatCompletionAsync(prompts);
            _logger.LogDebug($"completionResult: {System.Text.Json.JsonSerializer.Serialize(completionResult)}");

            //result.Add(new Message{Text = System.Text.Json.JsonSerializer.Serialize(completionResult)});
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

            var provideVacancyMessage = string.Format(Resources.OptimizeResume_ProvideVacancy, vacancy);
            conversation.Messages.AddRange(await GetResponse(Resources.OptimizeResume_SetupAssistant,
                provideVacancyMessage));

            var provideResumeMessage = string.Format(Resources.OptimizeResume_ProvideResume, resume);
            conversation.Messages.AddRange(await GetResponse(provideResumeMessage));

            return conversation;
        }

        public async Task<Conversation> SendAsync(string[] promptMessages, CancellationToken cancellationToken = default)
        {
            var response = await GetResponse(promptMessages);
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