using GorevYonetimSistemi.Business.Abstracts;
using GorevYonetimSistemi.Business.Concretes;
using GorevYonetimSistemi.Business.Rules;
using GorevYonetimSistemi.Core.CrossCuttingConcerns;
using GorevYonetimSistemi.Core.Utilities.Security.JWT;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IToDoTaskService, ToDoTaskManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<ITokenHelper, TokenHelper>();
            services.AddScoped<ToDoTaskBusinessRules>();
            services.AddScoped<UserBusinessRules>();


            return services;
        }
    }
}
