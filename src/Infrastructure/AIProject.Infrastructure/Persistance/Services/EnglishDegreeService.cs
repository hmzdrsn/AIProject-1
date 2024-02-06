using AIProject.Application.Common.Interfaces;
using AIProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Infrastructure.Persistance.Services
{
    public class EnglishDegreeService : BaseService<EnglishDegree>, IEnglishDegreeService
    {
        private readonly ApplicationContext _context;
        public EnglishDegreeService(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<EnglishDegree> GetById(string id, CancellationToken cancellationToken)
        {
            var data =  await Table.Where(x=>x.Id==id).FirstOrDefaultAsync();
            return data;
        }
    }
}
