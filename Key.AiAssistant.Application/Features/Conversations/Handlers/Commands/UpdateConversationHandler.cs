using AutoMapper;
using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Application.DTOs.Conversations.Validators;
using Key.AiAssistant.Application.Exceptions;
using Key.AiAssistant.Application.Features.Conversations.Requests.Commands;
using MediatR;

namespace Key.AiAssistant.Application.Features.Conversations.Handlers.Commands
{
    public class UpdateConversationHandler : IRequestHandler<UpdateConversationCommand, Unit>
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IMapper _mapper;

        public UpdateConversationHandler(IConversationRepository conversationRepository, IMapper mapper)
        {
            _conversationRepository = conversationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateConversationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateConversationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateConversationDto, cancellationToken);
            if (!validationResult.IsValid)
                throw new ModelValidationException(validationResult);

            var conversation = await _conversationRepository.Get(request.UpdateConversationDto.Id);

            _mapper.Map(request.UpdateConversationDto, conversation);

            await _conversationRepository.Update(conversation);
            return Unit.Value;
        }
    }
}
