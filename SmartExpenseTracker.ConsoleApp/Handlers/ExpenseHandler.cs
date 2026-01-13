using Microsoft.Extensions.DependencyInjection;
using SmartExpenseTracker.Domain.Entities;
using SmartExpenseTracker.Domain.Interfaces;

public static class ExpenseHandler
{
    public static void Handle(ServiceProvider provider)
    {
        Console.WriteLine("\n1. Add Expense");
        Console.WriteLine("2. Update Expense");
        Console.WriteLine("3. Delete Expense");
        Console.WriteLine("4. View Expenses");

        var choice = Console.ReadLine();

        using var scope = provider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IExpenseService>();

        switch (choice)
        {
            case "1":
                AddExpense(service);
                break;
            case "2":
                UpdateExpense(service);
                break;
            case "3":
                DeleteExpense(service);
                break;
            case "4":
                ViewExpenses(service);
                break;
        }
    }

    private static void AddExpense(IExpenseService service)
    {
        Console.Write("Amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        Console.Write("Category Id: ");
        int categoryId = int.Parse(Console.ReadLine());

        service.AddAsync(new Expense(amount, DateTime.Now, categoryId)).Wait();
        Console.WriteLine("Expense added.");
    }

    private static void UpdateExpense(IExpenseService service)
    {
        Console.Write("Expense Id: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("New Amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        service.UpdateAsync(new Expense(amount, DateTime.Now, 1)).Wait();
        Console.WriteLine("Expense updated.");
    }

    private static void DeleteExpense(IExpenseService service)
    {
        Console.Write("Expense Id: ");
        int id = int.Parse(Console.ReadLine());

        service.DeleteAsync(id).Wait();
        Console.WriteLine("Expense deleted.");
    }

    private static void ViewExpenses(IExpenseService service)
    {
        var expenses = service.GetAllAsync().Result;

        foreach (var e in expenses)
        {
            Console.WriteLine($"Id:{e.Id} Amount:{e.Amount} Category:{e.CategoryID}");
        }
    }
}
