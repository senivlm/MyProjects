using System;

namespace ProductProject
{
    public abstract class Product : ISaleableItem
	{
		protected string name;
		public string Name
		{
			get
			{
				return name;
			}
		}
		protected int price;
		public int Price
		{
			get
			{
				return price;
			}
			set
			{
				if (price < 0)
				{
					throw new ArgumentException();
				}
				price = value;
			}
		}
		protected double weight;
		public double Weight
		{
			get
			{
				return weight;
			}
		}

		public Product(string name, int price, double weight)
		{
			if (price < 0 || weight < 0 || name == null)
				throw new ArgumentException("wrong argument");
			this.name = name;
			this.price = price;
			this.weight = weight;
		}

		public override string ToString()
		{
			return string.Format("name: {0}, price: {1}, weight: {2}", name, price, Weight);
		}

		public virtual void ChangePrice(int percentage)
		{
			Price = (int)(Price * (percentage / 100d));
		}

        public void Parse(string text)
        {
            throw new NotImplementedException();
        }

		public override bool Equals(object obj)
		{
			return obj is ISaleableItem product &&
				   Name == product.Name &&
				   Price == product.Price &&
				   Weight == product.Weight;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(name, Name, price, Price, weight, Weight);
		}
	}
}

