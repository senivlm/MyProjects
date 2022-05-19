using System;
using System.Collections.Generic;

namespace ProductProject
{
    public class Meat : Product, IExpirableProduct
	{
        private Category meatCategory;
		public Category MeatCategory {
            get 
            {
                return meatCategory;
            } 
        }
        private Species meatSpecies;
		public Species MeatSpecies { 
            get
            {
                return meatSpecies;
            } 
        }
        private DateTime timeToExpire;
        public DateTime TimeToExpire { 
            get
            {
                return timeToExpire;
            }
        }

        private Dictionary<Category, int> additionPercentage;

        public Meat() : this(default, default, default, default, default, default)
        {

        }

        public Meat(string name, int price, double weight, DateTime dateExpire,
			Category meatCategory, Species meatSpecies) : base(name, price, weight)
        {
			this.meatCategory = meatCategory;
			this.meatSpecies = meatSpecies;
			timeToExpire = dateExpire;

            additionPercentage = new Dictionary<Category, int>();
            additionPercentage[Category.HighSort1] = 25;
            additionPercentage[Category.Sort2] = 10;

            ChangePrice(100); // adjusting price depending on sort
        }

		public override void ChangePrice(int percentage)
		{
            percentage += additionPercentage[this.meatCategory];
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
            return base.ToString() + string.Format
				("\n Date to expire: {0}, meat category: {1}, meat species: {2}", TimeToExpire, MeatCategory, MeatSpecies);
        }

        public new void Parse(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException();
            }
            base.Parse(text);
            string[] arrayString = text.Split(' ');

            object objCategory;
            object objSpecies;
            if(Enum.TryParse(typeof(Category), arrayString[3], out objCategory) ||
                Enum.TryParse(typeof(Category), arrayString[4], out objSpecies) ||
                DateTime.TryParse(arrayString[5], out timeToExpire))
            {
                throw new ArgumentException();
            }
                
            meatCategory = (Category)objCategory;
            meatSpecies = (Species)objSpecies;
        }
    }
}

