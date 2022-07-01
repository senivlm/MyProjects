using System;

namespace Task_11.Products
{
    public class SomeProduct : Product
    {
        public SomeProduct(SomeProduct product) : this(product.name, product.price, product.weight)
        {
        }

        public SomeProduct(string? name, int price, double weight) : base(name, price, weight)
        {

        }

        public override Product Clone()
        {
            return new SomeProduct(this);
        }
    }
}

