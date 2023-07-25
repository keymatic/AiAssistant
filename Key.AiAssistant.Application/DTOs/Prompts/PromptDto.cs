namespace Key.AiAssistant.Application.DTOs.Prompts
{
    public class PromptDto : DtoBase, IPromptDto
    {
        public string Title { get; set; }
        public string[] Messages { get; set; }
    }
}
