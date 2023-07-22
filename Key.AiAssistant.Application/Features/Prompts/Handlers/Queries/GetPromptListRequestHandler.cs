using AutoMapper;
using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Application.DTOs;
using Key.AiAssistant.Application.DTOs.Prompts;
using Key.AiAssistant.Application.Features.Prompts.Requests.Queries;
using MediatR;

namespace Key.AiAssistant.Application.Features.Prompts.Handlers.Queries
{
    public class GetPromptListRequestHandler : IRequestHandler<GetPromptListRequest, List<PromptDto>>
    {
        private readonly IPromptRepository _promptRepository;
        private readonly IMapper _mapper;

        public GetPromptListRequestHandler(IPromptRepository promptRepository, IMapper mapper)
        {
            _promptRepository = promptRepository;
            _mapper = mapper;
        }

        public async Task<List<PromptDto>> Handle(GetPromptListRequest request, CancellationToken cancellationToken)
        {
            var prompts = await _promptRepository.GetAll();
            return _mapper.Map<List<PromptDto>>(prompts);
        }
    }
}
