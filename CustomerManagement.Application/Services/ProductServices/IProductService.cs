using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services.ProductServices
{
    public interface IProductService
    {
        public Task<Product> GetProductById(int id);
        public Task<Product> GetProductByName(string name);
        public Task<IEnumerable<Product>> GetAllProduct();

        public Task<Product> CreateProduct(ProductDTO productDTO);
        public Task<Product> UpdateProductById(int id,ProductDTO productDTO);
        public Task<bool> DeleteProductById(int id);
    }
}
