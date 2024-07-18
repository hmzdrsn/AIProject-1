using AIProject.Application.Common.Interfaces;
using AIProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Infrastructure.Persistance.Services
{
    public class PromptService :BaseService<Prompt>, IPromptService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PromptService(ApplicationContext context,IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Prompt> CreatePrompt(Prompt request, CancellationToken cancellationToken)
        {
            await Table.AddAsync(request);
            await _unitOfWork.SaveChangesAsync();
            return request;
        }

        public async Task<Prompt> GetById(string id, CancellationToken cancellationToken)
        {
            var data = await Table.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public bool IsPromptIdValid(string promptId)
        {
            return Table.Any(x => x.Id==promptId);
        }
    }
}
