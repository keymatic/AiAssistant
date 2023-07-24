using MediatR;

namespace Key.AiAssistant.Application.Features.Prompts.Requests.Commands
{
    public class DeletePromptCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
