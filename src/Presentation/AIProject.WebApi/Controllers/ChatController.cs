using AIProject.Application.Common.Models.BaseModels;
using AIProject.Application.Features.Chat.Commands.CreateChat;
using AIProject.Domain.Abstraction;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace AIProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ApiBaseController
    {
      private readonly IMediator _mediator;

        public ChatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateChat(CreateChatCommand request)
        {
            var Token = AccessToken;
            var response =  await _mediator.Send(request);
            return Ok(response);
        }


    }
}
