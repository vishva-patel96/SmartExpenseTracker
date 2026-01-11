using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json; // Add this using directive

using System.IO;

namespace SmartExpenseTracker.Infrastructure;

public sealed class ExpenseDbContextFactory : IDesignTimeDbContextFactory<ExpenseDbContext>
{
    public ExpenseDbContext CreateDbContext(string[] args)
    {
        var consoleAppPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "SmartExpenseTracker.ConsoleApp");
        var configuration = new ConfigurationBuilder()
            .SetBasePath(consoleAppPath)
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var connectionString = configuration.GetConnectionString("ExpenseDb");

        var options = new DbContextOptionsBuilder<ExpenseDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        return new ExpenseDbContext(options);
    }
}