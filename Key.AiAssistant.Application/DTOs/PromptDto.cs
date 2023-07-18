namespace Key.AiAssistant.Application.DTOs
{
    public class PromptDto : DtoBase
    {
        public string Title { get; set; }
        public string[] Messages { get; set; }
    }
}
