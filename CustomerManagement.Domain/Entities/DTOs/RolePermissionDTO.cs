using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Entities.DTOs
{
    public class RolePermissionDTO
    {
        public string RoleName { get; set; }
        public List<int> Permissions { get; set; }
    }
}
