using System;

namespace ProductProject
{
    public class SomeProduct : Product
	{
		public SomeProduct() : this(default, default, default)
		{

		}

		public SomeProduct(string name, int price, double weight) : base(name, price, weight)
		{

		}
    }
}

