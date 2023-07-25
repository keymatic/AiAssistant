namespace Key.AiAssistant.Application.DTOs.Conversations
{
    public class UpdateConversationDto : DtoBase, IConversationDto
    {
        public string Title { get; set; }
    }
}