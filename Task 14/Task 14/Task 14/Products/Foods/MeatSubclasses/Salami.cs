using Task_11.Enums;

namespace Task_14.Products.Foods.MeatSubclasses
{
    public class Salami : Meat
    {
        public Salami(string? name, int price, double weight, DateTime dateExpire, Category meatCategory, Species meatSpecies) : base(name, price, weight, dateExpire, meatCategory, meatSpecies)
        {
        }

        public override string ToString()
        {
            return "Salami: " + base.ToString();
        }
    }
}

