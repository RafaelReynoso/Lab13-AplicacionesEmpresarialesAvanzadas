using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Listar()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        // POST: api/products/crear
        [HttpPost]
        public async Task<ActionResult<Product>> Crear([FromBody] Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Listar), new { id = product.ProductId }, product);
        }

        // GET: api/products/buscarporprecio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> BuscarPorPrecio(float price)
        {

            var products = await _context.Products
                .Where(p => p.Price > price)
                .ToListAsync();

            return Ok(products);
        }

        // GET: api/products/ordernarpornombre
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> OrderByName()
        {

            var products = await _context.Products
                .OrderBy(p => p.Name)
                .ToListAsync();

            return Ok(products);
        }
    }
}
