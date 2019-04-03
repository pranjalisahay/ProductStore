using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Catalog.Events
{
    public class NewProductEvent
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string toJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
