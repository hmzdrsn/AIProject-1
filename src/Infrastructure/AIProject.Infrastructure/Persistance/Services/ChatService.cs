using AIProject.Application.Common.Interfaces;
using AIProject.Application.Common.Models.BaseModels;
using AIProject.Domain.Abstraction;
using AIProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Infrastructure.Persistance.Services
{

    public class ChatService  : BaseService<Chat> , IChatService 
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChatService(ApplicationContext applicationContext, IUnitOfWork unitOfWork) : base(applicationContext)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Chat> CreateChat(Chat request, CancellationToken cancellationToken)
        {
            await Table.AddAsync(request);
            //Gelince ararsın 
            await _unitOfWork.SaveChangesAsync();
            return request;
        }

    }
}
