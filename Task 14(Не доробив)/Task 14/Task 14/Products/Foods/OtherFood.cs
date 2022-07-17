using System;
using Task_14.Products.Interfaces;

namespace Task_14.Products.Foods
{
    [Serializable]
    public class OtherFood : Food
    {
        public OtherFood() : base("Food", default, default)
        {

        }

        public OtherFood(OtherFood product) : this(product.name, product.price, product.weight)
        {
        }

        public OtherFood(string? name, int price, double weight) : base(name, price, weight)
        {

        }

        public override Food Clone()
        {
            return new OtherFood(this);
        }
    }
}

