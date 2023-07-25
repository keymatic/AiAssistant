using AutoMapper;
using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Application.DTOs.Prompts.Validators;
using Key.AiAssistant.Application.Exceptions;
using Key.AiAssistant.Application.Features.Prompts.Requests.Commands;
using MediatR;

namespace Key.AiAssistant.Application.Features.Prompts.Handlers.Commands
{
    public class UpdatePromptCommandHandler : IRequestHandler<UpdatePromptCommand, Unit>
    {
        private readonly IPromptRepository _promptRepository;
        private readonly IMapper _mapper;

        public UpdatePromptCommandHandler(IPromptRepository promptRepository, IMapper mapper)
        {
            _promptRepository = promptRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePromptCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePromptDtoValidator();
            var validationResult = await validator.ValidateAsync(request.PromptDto, cancellationToken);
            if (!validationResult.IsValid)
                throw new ModelValidationException(validationResult);

            var prompt = await _promptRepository.Get(request.PromptDto.Id);

            _mapper.Map(request.PromptDto, prompt);

            await _promptRepository.Update(prompt);
            return Unit.Value;
        }
    }
}
