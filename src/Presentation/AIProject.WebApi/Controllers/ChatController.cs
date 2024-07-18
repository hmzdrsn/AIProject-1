using AIProject.Application.Common.Interfaces;
using AIProject.Application.Exceptions;
using AIProject.Application.Features.Chat.Commands.CreateChat;
using AIProject.Application.Features.Chat.Queries.GetChats;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AIProject.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatController : ApiBaseController
    {
        private readonly IMediator _mediator;
        private readonly IResponseService _responseService;
        public ChatController(IMediator mediator, IResponseService responseService)
        {
            _mediator = mediator;
            _responseService = responseService;
        }


        [HttpGet]
        public async Task<IActionResult> GetChats()
        {
            GetChatsCommand request = new GetChatsCommand();
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetResponse()//
        {
            var data = await _responseService.GetResponse();
            var result=  JsonConvert.SerializeObject(data);
            return Ok(data);
             
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateChat(CreateChatCommand request)
        {
            if (!ModelState.IsValid)
            {
               var messages = ModelState
              .SelectMany(modelState => modelState.Value.Errors)
              .Select(err => err.ErrorMessage)
              .ToList();

                return BadRequest(messages);
            }
            var Token = AccessToken;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
