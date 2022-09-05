using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public interface IProductsRepository
   {
        Products GetProducts(int id);
        IEnumerable<Products> GetProducts();
        void AddProduct(Products product);
        void UpdateProduct(Products product);
        void DeleteProduct(Products product);

        IEnumerable<productsinformation> GetProducts2();
    }

    
}
