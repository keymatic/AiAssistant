using AutoMapper;
using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Application.DTOs.Messages;
using Key.AiAssistant.Application.Features.Messages.Requests.Queries;
using MediatR;

namespace Key.AiAssistant.Application.Features.Messages.Handlers.Queries
{
    public class GetMessageHandler : IRequestHandler<GetMessageRequest, MessageDto>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetMessageHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<MessageDto> Handle(GetMessageRequest request, CancellationToken cancellationToken)
        {
            var message = await _messageRepository.GetWithDetail(request.ConversationId, request.Id);
            return _mapper.Map<MessageDto>(message);
        }
    }
}
