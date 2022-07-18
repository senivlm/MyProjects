using Task_14.Enums;
using Task_14.Products.Interfaces;

namespace Task_14.Products.Instruments
{
    public class PlasticShovel : Instrument
    {
        public PlasticShovel(string name, double weight, int price, Colors color) : base(name, weight, price, color)
        {
        }

        public override IInstrument Clone()
        {
            return new PlasticShovel(Name, Weight, Price, Color);
        }
    }
}
