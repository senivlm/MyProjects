namespace Task_14.Products.Foods.MilkSubclasses
{
    public class Cheese : Milk
    {
        public Cheese(string? name, int price, double weight, DateTime date) : base(name, price, weight, date)
        {
        }

        public override string ToString()
        {
            return "Chesee: " + base.ToString() + string.Format(".Date to expire: {0}", TimeToExpire);
        }
    }
}

