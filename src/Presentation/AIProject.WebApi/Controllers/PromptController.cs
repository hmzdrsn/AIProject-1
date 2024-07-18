using AIProject.Application.Features.Chat.Commands.CreateChat;
using AIProject.Application.Features.Prompt.Commands.CreatePrompt;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromptController : ApiBaseController
    {
        private readonly IMediator _mediator;

        public PromptController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrompt(CreatePromptCommand request)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState
               .SelectMany(modelState => modelState.Value.Errors)
               .Select(err => err.ErrorMessage)
               .ToList();

                return BadRequest(messages);
            }
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
