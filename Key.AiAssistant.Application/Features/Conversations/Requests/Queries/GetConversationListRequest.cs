using Key.AiAssistant.Application.DTOs.Conversations;
using MediatR;

namespace Key.AiAssistant.Application.Features.Conversations.Requests.Queries
{
    public class GetConversationListRequest : IRequest<List<ConversationListDto>>
    {
    }
}
