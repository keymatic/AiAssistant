using Key.AiAssistant.Application.DTOs.Prompts;
using MediatR;

namespace Key.AiAssistant.Application.Features.Prompts.Requests.Queries
{
    public class GetPromptListRequest : IRequest<List<PromptDto>>
    {
    }
}
