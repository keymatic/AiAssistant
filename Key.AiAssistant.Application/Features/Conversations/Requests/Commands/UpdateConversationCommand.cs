using Key.AiAssistant.Application.DTOs.Conversations;
using MediatR;

namespace Key.AiAssistant.Application.Features.Conversations.Requests.Commands
{
    public class UpdateConversationCommand : IRequest<Unit>
    {
        public UpdateConversationDto UpdateConversationDto{ get; set; }
    }
}
