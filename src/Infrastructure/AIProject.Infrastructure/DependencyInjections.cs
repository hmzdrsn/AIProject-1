using AIProject.Application.Common.Interfaces;
using AIProject.Infrastructure.Persistance.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Infrastructure
{
    public static class DependencyInjections
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ITokenService,TokenService>();
        }
    }
}
