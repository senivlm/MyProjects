using Task_11.Enums;

namespace Task_14.Products.Foods.MeatSubclasses
{
    class Ribs : Meat
    {
        public Ribs(string? name, int price, double weight, DateTime dateExpire, Category meatCategory, Species meatSpecies) : base(name, price, weight, dateExpire, meatCategory, meatSpecies)
        {
        }

        public override string ToString()
        {
            return "Rib" + base.ToString();
        }
    }
}

