using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        try
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "CustomerDB")
                .Options;

            using var context = new DatabaseContext(options);
            context.Database.EnsureCreated();

            var searchService = new CustomerSearchService(context);

            int searchType = GetSearchType();
            string keyword = GetSearchKeyword();

            List<Customer> results = SafeExecute(() => SearchCustomers(searchService, searchType, keyword), []);

            DisplayResults(results);

            string csvData = SafeExecute(() => searchService.ExportToCSV(results), string.Empty);
            Console.WriteLine("CSV data : " + csvData);
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

    static int GetSearchType()
    {
        Console.WriteLine("Enter search type (1: Country, 2: Company, 3: Contact): ");
        if (int.TryParse(Console.ReadLine(), out int searchType) && searchType is >= 1 and <= 3)
        {
            return searchType;
        }

        Console.WriteLine("Invalid input. Please enter a valid search type.");
        return GetSearchType();
    }

    static string GetSearchKeyword()
    {
        Console.WriteLine("Enter search keyword: ");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Keyword cannot be empty. Please enter a valid keyword.");
            return GetSearchKeyword();
        }

        return input.Trim();
    }

    static List<Customer> SearchCustomers(CustomerSearchService searchService, int searchType, string keyword)
    {
        return searchType switch
        {
            1 => searchService.SearchByCountry(keyword),
            2 => searchService.SearchByCompanyName(keyword),
            3 => searchService.SearchByContact(keyword),
            _ => throw new ArgumentException("Invalid search type")
        };
    }

    static void DisplayResults(List<Customer> results)
    {
        if (results.Count == 0)
        {
            Console.WriteLine("No customers found.");
            return;
        }

        Console.WriteLine("\nSearch Results:");
        foreach (var customer in results)
        {
            Console.WriteLine($"ID: {customer.CustomerID}, Name: {customer.CompanyName}, Contact: {customer.ContactName}, Country: {customer.Country}");
        }
    }

    static void HandleException(Exception ex)
    {
        switch (ex)
        {
            case DbUpdateException:
                Console.WriteLine("Database operation failed: " + ex.Message);
                break;
            case FormatException:
                Console.WriteLine("Invalid format: " + ex.Message);
                break;
            case ArgumentException:
                Console.WriteLine("Argument error: " + ex.Message);
                break;
            default:
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                break;
        }
    }

    static T SafeExecute<T>(Func<T> func, T fallbackValue)
    {
        try
        {
            return func();
        }
        catch (Exception ex)
        {
            HandleException(ex);
            return fallbackValue;
        }
    }
}
