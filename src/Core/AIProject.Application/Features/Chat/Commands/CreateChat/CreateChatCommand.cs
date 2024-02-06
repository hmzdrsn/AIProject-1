using AIProject.Application.Common.Models.BaseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Application.Features.Chat.Commands.CreateChat
{
    public class CreateChatCommand : IRequest<DataResponse<CreateChatResponse>>
    {
        public string? Subject { get; set; }
        public string EnglishDegreeId { get; set; }
        public string PromptId { get; set; }

    }
}
