namespace SmartExpenseTracker.Domain.Events
{
    // Delegate react when total budget is exceeded
    public delegate void BudgetExceededHandler(decimal total);
}