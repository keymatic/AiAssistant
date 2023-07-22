using Key.AiAssistant.Application.DTOs.Messages;
using MediatR;

namespace Key.AiAssistant.Application.Features.Messages.Requests.Commands
{
    public class CreateMessageCommand : IRequest<int>
    {
        public CreateMessageDto MessageDto { get; set; }
    }
}
