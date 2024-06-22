using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.Request;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerUpdateController3 : ControllerBase
    {
        private readonly StoreContext _context;

        public CustomerUpdateController3(StoreContext context)
        {
            _context = context;
        }

        [HttpPut]
        public IActionResult Update(int CustomerId, [FromBody] CustomerUpdateRequest request)
        {
            var customer = _context.Customers.Find(CustomerId);
            customer.DocumentNumber = request.DocumentNumber;
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(customer);

        }
    }
}
