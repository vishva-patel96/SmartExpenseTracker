using Microsoft.Extensions.DependencyInjection;
using SmartExpenseTracker.Domain.Entities;
using SmartExpenseTracker.Infrastructure;

public static class CategoryHandler
{
    public static void Handle(ServiceProvider provider)
    {
        Console.Write("Enter category name: ");
        var name = Console.ReadLine();

        using var scope = provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ExpenseDbContext>();

        context.Category.Add(new Category(name));
        context.SaveChanges();

        Console.WriteLine("Category added successfully.");
    }
}
