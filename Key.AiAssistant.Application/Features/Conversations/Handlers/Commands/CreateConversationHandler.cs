using AutoMapper;
using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Application.Features.Conversations.Requests.Commands;
using Key.AiAssistant.Domain;
using MediatR;

namespace Key.AiAssistant.Application.Features.Conversations.Handlers.Commands
{
    public class CreateConversationHandler : IRequestHandler<CreateConversationCommand, int>
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IMapper _mapper;

        public CreateConversationHandler(IConversationRepository conversationRepository, IMapper mapper)
        {
            _conversationRepository = conversationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateConversationCommand request, CancellationToken cancellationToken)
        {
            var conversation = _mapper.Map<Conversation>(request.ConversationDto);
            conversation = await _conversationRepository.Add(conversation);
            return conversation.Id;
        }
    }
}
