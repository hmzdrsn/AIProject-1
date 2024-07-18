using AIProject.Application.Common.Interfaces;
using AIProject.Application.Validators.Chat;
using AIProject.Application.Validators.Prompt;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Application
{
    public static class DependecyInjections
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssemblyContaining<CreateChatValidator>();
            services.AddValidatorsFromAssemblyContaining<CreatePromptValidator>();
        }
    }
}
