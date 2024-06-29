namespace WebApplication1.Models.Request
{
    //8. Insertar Lista de Factura por cliente
    public class CustomerInsertFacturaCliente
    {
        public int CustomerId { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
