using CustomerManagement.API.Attributes;
using CustomerManagement.API.ExternalServices;
using CustomerManagement.Application.Services.ProductServices;
using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [IdentityFilter(Permissions.CreateProduct)]
        public async Task<IActionResult> CreateProduct(ProductDTO productDTO)
        {
            return Ok(await _productService.CreateProduct(productDTO));
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetAllProduct)]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await _productService.GetAllProduct());
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetProductById)]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetProductByName)]
        public async Task<IActionResult> GetProductByName(string ProductName)
        {
            return Ok(await _productService.GetProductByName(ProductName));
        }

        [HttpPut]
        [IdentityFilter(Permissions.UpdateProductById)]
        public async Task<IActionResult> UpdateProductById(int productId,ProductDTO productDTO)
        {
            return Ok(await _productService.UpdateProductById(productId, productDTO));
        }
        [HttpDelete]
        [IdentityFilter(Permissions.DeleteProductById)]
        public async Task<bool> DeleteProductById(int id)
        {
            return await _productService.DeleteProductById(id);
        }
    }
}
