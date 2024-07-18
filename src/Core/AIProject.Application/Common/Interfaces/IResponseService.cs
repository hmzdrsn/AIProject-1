using AIProject.Application.Common.Models;
using AIProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Application.Common.Interfaces
{
    public interface IResponseService
    {
        Task<AIResponse> GetResponse();
    }
}
