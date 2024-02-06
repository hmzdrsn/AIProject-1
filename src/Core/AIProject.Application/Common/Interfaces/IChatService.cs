using AIProject.Application.Common.Models.BaseModels;
using AIProject.Application.Features.Chat.Commands.CreateChat;
using AIProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Application.Common.Interfaces
{
    public interface IChatService
    {
         Task<Chat> CreateChat(Chat request ,CancellationToken cancellationToken);    
    }
}
