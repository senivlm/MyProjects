using System;

namespace ProductProject
{
    public class MilkProducts : Product, IExpirableProduct
    {
        private DateTime timeToExpire;
        public DateTime TimeToExpire { 
            get
            {
                return timeToExpire;
            } 
        }

        public MilkProducts() : this(default, default, default, default)
        {

        }

        public MilkProducts(string name, int price, double weight, DateTime date)
            : base(name, price, weight)
        {
            if (date == null)
                throw new ArgumentNullException();
            timeToExpire = date;
        }

        public override void ChangePrice(int percentage)
        {
            if (IsExpired())
            {
                percentage = percentage > 40 ? percentage - 30 : percentage;
            }
            Price = (int)(Price * (percentage / 100d));
        }

        public bool IsExpired()
        {
            return DateTime.Now > TimeToExpire;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(".Date to expire: {0}", TimeToExpire);
        }

        public override bool Equals(object obj)
        {
            return obj is MilkProducts product &&
                   Name == product.Name &&
                   Price == product.Price &&
                   Weight == product.Weight &&
                   timeToExpire == product.TimeToExpire;
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

