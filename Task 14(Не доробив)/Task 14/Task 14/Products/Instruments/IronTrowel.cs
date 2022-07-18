using Task_14.Enums;
using Task_14.Products.Interfaces;

namespace Task_14.Products.Instruments
{
    public class IronTrowel : Trowel
    {
        public IronTrowel(string name, double weight, int price) : base(name, weight, price, Colors.White)
        {
        }

        public override IInstrument Clone()
        {
            return new WoodenTrowel(Name, Weight, Price);
        }
    }
}
