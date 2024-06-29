using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Request;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoicesController3 : ControllerBase
    {
        private readonly StoreContext _context;

        public InvoicesController3(StoreContext context)
        {
            _context = context;
        }

        //8. Insertar Lista de Factura por cliente
        [HttpPost]
        public IActionResult Insert([FromBody] InvoiceInsertFacturaCliente request)
        {
            var customer = _context.Customers.Find(request.CustomerId);

            foreach (var invoice in request.Invoices)
            {
                invoice.Customers.Add(customer);
                _context.Invoices.Add(invoice);
            }

            _context.SaveChanges();
            return Ok();
        }

    }
}
