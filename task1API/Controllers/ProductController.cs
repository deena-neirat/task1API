using Microsoft.AspNetCore.Mvc;
using task1API.Models;

namespace task1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "book", Description = "this is book" },
            new Product { Id = 2, Name = "car", Description = "this is car" },
            new Product { Id = 3, Name = "bus", Description = "this is bus" },
        };

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = products.First(product => product.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(products[id]);
        }


        [HttpPost]
        public IActionResult Add(Product request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
            };
            products.Add(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product requset)
        {
            var currentProduct = products.FirstOrDefault(product => product.Id == id);

            if (currentProduct is null)
                return NotFound();

            currentProduct.Name = requset.Name;
            currentProduct.Description = requset.Description;

            return Ok(currentProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(product => product.Id == id);
            if (product is null)
                return NotFound();

            products.Remove(product);
            return Ok();
        }
    }
}
