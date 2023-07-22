using Key.AiAssistant.Application.DTOs.Prompts;
using MediatR;

namespace Key.AiAssistant.Application.Features.Prompts.Requests.Commands
{
    public class CreatePromptCommand : IRequest<int>
    {
        public CreatePromptDto PromptDto { get; set; }
    }
}
