using AIProject.Application.Common.Constants;
using AIProject.Application.Common.Interfaces;
using AIProject.Application.Common.Models.BaseModels;
using FluentValidation;
using MediatR;

namespace AIProject.Application.Features.Chat.Commands.CreateChat
{
    public class CreateChatHandler : IRequestHandler<CreateChatCommand, DataResponse<CreateChatResponse>>
    {
        private readonly IChatService<Domain.Entities.Chat> _chatService;
        private readonly IEnglishDegreeService _EnglishDegreeService;
        private readonly IPromptService _promptService;
        private readonly IValidator<CreateChatCommand> _validator;

        public CreateChatHandler(IChatService<Domain.Entities.Chat> chatService, IEnglishDegreeService englishDegreeService, IPromptService promptService, IValidator<CreateChatCommand> validator)
        {
            _chatService = chatService;
            _EnglishDegreeService = englishDegreeService;
            _promptService = promptService;
            _validator = validator;
        }

        public async Task<DataResponse<CreateChatResponse>> Handle(CreateChatCommand request, CancellationToken cancellationToken)
        {


            var result = _validator.Validate(request);
            if (!result.IsValid)
            {
                return new()
                {
                    Status = HttpStatusCode.BadRequest,
                    Message = ResponseConst.ValidationFailed,
                    ErrorList = result.Errors,
                    Data = null
                };
            }
            //              {
            //                   "subject": "RandomAIOlusturacak",
            //                   "englishDegreeId": "A1",
            //                   "promptId": "1"
            //              }
            var englishDegree = _EnglishDegreeService.GetById(request.EnglishDegreeId, cancellationToken).Result;
            var prompt = _promptService.GetById(request.PromptId, cancellationToken).Result;
            Domain.Entities.Chat chat = new();

            chat.Id = Guid.NewGuid().ToString();//değişicek
            //chat.CreatedAt = DateTime.Now;//değişicek
            chat.Subject = request.Subject;
            chat.EnglishDegree = englishDegree;
            chat.Prompt = prompt;

            chat.CustomPrompt = "sadsadsadas";//prompt ayzısı yazılacak 
            chat.UserId = "6631571A-F92B-4888-A782-02CBA99426A5";

            var response = await _chatService.CreateChat(chat, cancellationToken);

            if (response != null)
            {

                return new()
                {
                    Status = HttpStatusCode.OK,
                    Message = ResponseConst.OperationSuccess,
                    Data = new(),
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
