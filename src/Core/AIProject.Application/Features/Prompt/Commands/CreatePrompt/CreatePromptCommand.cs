using AIProject.Application.Common.Models.BaseModels;
using AIProject.Application.Features.Chat.Commands.CreateChat;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Application.Features.Prompt.Commands.CreatePrompt
{
    public class CreatePromptCommand : IRequest<DataResponse<CreatePromptResponse>>
    {
        public string PromptText { get; set; }
        public string PromptName { get; set; }
    }
}
