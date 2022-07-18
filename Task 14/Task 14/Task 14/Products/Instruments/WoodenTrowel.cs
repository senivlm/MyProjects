using Task_14.Enums;
using Task_14.Products.Interfaces;

namespace Task_14.Products.Instruments
{
    public class WoodenTrowel : Trowel
    {
        public WoodenTrowel(string name, double weight, int price) : base(name, weight, price, Colors.Brown)
        {
        }

        public override IInstrument Clone()
        {
            return new WoodenTrowel(Name, Weight, Price);
        }
    }
}
