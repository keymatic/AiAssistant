using Key.AiAssistant.Application.DTOs.Messages;
using Key.AiAssistant.Application.Features.Messages.Requests.Commands;
using Key.AiAssistant.Application.Features.Messages.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Key.AiAssistant.API.Controllers
{
    [Route("api/Conversations/{conversationId}/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<MessagesController>
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<ActionResult<List<MessageDto>>> GetAll(int conversationId)
        {
            var messages = await _mediator.Send(new GetMessageListRequest(conversationId));
            return Ok(messages);
        }

        // GET api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDto>> Get(int conversationId, int id)
        {
            var message = await _mediator.Send(new GetMessageRequest(conversationId, id));
            return Ok(message);
        }

        // POST api/Messages
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<MessageDto>> Post([FromBody] CreateMessageDto message, int conversationId)
        {
            var command = new CreateMessageCommand { MessageDto = message };
            command.MessageDto.ConversationId = conversationId;
            var response = await _mediator.Send(command);
            return Ok(new
            {
                Id = response
            });
        }
    }
}