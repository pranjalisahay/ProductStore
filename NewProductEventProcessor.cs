using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProductQueryApi.Models;
using ProductQueryApi.Queues;
using ProductQueryApi.Repository;
using ProductQueryModels;

namespace ProductQueryApi.Events
{
    public class NewProductEventProcessor : IEventProcessor
    {
        private ILogger logger;
        private IEventSubscriber subscriber;

        public NewProductEventProcessor(
            ILogger<NewProductEventProcessor> logger,
            IEventSubscriber eventSubscriber,
            IProductManagementRepository productRepository
        )
        {
            this.logger = logger;
            this.subscriber = eventSubscriber;
            this.subscriber.ProductAddedEventReceived += (prd) => {
                if (prd?.Product != null)
                {
                    productRepository.AddProduct(prd.Product);
                }
                else if(prd?.Catagory!=null)
                {
                    productRepository.AddCatagory(prd.Catagory);
                }
                //productRepository.Add(new Product()
                //{
                //    ProductName = prd.Name,
                //    ProductId = prd.ProductId,
                //    Catagory = prd.Category
                //});
            };
        }

        public void Start()
        {
            this.subscriber.Subscribe();
        }

        public void Stop()
        {
            this.subscriber.Unsubscribe();
        }
    }
}
