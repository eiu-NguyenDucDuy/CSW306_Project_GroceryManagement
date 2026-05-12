using GroceryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceryManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Apple", Price = 0.5m },
            new Product { Id = 2, Name = "Banana", Price = 0.3m },
            new Product { Id = 3, Name = "Carrot", Price = 0.2m }
        };

        [HttpGet("/products")]
        public ActionResult<List<Product>> GetAllProducts()
        {
            return Products;
        }

        [HttpGet("/products/{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(new { Message = $"Product with ID {id} not found." });
            }

            return product;
        }

        [HttpPost("/products/add")]
        public ActionResult<Product> AddProduct([FromBody] Product newProduct)
        {
            newProduct.Id = Products.Max(p => p.Id + 1);
            Products.Add(newProduct);
            return Ok(Products);
        }

        [HttpPut("/products/{id}")]
        public ActionResult<Product> UpdateProduct(int id, Product updatedProduct)
        {
            Product exisitingProduct = Products.First(p => p.Id == id);

            if (exisitingProduct == null)
            {
                return NotFound(new { Message = $"Product with ID {id} not found." });
            }

            exisitingProduct.Name = updatedProduct.Name;
            exisitingProduct.ThumbnailUrl = updatedProduct.ThumbnailUrl;
            exisitingProduct.Description = updatedProduct.Description;
            exisitingProduct.Price = updatedProduct.Price;

            return Ok(exisitingProduct);
        }

        [HttpDelete("/products/{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            Product product = Products.Find(p => p.Id == id);

            if (product == null)
            {
                return NotFound(new { Message = $"Product with ID {id} not found." });
            }

            Products.Remove(product);

            return NoContent();
        }
    }
}
