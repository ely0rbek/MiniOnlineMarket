using CustomerManagement.Domain.Entities.Models;
using CustomerManagement.Infrastructure.Persistance;
using CustomerManagement.Infrastructure.Repositories.BaseRepositories;

namespace CustomerManagement.Infrastructure.Repositories.AdminRepositories
{
    public class AdminRepository : BaseRepository<Admin>,IAdminRepository
    {
        public AdminRepository(InfrastructureDbContext context) : base(context)
        {
        }
    }
}
