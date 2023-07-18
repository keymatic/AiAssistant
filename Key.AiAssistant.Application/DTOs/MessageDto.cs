namespace Key.AiAssistant.Application.DTOs
{
    public class MessageDto : DtoBase
    {
        public string Text { get; set; }
        public ConversationDto Conversation { get; set; }
        public int ConversationId { get; set; }
        public bool FromAi { get; set; }
    }
}