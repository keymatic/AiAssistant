namespace Key.AiAssistant.Application.DTOs.Conversations
{
    public class CreateConversationDto : IConversationDto
    {
        public string Title { get; set; }
        public int PromptId { get; set; }
    }
}