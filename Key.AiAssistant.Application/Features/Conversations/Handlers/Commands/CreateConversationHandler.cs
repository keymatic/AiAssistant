using AutoMapper;
using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Application.DTOs.Conversations.Validators;
using Key.AiAssistant.Application.Exceptions;
using Key.AiAssistant.Application.Features.Conversations.Requests.Commands;
using Key.AiAssistant.Domain;
using MediatR;

namespace Key.AiAssistant.Application.Features.Conversations.Handlers.Commands
{
    public class CreateConversationHandler : IRequestHandler<CreateConversationCommand, int>
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IMapper _mapper;
        private readonly IPromptRepository _promptRepository;

        public CreateConversationHandler(IConversationRepository conversationRepository, IMapper mapper, IPromptRepository promptRepository)
        {
            _conversationRepository = conversationRepository;
            _promptRepository = promptRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateConversationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateConversationDtoValidator(_promptRepository);
            var validationResult = await validator.ValidateAsync(request.ConversationDto, cancellationToken);
            if (!validationResult.IsValid)
                throw new ModelValidationException(validationResult);

            var conversation = _mapper.Map<Conversation>(request.ConversationDto);
            conversation = await _conversationRepository.Add(conversation);
            return conversation.Id;
        }
    }
}
