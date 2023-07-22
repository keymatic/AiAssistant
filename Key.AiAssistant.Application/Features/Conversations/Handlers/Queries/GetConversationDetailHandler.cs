using AutoMapper;
using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Application.DTOs.Conversations;
using Key.AiAssistant.Application.Features.Conversations.Requests.Queries;
using MediatR;

namespace Key.AiAssistant.Application.Features.Conversations.Handlers.Queries
{
    public class GetConversationDetailHandler : IRequestHandler<GetConversationDetailRequest, ConversationDto>
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IMapper _mapper;

        public GetConversationDetailHandler(IConversationRepository conversationRepository, IMapper mapper)
        {
            _conversationRepository = conversationRepository;
            _mapper = mapper;
        }

        public async Task<ConversationDto> Handle(GetConversationDetailRequest request, CancellationToken cancellationToken)
        {
            var conversation = await _conversationRepository.GetWithDetail(request.Id);
            return _mapper.Map<ConversationDto>(conversation);
        }
    }
}
