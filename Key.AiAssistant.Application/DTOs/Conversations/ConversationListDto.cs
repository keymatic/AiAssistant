namespace Key.AiAssistant.Application.DTOs.Conversations
{
    public class ConversationListDto : DtoBase
    {
        public string Title { get; set; }
        public string PromptName { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}