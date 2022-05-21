using System;

namespace ProductProject
{
    public class Product
	{
        private string name;
		public string Name 
		{ 
			get 
			{
				return name;
			}
		}
		private int price;
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
		private double weight;
		public double Weight
		{ 
			get 
			{
				return weight;
			} 
		}

		public Product() : this(default, default, default)
		{

		}

		public Product(string name, int price, double weight)
		{
			if (price < 0 || weight < 0 || name == null)
				throw new ArgumentException("wrong argument");
			this.name = name;
			this.price = price;
			this.weight = weight;
		}

		public virtual void ChangePrice(int percentage)
        {
			Price = (int)(Price * (percentage / 100d));
		}

        public override string ToString()
        {
            return string.Format("name: {0}, price: {1}, weight: {2}", name, price, Weight);
        }
		
		public void Parse(string text)
        {
			if(text == null)
            {
				throw new ArgumentNullException();
            }
			string[] arrayString = text.Split(' ');
			name = arrayString[0];

			if(!int.TryParse(arrayString[1], out price) || 
				!double.TryParse(arrayString[2], out weight))
            {
				throw new ArgumentException();
			}
        }

	}
}

