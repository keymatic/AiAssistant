using Key.AiAssistant.Application.DTOs.Prompts;
using Key.AiAssistant.Application.Features.Prompts.Requests.Commands;
using Key.AiAssistant.Application.Features.Prompts.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Key.AiAssistant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromptsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PromptsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PromptsController>
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<ActionResult<List<PromptDto>>> Get()
        {
            var prompts = await _mediator.Send(new GetPromptListRequest());
            return Ok(prompts);
        }

        // GET api/Prompts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PromptDto>> Get(int id)
        {
            var prompt = await _mediator.Send(new GetPromptRequest() { Id = id });
            return Ok(prompt);
        }

        // POST api/Prompts
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PromptDto>> Post([FromBody] CreatePromptDto prompt)
        {
            var command = new CreatePromptCommand { PromptDto = prompt };
            var response = await _mediator.Send(command);
            return Ok(new
            {
                Id = response
            });
        }

        // PUT api/Prompts/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put([FromBody] PromptDto prompt)
        {
            var command = new UpdatePromptCommand { PromptDto = prompt };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/Prompts/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeletePromptCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
