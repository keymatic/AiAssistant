namespace Key.AiAssistant.Application.DTOs.Prompts;

public interface IPromptDto
{
    string Title { get; set; }
    string[] Messages { get; set; }
}