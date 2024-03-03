using CustomerManagement.Application.Services.AdminServices;
using CustomerManagement.Application.Services.AuthServices;
using CustomerManagement.Application.Services.PersonServices;
using CustomerManagement.Application.Services.ProductServices;
using CustomerManagement.Application.Services.RolePermissionServices;
using CustomerManagement.Infrastructure.Repositories.AdminRepositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IRolePermissionService, RolePermissionService>();
            return services;
        }
    }
}
