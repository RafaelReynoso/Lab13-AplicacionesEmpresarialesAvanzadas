using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.NewFolder;
using WebApplication1.Models.Request;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoicesController2 : ControllerBase
    {
        private readonly StoreContext _context;

        public InvoicesController2(StoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] InvoiceInsertRequest request)
        {
            var newInvoce = new Invoice
            {
                
                Date = DateTime.Now,
                InvoiceNumber = request.InvoiceNumber,
                Total = request.Total,
            };

            _context.Invoices.Add(newInvoce);
            _context.SaveChanges();
            return Ok(newInvoce);

        }
    }
}
