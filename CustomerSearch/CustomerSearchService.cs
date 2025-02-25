using System.Text;

public class CustomerSearchService
{
    private readonly DatabaseContext db;

    public CustomerSearchService(DatabaseContext context)
    {
        db = context;
    }

    public List<Customer> SearchByCountry(string country)
    {
        return db.Customers.Where(c => c.Country.Contains(country)).OrderBy(c => c.CustomerID).ToList();
    }

    public List<Customer> SearchByCompanyName(string company)
    {
        return db.Customers.Where(c => c.CompanyName.Contains(company)).OrderBy(c => c.CustomerID).ToList();
    }

    public List<Customer> SearchByContact(string contact)
    {
        return db.Customers.Where(c => c.ContactName.Contains(contact)).OrderBy(c => c.CustomerID).ToList();
    }

    public string ExportToCSV(List<Customer> data)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in data)
        {
            sb.AppendFormat("{0}, {1}, {2}, {3}", item.CustomerID, item.CompanyName, item.ContactName, item.Country);
            sb.AppendLine();
        }
        return sb.ToString();
    }
}
