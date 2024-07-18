using AIProject.Application.Common.Interfaces;
using AIProject.Domain.Entities;
using AIProject.Infrastructure.Persistance.Services;
using AIProject.Infrastructure.Persistance.UnitOfWork;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            services.AddTransient<IChatService<Chat>, ChatService>();
            services.AddTransient<IPromptService, PromptService>();
            services.AddTransient<IEnglishDegreeService,EnglishDegreeService>();

            services.AddTransient<IUnitOfWork,UnitOfWork>();

            services.AddTransient<IResponseService, ResponseService>();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ITokenService,TokenService>();
        }
    }
}
