using Task_14.Enums;
using Task_14.Products.Interfaces;

namespace Task_14.Products.Instruments
{
    public class IronShovel : Shovel
    {
        public IronShovel(string name, double weight, int price) : base(name, weight, price, Colors.White)
        {
        }

        public override IInstrument Clone()
        {
            return new IronShovel(Name, Weight, Price);
        }
    }
}
