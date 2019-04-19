using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductQueryApi.Models;
using ProductQueryModels;

namespace ProductQueryApi.Repository
{
    public interface IProductManagementRepository
    {
        IEnumerable<Product> GetAllProducts();

        void AddProduct(Product product);

        Product GetProductById(int id);

        IEnumerable<Catagory> GetAllCatagories();

        void AddCatagory(Catagory catagory);

        Catagory GetCatagoryById(int id);

        IEnumerable<Product> GetSearchedProducts(string searchedCriteria);
    }
}
