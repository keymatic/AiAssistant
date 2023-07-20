using Key.AiAssistant.Application.DTOs;
using MediatR;

namespace Key.AiAssistant.Application.Features.Prompts.Requests.Queries
{
    public class GetPromptListRequest : IRequest<List<PromptDto>>
    {
    }
}
