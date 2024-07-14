using GorevYonetimSistemi.Business.Abstracts;
using GorevYonetimSistemi.Business.Concretes;
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

            return services;
        }



    }
}
