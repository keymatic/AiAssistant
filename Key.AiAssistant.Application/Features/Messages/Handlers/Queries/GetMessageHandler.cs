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

        public GetMessageHandler(IMessageRepository conversationRepository, IMapper mapper)
        {
            _messageRepository = conversationRepository;
            _mapper = mapper;
        }

        public async Task<MessageDto> Handle(GetMessageRequest request, CancellationToken cancellationToken)
        {
            var prompt = await _messageRepository.GetWithDetail(request.Id);
            return _mapper.Map<MessageDto>(prompt);
        }
    }
}
