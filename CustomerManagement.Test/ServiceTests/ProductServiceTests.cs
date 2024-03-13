using CustomerManagement.API.Controllers;
using CustomerManagement.Application.Services.PersonServices;
using CustomerManagement.Application.Services.ProductServices;
using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Models;
using CustomerManagement.Test.Mapping;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Test.ServiceTests
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductService> _productService = new Mock<IProductService>();

        public static bool CompareModels(Product returnProduct, Product exceptedProduct)
        {
            if (returnProduct.ProductManufacturerName == exceptedProduct.ProductManufacturerName && returnProduct.ProductTitle == exceptedProduct.ProductTitle && returnProduct.ProductUnitPrice == exceptedProduct.ProductUnitPrice)
                return true;
            return false;
        }

        //  CreateProductTest
        #region CreateProductTest
        public static IEnumerable<object[]> CreateProductDataGenerator()
        {
            yield return new object[]
            {
                new ProductDTO()
                {
                    ProductTitle = "Test Product 3",
                    ProductManufacturerName = "Greanleaf",
                    ProductComment = "vabshi qichu",
                    ProductUnitPrice = 123456
                },
                new Product()
                {
                    ProductTitle = "Test Product 1",
                    ProductManufacturerName = "Greanleaf",
                    ProductComment = "vabshi qichu",
                    ProductUnitPrice = 123456
                }
            };
            yield return new object[]
            {
                new ProductDTO()
                {
                    ProductTitle = "Oxshidi aniq",
                    ProductManufacturerName = "Greanleaf",
                    ProductComment = "vabshi qichu",
                    ProductUnitPrice = 123456
                },
                new Product()
                {
                    ProductTitle = "Oxshidi aniq",
                    ProductManufacturerName = "Greanleaf",
                    ProductComment = "vabshi qichu",
                    ProductUnitPrice = 123456
                }
            };
        }
        [Theory]
        [MemberData(nameof(CreateProductDataGenerator), MemberType = typeof(ProductServiceTests))]
        public async Task CreateProductTest(ProductDTO inputProduct, Product exceptedProduct)
        {
            var inputProductModel = inputProduct.Map<Product>();

            _productService.Setup(x => x.CreateProduct(It.IsAny<ProductDTO>())).ReturnsAsync(inputProductModel);

            var controller = new cProductController(_productService.Object);

            var returnProduct = await controller.CreateProduct(inputProduct);
            Assert.NotNull(returnProduct);
            Assert.True(CompareModels(returnProduct, exceptedProduct));
        }

        #endregion

        //GetAllProductTest
        #region GetAllProductTest
        [Fact]
        public async Task GetAllProductsTest()
        {
            var exceptedProduct = new List<Product>
            {
                new Product
                {
                    ProductTitle = "nimadir",
                    ProductManufacturerName = "Greanleaf",
                    ProductComment = "vabshi qichu",
                    ProductUnitPrice = 123456
                },
                new Product
                {
                    ProductTitle = "kimdir",
                    ProductManufacturerName = "Greanleaf",
                    ProductComment = "vabshi qichu",
                    ProductUnitPrice = 123456
                },
            };
            
            _productService.Setup(x => x.GetAllProduct()).ReturnsAsync(exceptedProduct);

            var controller = new cProductController(_productService.Object);
            var returnData = await controller.GetAllProduct();
            Assert.NotNull(returnData);
            Assert.Equal(returnData.ToList().Count,exceptedProduct.Count);
        }

        #endregion

        // GetProductById
        #region GetProductById
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetProductByIdTest(int id)
        {
            var exceptedProduct = new Product()
            {
                ProductTitle = "Oxshidi aniq",
                ProductManufacturerName = "Greanleaf",
                ProductComment = "vabshi qichu",
                ProductUnitPrice = 123456
            };
            _productService.Setup(x => x.GetProductById(It.IsAny<int>())).ReturnsAsync(exceptedProduct);

            var controller= new cProductController(_productService.Object);
            var returnData=await controller.GetProductById(id);
            Assert.NotNull(returnData);
            Assert.True(CompareModels(returnData, exceptedProduct));
        }

        #endregion

        // UpdateProductTest
        #region UpdateProductTest
        public static IEnumerable<object[]> UpdateProductDataGenerator()
        {
            yield return new object[]
            {
                new int[]{1},
                new ProductDTO()
                {
                    ProductTitle = "nok",
                ProductManufacturerName = "Dehqon togo",
                ProductComment = "yaxshi bolsa kerak",
                ProductUnitPrice = 852369741
                },
                new Product()
                {
                    ProductTitle = "nok",
                ProductManufacturerName = "Dehqon togo",
                ProductComment = "yaxshi bolsa kerak",
                ProductUnitPrice = 852369741
                }
            };
            yield return new object[]
            {
                new int[]{2},
                new ProductDTO()
                {
                    ProductTitle = "xurmo",
                ProductManufacturerName = "Agriculture",
                ProductComment = "bilmiman vabshi",
                ProductUnitPrice = 7539545
                },
                new Product()
                {
                    ProductTitle = "xurmo",
                ProductManufacturerName = "Agriculture",
                ProductComment = "bilmiman vabshi",
                ProductUnitPrice = 753951
                }
            };
        }
        [Theory]
        [MemberData(nameof(UpdateProductDataGenerator),MemberType = typeof(ProductServiceTests))]
        public async Task UpdateProductTest(int[] ids, ProductDTO inputProduct, Product exceptedProduct)
        {
            var newModel = inputProduct.Map<Product>();

            _productService.Setup(x => x.UpdateProductById(It.IsAny<int>(), It.IsAny<ProductDTO>())).ReturnsAsync(newModel);

            var controller = new cProductController(_productService.Object);
            var returnProduct = await controller.UpdateProductById(ids[0], inputProduct);
            Assert.NotNull(returnProduct);
            Assert.True(CompareModels(exceptedProduct, returnProduct));
        }

        #endregion

        // DeleteProductTest
        #region DeleteProductTest
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task DeleteProductTest(int id)
        {
            _productService.Setup(x => x.DeleteProductById(It.IsAny<int>())).ReturnsAsync(true);
            var controller= new cProductController(_productService.Object);
            var returnResult = await controller.DeleteProductById(id);
            Assert.NotNull(returnResult);
            Assert.True(returnResult);
        }
        #endregion

    }
}
