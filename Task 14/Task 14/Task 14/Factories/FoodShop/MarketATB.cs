using System.Reflection;
using Task_11.Enums;
using Task_14.Factories.PatternStratehy;
using Task_14.Products.Foods;
using Task_14.Products.Foods.MilkSubclasses;
using Task_14.Products.Interfaces;

namespace Task_14.Shops_Fabrics_.FoodShop
{
    public class MarketATB : MarketFactory
    {
        public MarketATB(IDialogueStrategy dialogue) : base(dialogue)
        {
        }

        public override IFood GetChips()
        {
            return new OtherFood("ChipsLays", 40, 0.7);
        }

        public override IFood GetDrink()
        {
            return new OtherFood("MineralWater", 19, 1.5);
        }

        public override IMeat GetMeat()
        {
            return new Meat("Chicken", 110, 0.9, new DateTime(2022, 12, 5), Category.HighSort1, Species.chicken);
        }

        public override IMilk GetMilk()
        {
            return new Cheese("Milky", 40, 1, new DateTime(2022, 12, 5));
        }
    }
}

