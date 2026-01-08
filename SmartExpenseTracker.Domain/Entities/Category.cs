using System;
using System.Collections.Generic;
using System.Text;

namespace SmartExpenseTracker.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }

        protected Category() { }

        public Category(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Category name cannot be null or empty.", nameof(name));
            }
            else
            {
                Name = name;
            }
        }

    }
}
