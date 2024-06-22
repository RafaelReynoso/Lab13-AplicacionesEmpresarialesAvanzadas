using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Request;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsUpdateController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsUpdateController(StoreContext context)
        {
            _context = context;
        }

        [HttpPut]
        public IActionResult Update(int ProductId, [FromBody] ProductUpdateRequest request)
        {
            var product = _context.Products.Find(ProductId);
            product.Name = request.Name;
            product.Price = request.Price;
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(product);

        }
    }
}
