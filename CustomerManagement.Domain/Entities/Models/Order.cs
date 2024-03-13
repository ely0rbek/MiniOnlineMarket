using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Entities.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductAmount { get; set; }
    }
}
