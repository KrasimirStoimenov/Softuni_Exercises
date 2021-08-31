namespace WebApiExercise.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using WebApiExercise.Data;
    using WebApiExercise.Data.Models;
    using WebApiExercise.ViewModels;
    using Microsoft.EntityFrameworkCore;

    [Route("/api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly WebApiDbContext data;

        public ProductsController(WebApiDbContext data)
        {
            this.data = data;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await this.data.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await this.data.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(ProductInputViewModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Quantity = model.Quantity,
            };

            await this.data.Products.AddAsync(product);
            await this.data.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = product.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ProductInputViewModel model)
        {
            if (!await this.data.Products.AnyAsync(x => x.Id == id))
            {
                return BadRequest();
            }

            var product = this.data.Products.Find(id);

            product.Name = model.Name;
            product.Description = model.Description;
            product.Quantity = model.Quantity;

            await this.data.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var product = await this.data.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            this.data.Remove(product);
            this.data.SaveChanges();

            return product;
        }
    }
}
