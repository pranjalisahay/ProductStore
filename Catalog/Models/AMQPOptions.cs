using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class AMQPOptions
    {
        public AMQPOptions()
        {
            this.Username = "guest";
            this.Password = "guest";
            this.HostName = "localhost";
            this.Uri = "amqp://localhost:5672/";
            this.VirtualHost = "/";


        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string VirtualHost { get; set; }
        public string HostName { get; set; }
        public string Uri { get; set; }
    }
}
