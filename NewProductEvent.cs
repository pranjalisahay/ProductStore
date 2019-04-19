using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProductQueryModels;

namespace ProductQueryApi.Events
{
    public class NewProductEvent
    {
        public Product Product { get; set; }

        public Catagory Catagory { get; set; }

        //public Guid ProductId { get; set; }

        //public string Name { get; set; }

        //public string Category { get; set; }
    }
}
