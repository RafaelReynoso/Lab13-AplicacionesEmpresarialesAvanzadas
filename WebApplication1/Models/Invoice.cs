namespace WebApplication1.Models
{
    public class Invoice
    {
        public Invoice()
        {
            Customers = new List<Customer>();
        }
        public int InvoiceId { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public float Total { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
