using AIProject.Application.Common.Models;
using AIProject.Application.Common.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<DataResponse<LoginResponse>> LoginAsync(LoginRequest loginRequest);
    }
}
