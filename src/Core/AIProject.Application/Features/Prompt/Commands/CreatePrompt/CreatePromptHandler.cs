using AIProject.Application.Common.Constants;
using AIProject.Application.Common.Interfaces;
using AIProject.Application.Common.Models.BaseModels;
using FluentValidation;
using MediatR;

namespace AIProject.Application.Features.Prompt.Commands.CreatePrompt
{
    public class CreatePromptHandler : IRequestHandler<CreatePromptCommand, DataResponse<CreatePromptResponse>>
    {
        private readonly IPromptService _promptService;
        private readonly IValidator<CreatePromptCommand> _validator;
        public CreatePromptHandler(IPromptService promptService, IValidator<CreatePromptCommand> validator)
        {
            _promptService = promptService;
            _validator = validator;
        }

        public async Task<DataResponse<CreatePromptResponse>> Handle(CreatePromptCommand request, CancellationToken cancellationToken)
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
            Domain.Entities.Prompt prompt = new();
            prompt.Id = Guid.NewGuid().ToString();
            //parameters
            int sentenceAmount = 5;
            string englishDegree = "A1";
            string responseFormat = "json";
            //
            string promptText = $"Generate {sentenceAmount} sentences in English at {englishDegree} level. " +
                $"The sentences should be formatted in {responseFormat} like below:" +
                "{\"sentence\": \"Sample sentence 1\"},{\"sentence\": \"Sample sentence 2\"}" +
                $"Please provide the response ONLY in the mentioned {responseFormat} format. Do not include any additional text.";
            await Console.Out.WriteLineAsync(promptText);
            prompt.PromptText = promptText; //request.PromptText
            prompt.PromptName = request.PromptName;
            var response = await _promptService.CreatePrompt(prompt, cancellationToken);
            if (response != null)
            {

                return new()
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
