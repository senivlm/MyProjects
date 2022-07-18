using Task_11.Enums;
using Task_14.Products.Foods;
using Task_14.Products.Foods.MeatSubclasses;
using Task_14.Products.Foods.MilkSubclasses;
using Task_14.Products.Interfaces;

namespace Task_14.Shops_Fabrics_.FoodShop
{
    public class MarketOne : MarketFactory
    {
        public override IFood GetChips()
        {
            return new OtherFood("Crisps", 25, 0.6);
        }

        public override IFood GetDrink()
        {
            return new OtherFood("lWater", 15, 2);
        }

        public override IMeat GetMeat()
        {
            return new Salami("MuttonSalami", 85, 0.9, new DateTime(2022, 12, 5), Category.Sort2, Species.mutton);
        }

        public override IMilk GetMilk()
        {
            return new Yogurt("Yougurt", 35, 1, 30, new DateTime(2022, 12, 5));
        }
    }
}
