using System;
using System.Collections.Generic;
using Task_11.Enums;
using Task_14.Products.Interfaces;

namespace Task_14.Products.Foods
{
    [Serializable]
    public class Meat : Food, IMeat
    {
        private Category meatCategory;
        public Category MeatCategory
        {
            get
            {
                return meatCategory;
            }
        }
        private Species meatSpecies;
        public Species MeatSpecies
        {
            get
            {
                return meatSpecies;
            }
        }
        private DateTime timeToExpire;
        public DateTime TimeToExpire
        {
            get
            {
                return timeToExpire;
            }
        }

        private Dictionary<Category, int> additionPercentage = new();

        public Meat() : this(default, default, default, default, default, default)
        {

        }

        public Meat(Meat meat) : base(meat)
        {
            if (meat == null)
                return;
            meatCategory = meat.MeatCategory;
            meatSpecies = meat.MeatSpecies;
            timeToExpire = meat.timeToExpire;
            setUpMarkup();
        }

        public Meat(string? name, int price, double weight, DateTime dateExpire,
            Category meatCategory, Species meatSpecies) : base(name, price, weight)
        {
            this.meatCategory = meatCategory;
            this.meatSpecies = meatSpecies;
            timeToExpire = dateExpire;
            setUpMarkup();
            ChangePrice(100); // врегулювання ціни в залежності від сорту
        }

        protected void setUpMarkup(int high = 25, int medium = 10)
        {
            additionPercentage[Category.HighSort1] = high;
            additionPercentage[Category.Sort2] = medium;
        }

        public override Food Clone()
        {
            return new Meat(this);
        }

        public bool IsExpired() => DateTime.Now > TimeToExpire;

        public override void ChangePrice(int percentage)
        {
            percentage += additionPercentage[meatCategory];
            if (IsExpired())
            {
                percentage = percentage > 40 ? percentage - 30 : percentage;
            }
            Price = (int)(Price * (percentage / 100d));
        }

        public override string ToString()
        {
            return base.ToString() + string.Format
                ("\n Date to expire: {0}, meat category: {1}, meat species: {2}", TimeToExpire, MeatCategory, MeatSpecies);
        }

        public override bool Equals(object? obj)
        {
            return obj is Meat product &&
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

            object? objCategory;
            object? objSpecies;
            if (Enum.TryParse(typeof(Category), arrayString[3], out objCategory) ||
                Enum.TryParse(typeof(Category), arrayString[4], out objSpecies) ||
                DateTime.TryParse(arrayString[5], out timeToExpire))
            {
                throw new ArgumentException();
            }

            if(objCategory is Category categoryTemp)
                meatCategory = categoryTemp;
            if (objCategory is Species specieTemp)
                meatSpecies = specieTemp;
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
            hash.Add(meatCategory);
            hash.Add(MeatCategory);
            hash.Add(meatSpecies);
            hash.Add(MeatSpecies);
            hash.Add(timeToExpire);
            hash.Add(TimeToExpire);
            return hash.ToHashCode();
        }
    }
}

