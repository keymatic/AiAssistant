using AutoMapper;
using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Application.DTOs.Prompts;
using Key.AiAssistant.Application.Features.Prompts.Requests.Queries;
using MediatR;

namespace Key.AiAssistant.Application.Features.Prompts.Handlers.Queries
{
    public class GetPromptRequestHandler : IRequestHandler<GetPromptRequest, PromptDto>
    {
        private readonly IPromptRepository _promptRepository;
        private readonly IMapper _mapper;

        public GetPromptRequestHandler(IPromptRepository promptRepository, IMapper mapper)
        {
            _promptRepository = promptRepository;
            _mapper = mapper;
        }

        public async Task<PromptDto> Handle(GetPromptRequest request, CancellationToken cancellationToken)
        {
            var prompt = await _promptRepository.Get(request.Id);
            return _mapper.Map<PromptDto>(prompt);
        }
    }
}
