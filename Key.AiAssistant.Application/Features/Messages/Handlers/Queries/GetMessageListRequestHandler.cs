using AutoMapper;
using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Application.DTOs.Messages;
using Key.AiAssistant.Application.Features.Messages.Requests.Queries;
using MediatR;

namespace Key.AiAssistant.Application.Features.Messages.Handlers.Queries
{
    public class GetMessageListRequestHandler : IRequestHandler<GetMessageListRequest, List<MessageDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetMessageListRequestHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<List<MessageDto>> Handle(GetMessageListRequest request, CancellationToken cancellationToken)
        {
            var messages = await _messageRepository.GetAll();
            return _mapper.Map<List<MessageDto>>(messages);
        }
    }
}
