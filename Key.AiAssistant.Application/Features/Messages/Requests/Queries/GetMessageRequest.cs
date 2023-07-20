using Key.AiAssistant.Application.DTOs.Messages;
using MediatR;

namespace Key.AiAssistant.Application.Features.Messages.Requests.Queries
{
    public class GetMessageRequest : IRequest<MessageDto>
    {
        public int Id { get; set; }
    }
}
