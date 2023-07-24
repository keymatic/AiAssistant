using MediatR;

namespace Key.AiAssistant.Application.Features.Conversations.Requests.Commands
{
    public class DeleteConversationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
