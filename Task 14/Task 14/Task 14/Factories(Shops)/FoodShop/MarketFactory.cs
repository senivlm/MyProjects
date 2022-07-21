using Task_14.Factories;
using Task_14.Factories.PatternStratehy;
using Task_14.Products.Interfaces;

namespace Task_14.Shops_Fabrics_.FoodShop
{
    public abstract class MarketFactory : Shop
    {
        public MarketFactory(IDialogueStrategy dialogue) : base(dialogue)
        {
        }

        [NameLabel("Buy milk")]
        public abstract IMilk GetMilk();
        [NameLabel("Buy meat")]
        public abstract IMeat GetMeat();
        [NameLabel("Buy drink")]
        public abstract IFood GetDrink();
        [NameLabel("Buy crisps")]
        public abstract IFood GetChips();
    }
}
