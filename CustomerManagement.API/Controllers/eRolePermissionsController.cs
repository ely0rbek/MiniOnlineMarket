using CustomerManagement.API.Attributes;
using CustomerManagement.Application.Services.AdminServices;
using CustomerManagement.Application.Services.RolePermissionServices;
using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class eRolePermissionsController : Controller
    {
        private readonly IRolePermissionService _rolePermissionService;

        public eRolePermissionsController(IRolePermissionService rolePermissionService)
        {
            _rolePermissionService = rolePermissionService;
        }

        [HttpPost]
        [IdentityFilter(Permissions.CreateRolePermission)]
        public async Task<IActionResult> CreateRolePermission(RolePermissionDTO rolePermissionDTO)
        {
            return Ok(await _rolePermissionService.CreateRolePermission(rolePermissionDTO));
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetAllRolePermissions)]
        public async Task<IActionResult> GetAllRolePermissions()
        {
            return Ok(await _rolePermissionService.GetAllRolePermissions());
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetRolePermissionById)]
        public async Task<IActionResult> GetRolePermissionById(int id)
        {
            return Ok(await _rolePermissionService.GetRolePermissionById(id));
        }

        [HttpPut]
        [IdentityFilter(Permissions.UpdateRolePermissionById)]
        public async Task<IActionResult> UpdateRolePermissionById(int id, RolePermissionDTO rolePermissionDTO)
        {
            return Ok(await _rolePermissionService.UpdateRolePermissionById(id, rolePermissionDTO));
        }
        [HttpDelete]
        [IdentityFilter(Permissions.DeleteRolePermissionById)]
        public async Task<bool> DeleteRolePermissionById(int id)
        {
            return await _rolePermissionService.DeleteRolePermissionById(id);
        }
    }
}
