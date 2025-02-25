using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerID = 1, CompanyName = "ABC Corp", ContactName = "John Doe", Country = "USA" },
            new Customer { CustomerID = 2, CompanyName = "XYZ Ltd", ContactName = "Alice Smith", Country = "UK" },
            new Customer { CustomerID = 3, CompanyName = "Tech Solutions", ContactName = "Bob Johnson", Country = "Canada" }
        );
    }
}
