using Microsoft.Extensions.DependencyInjection;

public static class MainMenu
{
    public static void Show(ServiceProvider provider)
    {
        while (true)
        {
            Console.WriteLine("\n=== Smart Expense Tracker ===");
            Console.WriteLine("1. Manage Categories");
            Console.WriteLine("2. Manage Expenses");
            Console.WriteLine("0. Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CategoryHandler.Handle(provider);
                    break;
                case "2":
                    ExpenseHandler.Handle(provider);
                    break;
                case "0":
                    return;
            }
        }
    }
}
