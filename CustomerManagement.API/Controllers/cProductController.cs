using CustomerManagement.API.Attributes;
using CustomerManagement.API.ExternalServices;
using CustomerManagement.Application.Services.ProductServices;
using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Enums;
using CustomerManagement.Domain.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class cProductController : Controller
    {
        private readonly IProductService _productService;

        public cProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [IdentityFilter(Permissions.CreateProduct)]
        public async Task<Product> CreateProduct(ProductDTO productDTO)
        {
            return await _productService.CreateProduct(productDTO);
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetAllProduct)]
        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _productService.GetAllProduct();
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetProductById)]
        public async Task<Product> GetProductById(int id)
        {
            return await _productService.GetProductById(id);
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetProductByName)]
        public async Task<Product> GetProductByName(string ProductName)
        {
            return await _productService.GetProductByName(ProductName);
        }

        [HttpPut]
        [IdentityFilter(Permissions.UpdateProductById)]
        public async Task<Product> UpdateProductById(int productId,ProductDTO productDTO)
        {
            return await _productService.UpdateProductById(productId, productDTO);
        }
        [HttpDelete]
        [IdentityFilter(Permissions.DeleteProductById)]
        public async Task<bool> DeleteProductById(int id)
        {
            return await _productService.DeleteProductById(id);
        }
    }
}
