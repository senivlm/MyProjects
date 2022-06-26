using System;

namespace Task_11.Products
{
    public class MilkProduct : Product, IExpirableProduct
    {
        private DateTime timeToExpire;
        public DateTime TimeToExpire
        {
            get
            {
                return timeToExpire;
            }
        }

        public MilkProduct() : this(default, default, default, default)
        {

        }

        public MilkProduct(MilkProduct? milkProduct) : base(milkProduct)
        {
            if (milkProduct == null)
                return;
            timeToExpire = milkProduct.timeToExpire;
        }

        public MilkProduct(string? name, int price, double weight, DateTime date)
            : base(name, price, weight)
        {
            timeToExpire = date;
        }

        public override Product Clone()
        {
            return new MilkProduct(this);
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
            return obj is MilkProduct product &&
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

