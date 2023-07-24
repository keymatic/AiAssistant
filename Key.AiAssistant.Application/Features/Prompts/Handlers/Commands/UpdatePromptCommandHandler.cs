using AutoMapper;
using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Application.Features.Prompts.Requests.Commands;
using Key.AiAssistant.Domain;
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
            var prompt = await _promptRepository.Get(request.PromptDto.Id);

            _mapper.Map(request.PromptDto, prompt);

            await _promptRepository.Update(prompt);
            return Unit.Value;
        }
    }
}
