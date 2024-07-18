using AIProject.Application.Common.Constants;
using AIProject.Application.Common.Interfaces;
using AIProject.Application.Common.Models.BaseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Application.Features.Chat.Queries.GetChats
{
    public class GetChatsHandler : IRequestHandler<GetChatsCommand, DataResponse<GetChatsResponse>>
    {
        private readonly IChatService<Domain.Entities.Chat> _chatService;

        public GetChatsHandler(IChatService<Domain.Entities.Chat> chatService)
        {
            _chatService = chatService;
        }

        public async Task<DataResponse<GetChatsResponse>> Handle(GetChatsCommand request, CancellationToken cancellationToken)
        {
            var chats = await _chatService.GetChats(cancellationToken);

            if (chats != null)
            {
                return new()
                {
                    Status = HttpStatusCode.OK,
                    Message = ResponseConst.OperationSuccess,
                    Data = new()
                    {
                        Data = chats
                    }
                };
            }
            else
            {
                return new()
                {
                    Status = HttpStatusCode.NoContent,
                    Message = ResponseConst.OperationFailed,
                    Data = null
                };
            }
        }
    }
}
