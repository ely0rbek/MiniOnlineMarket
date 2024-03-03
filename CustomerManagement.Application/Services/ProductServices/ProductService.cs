using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Models;
using CustomerManagement.Infrastructure.Repositories.PersonRepositories;
using CustomerManagement.Infrastructure.Repositories.ProductRepositories;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services.ProductServices
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateProduct(ProductDTO productDTO)
        {
            var product = new Product()
            {
                ProductTitle = productDTO.ProductTitle,
                ProductManufacturerName = productDTO.ProductManufacturerName,
                ProductUnitPrice = productDTO.ProductUnitPrice,
                ProductComment = productDTO.ProductComment,
            };

            return await _productRepository.Create(product);
        }

        public async Task<bool> DeleteProductById(int id)
        {
            return await _productRepository.Delete(x=>x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _productRepository.GetAll();
        }
        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetByAny(x => x.Id == id);
        }
        public async Task<Product> GetProductByName(string name)
        {
            return await _productRepository.GetByAny(x => x.ProductTitle.ToLower() == name.ToLower());
        }

        public async Task<Product> UpdateProductById(int id,ProductDTO productDTO)
        {
            var searchedProduct=await _productRepository.GetByAny(x=>x.Id==id);
            if (searchedProduct != null)
            {
                searchedProduct.ProductTitle = productDTO.ProductTitle;
                searchedProduct.ProductManufacturerName = productDTO.ProductManufacturerName;
                searchedProduct.ProductUnitPrice = productDTO.ProductUnitPrice;
                searchedProduct.ProductComment = productDTO.ProductComment;

                return await _productRepository.Update(searchedProduct);
            }
            else return null;
        }
    }
}
