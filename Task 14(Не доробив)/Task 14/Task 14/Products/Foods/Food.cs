using System;
using Task_14.Products.Interfaces;

namespace Task_14.Products.Foods
{
    [Serializable]
    public abstract class Food : IFood, ICloneable<Food>
    {
        protected string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(value != null)
                    name = value;
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
            set
            {
                if(weight < 0)
                {
                    throw new ArgumentException();
                }
                weight = value;
            }
        }

        public Food(string? name, int price, double weight)
        {
            if (price < 0 || weight < 0 || name == null)
                throw new ArgumentException("wrong argument");
            this.name = name;
            this.price = price;
            this.weight = weight;
        }

        public Food(IFood product)
            : this(product.Name, product.Price, product.Weight)
        {
        }

        public abstract Food Clone();

        public override string ToString()
        {
            return string.Format("name: {0}, price: {1}, weight: {2}", name, price, Weight);
        }

        public virtual void ChangePrice(int percentage)
        {
            Price = (int)(Price * (percentage / 100d));
        }

        public static bool operator ==(Food? product1, Food? product2)
        {
            if (product1 is not IFood || product2 is not IFood)
                return false;
            return product1.name == product2.name && product1.price == product2.price &&
                product1.weight == product2.weight;
        }

        public static bool operator !=(Food? product1, Food? product2)
        {
            return !(product1 == product2);
        }

        public override bool Equals(object? obj)
        {
            return obj is IFood product &&
                   Name == product.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, Name, price, Price, weight, Weight);
        }

        public void Parse(string text)
        {
            var data = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            name = data[0];
            price = int.Parse(data[1]);
            weight = double.Parse(data[2]);

        }
    }
}

