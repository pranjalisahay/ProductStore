using Microsoft.AspNetCore.Mvc;
using ProductQueryApi.Models;
using ProductQueryApi.Repository;
using ProductQueryModels;
using System;
using System.Collections.Generic;

namespace ProductQueryApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        static int counter = 1;
        private IProductManagementRepository productRepository;

        public ProductController( 
            IProductManagementRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> All()
        {
            return this.productRepository.GetAllProducts();
        }

        [HttpGet]
        [Route("GetSpecificProduct")]
        public Product GetSpecificProduct([FromQuery] int id)
        {
            return this.productRepository.GetProductById(id);
        }

        [HttpPost]
        public void Add([FromBody] Product product)
        {
            //var product1 = new Product
            //{
            //    ProductName = "book 1",
            //    ProductId = counter,
            //    Description = "book 1 Description",
            //    Price = 100,
            //    CatagoryId = 1,
            //    Catagory = new Catagory
            //    {
            //        CatagoryId = 1,
            //        CatagorCode = "categorycode",
            //        CatagoryDesc = "categoryDescription",
            //        CatagoryName = "categoryName"
            //    }
            //};
            
            this.productRepository.AddProduct(product);
            //counter++;
        }

        [HttpGet]
        [Route("GetProductsOnSearchedCriteria")]
        public IEnumerable<Product> GetMatchingProducts([FromQuery] string searchedText)
        {
            return this.productRepository.GetSearchedProducts(searchedText);
        }
    }
}
