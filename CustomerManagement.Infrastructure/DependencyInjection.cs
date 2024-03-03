using CustomerManagement.Infrastructure.Persistance;
using CustomerManagement.Infrastructure.Repositories.AdminRepositories;
using CustomerManagement.Infrastructure.Repositories.BaseRepositories;
using CustomerManagement.Infrastructure.Repositories.PersonRepositories;
using CustomerManagement.Infrastructure.Repositories.ProductRepositories;
using CustomerManagement.Infrastructure.Repositories.RolePermissionsRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<InfrastructureDbContext>(options =>
            {
                options.UseNpgsql(conf.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            return services;
        }
    }
}
