namespace Task_14.Products.Foods.MilkSubclasses
{
    public class Yogurt : Milk
    {
        public int FatPercent { get; private set; }

        public Yogurt(string? name, int price, double weight, int percentageFat, DateTime date) : base(name, price, weight, date)
        {
            FatPercent = percentageFat;
        }

        public override string ToString()
        {
            return "Chesee: " + base.ToString() + $", fat percentage: {FatPercent}" + string.Format(".Date to expire: {0}", TimeToExpire);
        }
    }
}

