using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Request;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController2 : ControllerBase
    {
        private readonly StoreContext _context;

        public CustomersController2(StoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] CustomerInsertRequest request)
        {
            var newCustomer = new Customer
            {
                FirstName = request.FirstName,
                lastName = request.lastName,
                DocumentNumber = request.DocumentNumber,

            };

            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
            return Ok(newCustomer);

        }

        [HttpPost]
        public IActionResult Delete([FromBody] CustomerDeleteRequest request)
        {
            var customer = _context.Customers.FirstOrDefault((c => c.CustomerId == request.CustomerId));

            _context.Customers.Remove(customer);

            _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
