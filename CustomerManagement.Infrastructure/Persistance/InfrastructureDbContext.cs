using CustomerManagement.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infrastructure.Persistance
{
    public class InfrastructureDbContext : DbContext
    {
        public InfrastructureDbContext(DbContextOptions<InfrastructureDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }
        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<RolePermissions> RolePermissions { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Admin> Admins { get; set; }
    }
}
