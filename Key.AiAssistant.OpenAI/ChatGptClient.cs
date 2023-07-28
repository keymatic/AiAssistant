using Key.AiAssistant.Application.Contracts.ChatBot;
using Key.AiAssistant.Domain;
using Microsoft.Extensions.Options;
using OpenAI_API;

namespace Key.AiAssistant.ChatGPT
{
    public class ChatGptClient : IChatBotClient
    {
        private readonly ChatGptSettings _settings;

        public ChatGptClient(IOptions<ChatGptSettings> options)
        {
            _settings = options.Value;
        }

        public async Task<List<Message>> GetResponse(params string[] prompts)
        {
            var result = prompts.Select(s => new Message { Text = s }).ToList();
            
            var api = new OpenAIAPI(new APIAuthentication(_settings.ApiKey));
            
            var completionResult = await api.Completions.CreateCompletionAsync(prompts);
            result.Add(new Message{Text = completionResult.Completions[0].Text.Trim(), FromAi = true});
            
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

        private string BuildConversationTitle(string vacancy)
        {
            var title = vacancy.Substring(0, 47);
            return title.Length < 47 ? title : title + "...";
        }
    }
}