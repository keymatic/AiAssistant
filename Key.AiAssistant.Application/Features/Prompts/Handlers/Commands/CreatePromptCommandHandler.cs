﻿using AutoMapper;
using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Application.DTOs.Prompts.Validators;
using Key.AiAssistant.Application.Exceptions;
using Key.AiAssistant.Application.Features.Prompts.Requests.Commands;
using Key.AiAssistant.Domain;
using MediatR;

namespace Key.AiAssistant.Application.Features.Prompts.Handlers.Commands
{
    public class CreatePromptCommandHandler : IRequestHandler<CreatePromptCommand, int>
    {
        private readonly IPromptRepository _promptRepository;
        private readonly IMapper _mapper;

        public CreatePromptCommandHandler(IPromptRepository promptRepository, IMapper mapper)
        {
            _promptRepository = promptRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePromptCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePromptDtoValidator();
            var validationResult = await validator.ValidateAsync(request.PromptDto, cancellationToken);
            if (!validationResult.IsValid)
                throw new ModelValidationException(validationResult);

            var prompt = _mapper.Map<Prompt>(request.PromptDto);
            prompt = await _promptRepository.Add(prompt);
            return prompt.Id;
        }
    }
}
