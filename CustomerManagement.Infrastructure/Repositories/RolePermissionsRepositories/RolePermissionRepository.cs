using CustomerManagement.Domain.Entities.Models;
using CustomerManagement.Infrastructure.Persistance;
using CustomerManagement.Infrastructure.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Infrastructure.Repositories.RolePermissionsRepositories
{
    public class RolePermissionRepository : BaseRepository<RolePermissions>, IRolePermissionRepository
    {
        public RolePermissionRepository(InfrastructureDbContext context) : base(context)
        {
        }
    }
}
