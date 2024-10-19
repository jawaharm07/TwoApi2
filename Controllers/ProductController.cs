using Microsoft.AspNetCore.Mvc;
using TwoApi.Models;
using TwoApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase // Use ControllerBase for API controllers
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // POST: api/product
        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            if (product == null) // Check if the product is null
            {
                return BadRequest("Product cannot be null.");
            }

            await _productService.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetProductsById), new { id = product.Id }, product);
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var list = await _productService.GetProductsAsync();
            return Ok(list);
        }

        // GET: api/product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductsById(int id)
        {
            var product = await _productService.GetProductBYIdAsync(id); // Ensure method name is correct
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // GET: api/product/name/{name}
        [HttpGet("name/{name}")]
        public async Task<ActionResult<Product>> GetProductsByName(string name)
        {
            var product = await _productService.GetProductBYNameAsync(name); // Ensure method name is correct
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // PUT: api/product/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest("Product ID mismatch.");
            }

            await _productService.UpdateProductAsync(product);
            return NoContent();
        }

        // DELETE: api/product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var exists = await _productService.GetProductBYIdAsync(id); // Check if the product exists
            if (exists == null)
            {
                return NotFound();
            }

            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
