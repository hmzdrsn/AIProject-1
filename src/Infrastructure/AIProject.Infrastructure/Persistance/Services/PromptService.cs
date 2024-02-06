﻿using AIProject.Application.Common.Interfaces;
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
        private readonly ApplicationContext _context;
        public PromptService(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Prompt> GetById(string id, CancellationToken cancellationToken)
        {
            var data = await Table.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }
    }
}
