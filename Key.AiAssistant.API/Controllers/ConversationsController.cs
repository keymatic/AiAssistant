using Key.AiAssistant.Application.DTOs.Conversations;
using Key.AiAssistant.Application.Features.Conversations.Requests.Commands;
using Key.AiAssistant.Application.Features.Conversations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Key.AiAssistant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConversationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ConversationsController>
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<ActionResult<List<ConversationDto>>> Get()
        {
            var conversations = await _mediator.Send(new GetConversationListRequest());
            return Ok(conversations);
        }

        // GET api/Conversations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConversationDto>> Get(int id)
        {
            var conversation = await _mediator.Send(new GetConversationDetailRequest { Id = id });
            return Ok(conversation);
        }

        // POST api/Conversations
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ConversationDto>> Post([FromBody] CreateConversationDto conversation)
        {
            var command = new CreateConversationCommand { ConversationDto = conversation };
            var response = await _mediator.Send(command);
            return Ok(new
            {
                Id = response
            });
        }

        // POST api/Conversations/optimize-resume
        [HttpPost("optimize-resume")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ConversationDto>> Post([FromBody] OptimizeResumeChatDto dto)
        {
            var command = new OptimizeResumeCommand { OptimizeResumeChatDto = dto };
            var response = await _mediator.Send(command);
            return Ok(new
            {
                Id = response
            });
        }

        // PUT api/Conversations/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put([FromBody] UpdateConversationDto conversation)
        {
            var command = new UpdateConversationCommand { UpdateConversationDto = conversation };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/Conversations/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteConversationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
