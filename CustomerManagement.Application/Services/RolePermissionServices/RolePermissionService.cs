using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Models;
using CustomerManagement.Infrastructure.Repositories.RolePermissionsRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services.RolePermissionServices
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IRolePermissionRepository _rolePermissionRepository;

        public RolePermissionService(IRolePermissionRepository rolePermissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
        }

        public async Task<RolePermissions> CreateRolePermission(RolePermissionDTO rolePermissionDTO)
        {
            var newRole = new RolePermissions() 
            { 
                RoleName = rolePermissionDTO.RoleName,
                Permissions = rolePermissionDTO.Permissions,
            };
            return await _rolePermissionRepository.Create(newRole);
        }

        public async Task<bool> DeleteRolePermissionById(int Id)
        {
            return await _rolePermissionRepository.Delete(x=>x.Id == Id);
        }

        public async Task<IEnumerable<RolePermissions>> GetAllRolePermissions()
        {
            return await _rolePermissionRepository.GetAll();
        }

        public async Task<RolePermissions> GetRolePermissionById(int id)
        {
            return await _rolePermissionRepository.GetByAny(x=>x.Id==id);
        }

        public async  Task<RolePermissions> UpdateRolePermissionById(int id, RolePermissionDTO rolePermissionDTO)
        {
            var oldRole= await _rolePermissionRepository.GetByAny(x => x.Id == id);
            if(oldRole==null) { return null; }
            else
            {
                oldRole.RoleName= rolePermissionDTO.RoleName;
                oldRole.Permissions= rolePermissionDTO.Permissions;

                return await _rolePermissionRepository.Update(oldRole);
            }
        }
    }
}
