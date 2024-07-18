using AIProject.Application.Common.Models.BaseModels;
using AIProject.Application.Features.Chat.Commands.CreateChat;
using AIProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Application.Common.Interfaces
{
    public interface IChatService<T>
    {
         Task<Chat> CreateChat(Chat request ,CancellationToken cancellationToken);    
         Task<List<T>>? GetChats(CancellationToken cancellationToken, Expression<Func<T, bool>> filter = null);
    }
}
