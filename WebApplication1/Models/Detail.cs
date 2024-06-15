namespace WebApplication1.Models
{
    public class Detail
    {
        public Detail()
        {
            Invoices = new List<Invoice>();
            Products = new List<Product>();
        }
        public int DetailId { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public float SubTotal { get; set; }

        public List<Invoice> Invoices { get; set; }
        public List<Product> Products { get; set; }
    }
}
