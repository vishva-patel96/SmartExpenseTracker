using SmartExpenseTracker.Domain.Entities;
using SmartExpenseTracker.Domain.Interfaces;
namespace SmartExpenseTracker.Application.Services
{
    //Implementation of IExpenseRepository interface
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task AddAsync(Expense expense)
        {
            await _expenseRepository.AddAsync(expense);
        }

        public async Task UpdateAsync(Expense expense)
        {
            await _expenseRepository.UpdateAsync(expense);
        }

        public async Task DeleteAsync(int expenseId)
        {
            await _expenseRepository.DeleteAsync(expenseId);
        }

        public async Task<List<Expense>> GetAllAsync()
        {
            return await _expenseRepository.GetAllExpensesAsync();
        }
    }
}
