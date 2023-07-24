using Key.AiAssistant.Application.DTOs.Prompts;
using MediatR;

namespace Key.AiAssistant.Application.Features.Prompts.Requests.Commands
{
    public class UpdatePromptCommand : IRequest<Unit>
    {
        public PromptDto PromptDto { get; set; }
    }
}
