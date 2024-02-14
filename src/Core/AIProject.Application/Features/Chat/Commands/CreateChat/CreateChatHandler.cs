using AIProject.Application.Common.Constants;
using AIProject.Application.Common.Interfaces;
using AIProject.Application.Common.Models.BaseModels;
using AIProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace AIProject.Application.Features.Chat.Commands.CreateChat
{
    public class CreateChatHandler : IRequestHandler<CreateChatCommand, DataResponse<CreateChatResponse>>
    {
        private readonly IChatService _chatService;
        private readonly IEnglishDegreeService _EnglishDegreeService;
        private readonly IPromptService _promptService;

        public CreateChatHandler(IChatService chatService, IEnglishDegreeService englishDegreeService, IPromptService promptService)
        {
            _chatService = chatService;
            _EnglishDegreeService = englishDegreeService;
            _promptService = promptService;
        }

        public async Task<DataResponse<CreateChatResponse>> Handle(CreateChatCommand request, CancellationToken cancellationToken)
        {           
            var englishDegree = _EnglishDegreeService.GetById(request.EnglishDegreeId ,cancellationToken ).Result;
            var prompt = _promptService.GetById(request.PromptId, cancellationToken).Result;
            Domain.Entities.Chat chat = new();

            chat.Id = Guid.NewGuid().ToString();//değişicek
            //chat.CreatedAt = DateTime.Now;//değişicek
            chat.Subject = request.Subject;
            chat.EnglishDegree = englishDegree;
            chat.Prompt = prompt;
            
            chat.CustomPrompt = "sadsadsadas";//promt ayzısı yazılacak 
            chat.UserId = "6631571A-F92B-4888-A782-02CBA99426A5";

            var response = await _chatService.CreateChat(chat, cancellationToken);

            if(response != null) {
            
            return new ()
            {
                Status = HttpStatusCode.OK,
                Message = ResponseConst.OperationSuccess,
                Data = null
            };
            }
            else
            {
                return new()
                {
                    Status = HttpStatusCode.NotFound,
                    Message = ResponseConst.OperationFailed,
                    Data = null
                };
            }

        }
    }
}
