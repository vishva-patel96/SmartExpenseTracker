using System;
using System.Collections.Generic;
using System.Text;

namespace SmartExpenseTracker.Domain.Entities
{
    //create a abstract class --> cannot be used to create objects directly
    //need to be inherited by other classes -- follow DRY principle
    public abstract class BaseEntity
    {
        //get --> anyone can read the value
        //protected set --> only this class and derived classes can change the value
        public int Id { get; protected  set; }
    }
}
