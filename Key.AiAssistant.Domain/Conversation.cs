using Key.AiAssistant.Domain.Common;

namespace Key.AiAssistant.Domain
{
    public class Conversation : EntityBase
    {
        public string Title { get; set; }
        public Prompt Prompt { get; set; }
        public int? PromptId { get; set; }
        public List<Message> Messages { get; set; } = new();
    }
}