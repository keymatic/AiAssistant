using Key.AiAssistant.Application.DTOs.Conversations;
using MediatR;

namespace Key.AiAssistant.Application.Features.Conversations.Requests.Commands
{
    public class CreateConversationCommand : IRequest<int>
    {
        public CreateConversationDto ConversationDto { get; set; }
    }
}
