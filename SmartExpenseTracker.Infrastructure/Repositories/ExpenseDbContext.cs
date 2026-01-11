using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SmartExpenseTracker.Domain.Entities;

namespace SmartExpenseTracker.Infrastructure
{
    public class ExpenseDbContext : DbContext
    {
        //constructor to pass options to base DbContext class
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Category { get; set; }
        //DbSet for Expense entity
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.category)
                .WithMany()
                .HasForeignKey(e => e.CategoryID);
        }
    }
}
