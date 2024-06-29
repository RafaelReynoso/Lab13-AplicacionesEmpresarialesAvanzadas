using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class StoreContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Detail> Details { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=PC-RAFAEL\\SQLEXPRESS;" + "Initial Catalog=StoreDB; Integrated Security = True;trustservercertificate=True");
        }
    }
}
