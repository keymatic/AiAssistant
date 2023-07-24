using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Application.Features.Conversations.Requests.Commands;
using MediatR;

namespace Key.AiAssistant.Application.Features.Conversations.Handlers.Commands
{
    public class DeleteConversationHandler : IRequestHandler<DeleteConversationCommand, Unit>
    {
        private readonly IConversationRepository _conversationRepository;

        public DeleteConversationHandler(IConversationRepository conversationRepository)
        {
            _conversationRepository = conversationRepository;
        }

        public async Task<Unit> Handle(DeleteConversationCommand request, CancellationToken cancellationToken)
        {
            var conversation = await _conversationRepository.Get(request.Id);

            await _conversationRepository.Delete(conversation);
            return Unit.Value;
        }
    }
}
