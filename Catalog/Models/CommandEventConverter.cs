using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Events;

namespace Catalog.Models
{
    public class CommandEventConverter : ICommandEventConverter
    {
        public NewProductEvent CommandToEvent(Product product)
        {
            var newproductEvent = new NewProductEvent()
            {
                Name =  product.Name,
                ProductId = product.ProductId,
                Category = product.Category
            };

            return newproductEvent;
        }
    }
}
