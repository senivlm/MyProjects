using Task_14.Enums;
using Task_14.Products.Interfaces;

namespace Task_14.Products.Instruments
{
    public class Hammer : Instrument
    {
        public Hammer(string name, double weight, int price, Colors color) : base(name, weight, price, color)
        {
        }

        public override IInstrument Clone()
        {
            return new Hammer(Name, Weight, Price, Color);
        }
    }
}
