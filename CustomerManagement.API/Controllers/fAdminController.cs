using CustomerManagement.API.Attributes;
using CustomerManagement.API.ExternalServices;
using CustomerManagement.Application.Services.AdminServices;
using CustomerManagement.Application.Services.PersonServices;
using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class fAdminController : Controller
    {
        private readonly IAdminService _adminService;

        public fAdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        [IdentityFilter(Permissions.CreateAdmin)]
        public async Task<IActionResult> CreateAdmin(AdminDTO adminDTO)
        {
            return Ok(await _adminService.CreateAdmin(adminDTO));
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetAllAdmins)]
        public async Task<IActionResult> GetAllAdmins()
        {
            return Ok(await _adminService.GetAllAdmins());
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetAdminByAdminId)]
        public async Task<IActionResult> GetAdminByAdminId(int id)
        {
            return Ok(await _adminService.GetAdminByAdminId(id));
        }

        [HttpPut]
        [IdentityFilter(Permissions.UpdateAdminByAdminId)]
        public async Task<IActionResult> UpdateAdminByAdminId(int adminId, AdminDTO adminDTO)
        {
            return Ok(await _adminService.UpdateAdminByAdminId(adminId, adminDTO));
        }
        [HttpDelete]
        [IdentityFilter(Permissions.DeleteAdminByAdminId)]
        public async Task<bool> DeleteAdminByAdminId(int id)
        {
            return await _adminService.DeleteAdminByAdminId(id);
        }
    }
}
