using Microsoft.EntityFrameworkCore;
using SmartExpenseTracker.Domain.Entities;
using SmartExpenseTracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

//expense repository implementation, so application and domain layers never touch EF Core directly
namespace SmartExpenseTracker.Infrastructure.Repositories
{
    //Implementing the IExpenseRepository interface
    public class ExpenseRepository: IExpenseRepository
    {
        public readonly ExpenseDbContext _context;
        //constructor to initialize DbContext via dependency injection
        public ExpenseRepository(ExpenseDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Expense expense)
        {
            //Add the expense entity to the DbContext and Save changes
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Expense>> GetAllExpensesAsync()
        {
            //Retrieve all expenses from the DbContext as a list
            return await _context.Expenses.AsNoTracking().ToListAsync();
        }
    }
}
