using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly StoreContext _context;

        public DetailsController(StoreContext context)
        {
            _context = context;
        }

        // GET: api/details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detail>>> Listar()
        {
            var details = await _context.Details.ToListAsync();
            return Ok(details);
        }

        // POST: api/details/crear
        [HttpPost]
        public async Task<ActionResult<Detail>> Crear([FromBody] Detail details)
        {
            _context.Details.Add(details);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Listar), new { id = details.DetailId }, details);
        }
    }
}
