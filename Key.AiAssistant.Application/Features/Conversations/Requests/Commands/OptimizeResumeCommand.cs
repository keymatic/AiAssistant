using Key.AiAssistant.Application.DTOs.Conversations;
using MediatR;

namespace Key.AiAssistant.Application.Features.Conversations.Requests.Commands
{
    public class OptimizeResumeCommand : IRequest<int>
    {
        public OptimizeResumeChatDto OptimizeResumeChatDto { get; set; }
    }
}
