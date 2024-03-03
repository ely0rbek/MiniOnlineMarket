using System.Text.Json.Serialization;

namespace CustomerManagement.Domain.Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductTitle { get; set; }
        public string ProductManufacturerName { get; set; }
        public int ProductUnitPrice { get; set; }
        public string ProductComment { get; set; }
    }
}
