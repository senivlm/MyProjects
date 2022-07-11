using System;

namespace Task_11.Products
{
    public interface IExpirableProduct
    {
        public DateTime TimeToExpire { get; }
        public bool IsExpired();
    }
}

