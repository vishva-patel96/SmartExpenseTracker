using SmartExpenseTracker.Domain.Entities;
using SmartExpenseTracker.Domain.Interfaces;
namespace SmartExpenseTracker.Application.Services
{
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
    }
}
