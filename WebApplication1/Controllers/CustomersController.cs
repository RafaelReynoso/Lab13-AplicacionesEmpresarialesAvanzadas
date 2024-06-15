using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly StoreContext _context;

        public CustomersController(StoreContext context)
        {
            _context = context;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Listar()
        {
            var customer = await _context.Customers.ToListAsync();
            return Ok(customer);
        }

        // POST: api/customers/crear
        [HttpPost]
        public async Task<ActionResult<Customer>> Crear([FromBody] Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Listar), new { id = customer.CustomerId }, customer);
        }

        // GET: api/customers/buscaryordenar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> BuscarCustomerLastName()
        {

            var customers = await _context.Customers
                .OrderByDescending(p => p.lastName)
                .ToListAsync();

            return Ok(customers);
        }


    }
}
