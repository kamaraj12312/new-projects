using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IProductsRepository _productRepository;
        public ValuesController(IProductsRepository productRepositor)
        {
            _productRepository = productRepositor;

        }
        [HttpGet]
        [Route("GetProducts")]
        public IEnumerable<Products> GetProducts()
        {
            return _productRepository.GetProducts().ToList();
        }

        [HttpGet("{id}")]

        public ActionResult<Products> GetProducts(int id)
        {

            var prod = _productRepository.GetProducts(id);
            if (prod is null) return NotFound();
            return prod;
        }


        [HttpPost("[action]")]
        public ActionResult<Products> AddProduct(Products product)
        {
            _productRepository.AddProduct(product);
            return CreatedAtAction(nameof(GetProducts), new { id = product.ProdId }, product);
        }

        [HttpPut("[action]/{id}")]
        public ActionResult<Products> UpdateProduct(int id, Products product)
        {
            var prod = _productRepository.GetProducts(id);
            if (prod is null) return NotFound();
            prod.ProdName = product.ProdName;
            prod.Price = product.Price;

            _productRepository.UpdateProduct(prod);
            return Ok();

        }


        //[HttpDelete("[action]/{id}")]

        [HttpDelete("[action]/{id}")]

        public ActionResult DeleteProduct(int id)
        {
            var prod = _productRepository.GetProducts(id);
            if (prod is null)
                return NotFound();
            _productRepository.DeleteProduct(prod);
            return Ok();

        }

        [HttpGet]
        [Route("GetProducts2")]
        public IEnumerable<productsinformation> GetProducts2()
        {
            return _productRepository.GetProducts2().ToList();
        }
    }
}
