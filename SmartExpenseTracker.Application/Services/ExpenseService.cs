using SmartExpenseTracker.Domain.Entities;
using SmartExpenseTracker.Domain.Interfaces;
namespace SmartExpenseTracker.Application.Services
{
    //Implementation of IExpenseRepository interface
    public class ExpenseService :IExpenseRepository
    {
        //dependency injection of repository
        private readonly IExpenseRepository _expenseRepository;

        //constructor to initialize repository
        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        //async method to add expense
        public async Task AddAsync(Expense expense)
        {
            await _expenseRepository.AddAsync(expense);
        }

        //async method to get all expenses
        public async Task<List<Expense>> GetAllExpensesAsync()
        {
            return await _expenseRepository.GetAllExpensesAsync();
        }
        //added Linq query to get monthly total expenses
        public decimal GetMonthlyTotal(IEnumerable<Expense> expense, int month)
        {
            return expense.Where(x => x.Date.Month == month)
                           .Sum(x => x.Amount);
        }
    }
}
