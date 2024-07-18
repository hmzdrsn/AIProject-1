using AIProject.Application.Common.Models.BaseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Application.Features.Chat.Queries.GetChats
{
    public class GetChatsCommand : IRequest<DataResponse<GetChatsResponse>>
    {
    }
}
