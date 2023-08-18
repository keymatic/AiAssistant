namespace Key.AiAssistant.Application.DTOs.Messages
{
    public class MessageDto : DtoBase
    {
        public string Text { get; set; }
        public bool FromAi { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}