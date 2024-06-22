namespace WebApplication1.Models.Request
{
    public class InvoiceInsertRequest
    {
        public InvoiceInsertRequest()
        {
            Customers = new List<Customer>();
        }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public float Total { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
