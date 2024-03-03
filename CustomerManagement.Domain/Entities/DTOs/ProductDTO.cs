using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Entities.DTOs
{
    public class ProductDTO
    {
        public string ProductTitle { get; set; }
        public string ProductManufacturerName { get; set; }
        public int ProductUnitPrice { get; set; }
        public string ProductComment { get; set; }
    }
}
