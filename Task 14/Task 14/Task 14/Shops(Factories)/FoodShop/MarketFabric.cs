using Task_14.Products.Interfaces;

namespace Task_14.Shops_Fabrics_.FoodShop
{
    public abstract class MarketFactory
    {
        public abstract IMilk GetMilk();
        public abstract IMeat GetMeat();
        public abstract IFood GetDrink();
        public abstract IFood GetChips();
    }
}
