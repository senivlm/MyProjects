using Task_14.Enums;
using Task_14.Products.Instruments;

namespace Task_14.Shops_Fabrics_.InstrumentShop
{
    public class IronFactory : InstrumentFactory
    {
        public override Hammer GetHammer(Colors color)
        {
            return new Hammer("HammerM", 2, 190, color);
        }

        public override Shovel GetShovel()
        {
            return new IronShovel("IronShovel", 5, 550);
        }

        public override Trowel GetTrowel()
        {
            return new IronTrowel("IronTrowel", 1, 220);
        }
    }
}
