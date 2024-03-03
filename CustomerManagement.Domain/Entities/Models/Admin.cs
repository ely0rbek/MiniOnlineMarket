using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Entities.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public int UserId { get; set;}
        public int LimitAdmin { get; set; }
        public List<int> AdminPermissions { get; set; }

    }
}
