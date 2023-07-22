using Key.AiAssistant.Application.DTOs;
using Key.AiAssistant.Application.DTOs.Prompts;
using MediatR;

namespace Key.AiAssistant.Application.Features.Prompts.Requests.Queries
{
    public class GetPromptRequest : IRequest<PromptDto>
    {
        public int Id { get; set; }
    }
}
