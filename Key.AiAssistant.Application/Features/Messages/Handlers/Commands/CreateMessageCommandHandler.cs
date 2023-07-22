using AutoMapper;
using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Application.Features.Messages.Requests.Commands;
using Key.AiAssistant.Domain;
using MediatR;

namespace Key.AiAssistant.Application.Features.Messages.Handlers.Commands
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, int>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public CreateMessageCommandHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = _mapper.Map<Message>(request.MessageDto);
            message = await _messageRepository.Add(message);
            return message.Id;
        }
    }
}
