using Microsoft.AspNetCore.Mvc;
using ProductQueryApi.Models;
using ProductQueryApi.Repository;
using System;
using System.Collections.Generic;

namespace ProductQueryApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductRepository productRepository;

        public ProductController( 
            IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public ICollection<Product> All()
        {
            return this.productRepository.GetAll();
        }
    }
}
