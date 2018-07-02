using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.API.Models;
using SimpleApp.API.Repositories;

namespace SimpleApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsRepository _repository;

        public ProductsController(ProductsRepository repository)
        {
            _repository = repository;
        }



        [HttpGet]
        public ActionResult<List<Product>> Get([FromQuery] bool discontinuedOnly = false)
        {
            List<Product> products = null;

            if (discontinuedOnly)
            {
                products = _repository.GetDiscontinuedProducts();
            }
            else
            {
                products = _repository.GetProducts();
            }

            return products;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Product> GetById(int id)
        {
            if (!_repository.TryGetProduct(id, out var product))
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Product>> CreateAsync(Product product)
        {
            await _repository.AddProductAsync(product);

            return CreatedAtAction(nameof(GetById),
                new { id = product.Id }, product);
        }
    }
}