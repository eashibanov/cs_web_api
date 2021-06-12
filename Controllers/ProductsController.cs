using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTO;
using ProductsAPI.Models;
using ProductsAPI.Repositories;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("products/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int Id)
        {
            var product = await productRepository.Get(Id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await productRepository.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProductDTO dto)
        {
            Product product = new() 
            {
                Name = dto.Name,
                Price = dto.Price,
                DateCreated = System.DateTime.Now
            };

            await productRepository.Add(product);
            return Ok(product);
        }

        [HttpDelete("products/{id}")]
        public async Task<ActionResult> DeleteProduct(int Id)
        {
            await productRepository.Delete(Id);
            return Ok();
        }

        [HttpPut("products/{id}")]
        public async Task<ActionResult> DeleteProduct(int Id, UpdateProductDTO dto)
        {
            Product product = new() 
            {
                ProductId = Id,
                Name = dto.Name,
                Price = dto.Price
            };
            await productRepository.Update(product);
            return Ok();
        }
    }
}