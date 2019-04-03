using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductQueryApi.Models;

namespace ProductQueryApi.Repository
{
    public interface IProductRepository
    {
        ICollection<Product> GetAll();

        void Add(Product product);

    }
}
