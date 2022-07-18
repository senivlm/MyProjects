using Task_14.Enums;
using Task_14.Products.Instruments;

namespace Task_14.Shops_Fabrics_.InstrumentShop
{
    public abstract class InstrumentFactory
    {
        public abstract Shovel GetShovel();
        public abstract Trowel GetTrowel();
        public abstract Hammer GetHammer(Colors color);
    }
}
