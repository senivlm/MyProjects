using System;

namespace Task_14.Products.Interfaces
{
    public interface IExpirable
    {
        public DateTime TimeToExpire { get; }
        public bool IsExpired() => DateTime.Now > TimeToExpire;

    }
}

