using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebApplication1.Models;
using WebApplication1.Models.NewFolder;
using WebApplication1.Models.Request;

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

        //1. Insertar Product
        [HttpPost]
        public IActionResult Insert([FromBody] ProductInsertRequest request)
        {
            var newProduct = new Product
            {
                Name = request.Name,
                Price = request.Price,
            };

            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return Ok(newProduct);

        }

        //2. Eliminar Product
        [HttpPost]
        public IActionResult Delete([FromBody] ProductDeleteRequest request)
        {
            var product = _context.Products.FirstOrDefault((p => p.ProductId == request.ProductId));

            _context.Products.Remove(product);

            _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
