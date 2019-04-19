using Catalog.Events;
using Catalog.Models;
using Catalog.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private ICommandEventConverter converter;
        private IEventEmitter eventEmitter;

        private IProductRepository productRepository;

        public ProductController(ICommandEventConverter converter,
            IEventEmitter eventEmitter, 
            IProductRepository productRepository)
        {
            this.converter = converter;
            this.eventEmitter = eventEmitter;
            this.productRepository = productRepository;
        }

        [HttpGet]
        public ICollection<Product> All()
        {
            return this.productRepository.GetAll();
        }

        [HttpPost]
        public ActionResult Add([FromBody]Product product)
        {
            var id = this.productRepository.Add(product);

            NewProductEvent newProductEvent = converter.CommandToEvent(product);
            newProductEvent.ProductId = Guid.Parse(id);
            eventEmitter.EmitProductAddedEvent(newProductEvent);

            return Ok(id);
        }
    }
}
