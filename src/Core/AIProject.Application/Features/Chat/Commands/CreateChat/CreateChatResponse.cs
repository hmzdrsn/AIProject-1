using AIProject.Application.Common.Models.BaseModels;
using AIProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AIProject.Application.Features.Chat.Commands.CreateChat
{
    public class CreateChatResponse
    {
        //public object? ErrorList {  get; set; }//bunu düzelticez burası böle olmaz
        public Domain.Entities.Chat? Chat { get; set; }
    }
}
