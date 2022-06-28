using System;

namespace Task_11.Products
{
    public class SomeProduct : Product
    {
        public SomeProduct(SomeProduct? product) : this()
        {
            if (product == null)
            {
                return;
            }
            name = product.name;
            price = product.price;
            weight = product.weight;
        }

        public SomeProduct() : this(default, default, default)
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

