using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services.AdminServices
{
    public interface IAdminService
    {
        public Task<Admin> CreateAdmin(AdminDTO adminDTO);
        public Task<IEnumerable<Admin>> GetAllAdmins();
        public Task<Admin> GetAdminByAdminId(int adminId);
        public Task<Admin> UpdateAdminByAdminId(int adminId,AdminDTO adminDTO);
        public Task<bool> DeleteAdminByAdminId(int adminId);
    }
}
