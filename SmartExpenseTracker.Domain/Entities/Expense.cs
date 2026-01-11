using System;
using System.Collections.Generic;
using System.Text;

namespace SmartExpenseTracker.Domain.Entities
{
    // Expense entity inheriting from BaseEntity
    public class Expense : BaseEntity
    {
        //get --> anyone can read these values
        //Private set --> values can only change through the constructor
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public int CategoryID { get; private set; }
        public Category category { get; private set; }

        protected Expense() { }

        // created immutable obj
        //created constructor

        public Expense(decimal amount,DateTime date, int categoryID)
        {
            if(amount <= 0)
            {
                throw new Exception("Amount must be greater than zero");
            }
            else
            {
                Amount = amount;
                Date = date;
                CategoryID = categoryID;
            }
        }
        public void Update(decimal amount, DateTime date, int categoryID)
        {
            if (amount <= 0)
            {
                throw new Exception("Amount must be greater than zero");
            }
            else
            {
                Amount = amount;
                Date = date;
                CategoryID = categoryID;
            }
        }
    }
}
