﻿using AutoMapper;
using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Application.DTOs.Conversations;
using Key.AiAssistant.Application.Features.Conversations.Requests.Queries;
using MediatR;

namespace Key.AiAssistant.Application.Features.Conversations.Handlers.Queries
{
    public class GetConversationListRequestHandler : IRequestHandler<GetConversationListRequest, List<ConversationListDto>>
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IMapper _mapper;

        public GetConversationListRequestHandler(IConversationRepository conversationRepository, IMapper mapper)
        {
            _conversationRepository = conversationRepository;
            _mapper = mapper;
        }

        public async Task<List<ConversationListDto>> Handle(GetConversationListRequest request, CancellationToken cancellationToken)
        {
            var conversations = await _conversationRepository.GetAllWithDetail();
            return _mapper.Map<List<ConversationListDto>>(conversations);
        }
    }
}
