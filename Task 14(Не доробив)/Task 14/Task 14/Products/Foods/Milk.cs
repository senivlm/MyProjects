using System;
using Task_14.Products.Interfaces;

namespace Task_14.Products.Foods
{
    [Serializable]
    public class Milk : Food, IMilk
    {
        private DateTime timeToExpire;
        public DateTime TimeToExpire
        {
            get
            {
                return timeToExpire;
            }
        }

        public Milk(Milk milkProduct) : base(milkProduct)
        {
            if (milkProduct == null)
                return;
            timeToExpire = milkProduct.timeToExpire;
        }

        public Milk(string? name, int price, double weight, DateTime date)
            : base(name, price, weight)
        {
            timeToExpire = date;
        }

        public override Food Clone()
        {
            return new Milk(this);
        }

        public bool IsExpired() => DateTime.Now > TimeToExpire;

        public override void ChangePrice(int percentage)
        {
            if (IsExpired())
            {
                percentage = percentage > 40 ? percentage - 30 : percentage;
            }
            Price = (int)(Price * (percentage / 100d));
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(".Date to expire: {0}", TimeToExpire);
        }

        public override bool Equals(object? obj)
        {
            return obj is Milk product &&
                   Name == product.Name;
        }

        public new void Parse(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException();
            }
            base.Parse(text);
            string[] arrayString = text.Split(' ');

            if (!DateTime.TryParse(arrayString[3], out timeToExpire))
            {
                throw new ArgumentException();
            }
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(base.GetHashCode());
            hash.Add(name);
            hash.Add(Name);
            hash.Add(price);
            hash.Add(Price);
            hash.Add(weight);
            hash.Add(Weight);
            hash.Add(timeToExpire);
            hash.Add(TimeToExpire);
            return hash.ToHashCode();
        }
    }
}

