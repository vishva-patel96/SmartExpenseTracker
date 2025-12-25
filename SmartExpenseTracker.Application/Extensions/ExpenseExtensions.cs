using System;
using System.Collections.Generic;
using System.Text;
using SmartExpenseTracker.Domain.Entities;

namespace SmartExpenseTracker.Application.Extensions
{
    public static class ExpenseExtensions
    {
        //to keep code clean and reusable
        //can create extension method for expense entity
        public static decimal GetMonthlyTotal(this IEnumerable<Expense> expense, int month)
        {
            return expense.Where(x => x.Date.Month ==month)
                .Sum(x=>x.Amount);
        }
    }
}
