namespace Key.AiAssistant.Application.DTOs.Prompts
{
    public class CreatePromptDto : IPromptDto
    {
        public string Title { get; set; }
        public string[] Messages { get; set; }
    }
}
