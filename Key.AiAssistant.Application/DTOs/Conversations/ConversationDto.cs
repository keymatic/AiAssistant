namespace Key.AiAssistant.Application.DTOs.Conversations
{
    public class ConversationDto : DtoBase
    {
        public string Title { get; set; }
        public PromptDto Prompt { get; set; }
        public int PromptId { get; set; }
    }
}