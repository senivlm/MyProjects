using Task_14.Enums;
using Task_14.Products.Instruments;

namespace Task_14.Shops_Fabrics_.InstrumentShop
{
    public class PlasticFactory : InstrumentFactory
    {
        public override Hammer GetHammer(Colors color)
        {
            return new Hammer("GameHammer", 0.5, 60, color);
        }

        public override Shovel GetShovel()
        {
            return new PlasticShovel("GameShovel", 0.6, 70, Colors.Yellow);
        }

        public override Trowel GetTrowel()
        {
            return new WoodenTrowel("GameTrowel", 0.6, 55);
        }
    }
}
