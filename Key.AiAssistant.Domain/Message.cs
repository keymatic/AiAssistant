using Key.AiAssistant.Domain.Common;

namespace Key.AiAssistant.Domain
{
    public class Message : EntityBase
    {
        public string Text { get; set; }
        public Conversation Conversation { get; set; }
        public int ConversationId { get; set; }
        public bool FromAi { get; set; }
    }
}