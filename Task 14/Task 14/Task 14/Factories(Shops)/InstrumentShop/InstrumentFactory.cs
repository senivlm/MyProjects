using Task_14.Enums;
using Task_14.Factories;
using Task_14.Factories.PatternStratehy;
using Task_14.Products.Instruments;

namespace Task_14.Shops_Fabrics_.InstrumentShop
{
    public abstract class InstrumentFactory : Shop
    {
        protected InstrumentFactory(IDialogueStrategy dialogue) : base(dialogue)
        {
        }

        [NameLabel("Buy a shovel")]
        public abstract Shovel GetShovel();
        [NameLabel("Buy a trowel")]
        public abstract Trowel GetTrowel();
        [NameLabel("Buy a hammer")]
        public abstract Hammer GetHammer(Colors color);
    }
}
