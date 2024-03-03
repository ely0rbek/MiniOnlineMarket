using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services.RolePermissionServices
{
    public interface IRolePermissionService
    {
        public Task<RolePermissions> CreateRolePermission(RolePermissionDTO rolePermissionDTO);
        public Task<IEnumerable<RolePermissions>> GetAllRolePermissions();
        public Task<RolePermissions> GetRolePermissionById(int id);
        public Task<RolePermissions> UpdateRolePermissionById(int id, RolePermissionDTO rolePermissionDTO);
        public Task<bool> DeleteRolePermissionById(int Id);
    }
}
