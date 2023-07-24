using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Application.Features.Prompts.Requests.Commands;
using MediatR;

namespace Key.AiAssistant.Application.Features.Prompts.Handlers.Commands
{
    public class DeletePromptCommandHandler : IRequestHandler<DeletePromptCommand, Unit>
    {
        private readonly IPromptRepository _promptRepository;

        public DeletePromptCommandHandler(IPromptRepository promptRepository)
        {
            _promptRepository = promptRepository;
        }

        public async Task<Unit> Handle(DeletePromptCommand request, CancellationToken cancellationToken)
        {
            var prompt = await _promptRepository.Get(request.Id);

            await _promptRepository.Delete(prompt);
            return Unit.Value;
        }
    }
}
