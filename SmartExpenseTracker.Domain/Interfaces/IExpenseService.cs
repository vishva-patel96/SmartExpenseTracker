using SmartExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartExpenseTracker.Domain.Interfaces
{
    public interface IExpenseService
    {
        Task AddAsync(Expense expense);
        Task UpdateAsync(Expense expense);
        Task DeleteAsync(int expenseId);
        Task<List<Expense>> GetAllAsync();
    }
}
