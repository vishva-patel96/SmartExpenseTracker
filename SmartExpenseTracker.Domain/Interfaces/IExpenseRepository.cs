using SmartExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartExpenseTracker.Domain.Interfaces
{
    public interface IExpenseRepository
    {
        //async method to add a new expense to data store
        Task AddAsync(Expense expense);
        //async method to retive all expense from data store, and return as a list
        Task<List<Expense>> GetAllExpensesAsync();
    }
}
