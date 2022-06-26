using System;

namespace Task_11.Products
{
    public abstract class Product
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

        public Product(string? name, int price, double weight)
        {
            if (price < 0 || weight < 0 || name == null)
                throw new ArgumentException("wrong argument");
            this.name = name;
            this.price = price;
            this.weight = weight;
        }

        public abstract Product Clone();

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

        public static bool operator ==(Product? product1, Product? product2)
        {
            if (product1 is not Product || product2 is not Product)
                return false;
            return product1.name == product2.name && product1.price == product2.price &&
                product1.weight == product2.weight;
        }

        public static bool operator !=(Product? product1, Product? product2)
        {
            return !(product1 == product2);
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Name == product.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, Name, price, Price, weight, Weight);
        }
    }
}

