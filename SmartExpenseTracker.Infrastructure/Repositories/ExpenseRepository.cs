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
        public async Task UpdateAsync(Expense expense)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int expenseId)
        {
            var expense = await _context.Expenses.FindAsync(expenseId);
            if (expense == null)
                throw new Exception("Expense not found");

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<Expense?> GetByIdAsync(int expenseId)
        {
            return await _context.Expenses.FindAsync(expenseId);
        }
        public async Task<List<Expense>> GetAllExpensesAsync()
        {
            //Retrieve all expenses from the DbContext as a list
            return await _context.Expenses
         .Include(e => e.category)  // 🔑 This loads the Category data
         .AsNoTracking()
         .ToListAsync();
        }
    }
}
