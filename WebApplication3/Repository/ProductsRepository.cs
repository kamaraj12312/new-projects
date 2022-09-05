using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class ProductRepository : IProductsRepository
    {
        protected TestDBContext _context;

        public ProductRepository(TestDBContext context)
        {
            _context = context;
        }
        public Products GetProducts(int id)
        {
            return _context.Products.AsNoTracking().FirstOrDefault(p => p.ProdId == id);
        }

        public IEnumerable<Products> GetProducts()
        {

            return _context.Products.AsNoTracking().ToList();
        }

        public void AddProduct(Products product)
        {
                _context.Products.Add(product);
                _context.SaveChanges();
 

        }

        public void DeleteProduct(Products product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }

      
       
        public IEnumerable<productsinformation> GetProducts2()
        {
             var prodList = (from p in _context.Products
                            join pm in _context.Market on p.ModelId equals pm.Marketname
                            join pd in _context.Sales on p.ProdId equals pd.SalesId
                            select new productsinformation
                            {
                                ProdId = p.ProdId,
                                ProdName = p.ProdName,
                                Price = p.Price,
                                Marketname = pm.Marketname,
                                SalesId = pd.SalesId

                            }).ToList();

            return prodList;
        }

        public void UpdateProduct(Products product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
