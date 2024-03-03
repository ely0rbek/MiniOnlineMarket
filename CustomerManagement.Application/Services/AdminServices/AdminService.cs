using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Models;
using CustomerManagement.Infrastructure.Repositories.AdminRepositories;
using CustomerManagement.Infrastructure.Repositories.PersonRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IPersonRepository _personRepository;

        public AdminService(IAdminRepository adminRepository, IPersonRepository personRepository)
        {
            _adminRepository = adminRepository;
            _personRepository = personRepository;
        }

        public async Task<Admin> CreateAdmin(AdminDTO adminDTO)
        {
            var newAdmin = new Admin()
            {
                UserId = adminDTO.UserId,
                AdminPermissions = adminDTO.AdminPermissions,
                LimitAdmin = adminDTO.LimitAdmin,
            };
            return await _adminRepository.Create(newAdmin);
        }

        public async Task<bool> DeleteAdminByAdminId(int adminId)
        {
            return await _adminRepository.Delete(x=>x.Id == adminId);
        }

        public async Task<Admin> GetAdminByAdminId(int adminId)
        {
            return await _adminRepository.GetByAny(x=>x.Id==adminId);
        }

        public async Task<IEnumerable<Admin>> GetAllAdmins()
        {
            return await _adminRepository.GetAll();
        }

        public async Task<Admin> UpdateAdminByAdminId(int adminId, AdminDTO adminDTO)
        {
            var admin = await _adminRepository.GetByAny(x => x.Id == adminId);
            if(admin == null) { return null; }
            else
            {
                admin.UserId = adminDTO.UserId;
                admin.AdminPermissions = adminDTO.AdminPermissions;
                admin.LimitAdmin = adminDTO.LimitAdmin;

                return await _adminRepository.Update(admin);
            }
        }
    }
}
