using Task_14.Enums;
using Task_14.Products.Interfaces;

namespace Task_14.Products.Instruments
{
    public abstract class Shovel : Instrument
    {
        public Shovel(string name, double weight, int price, Colors color) : base(name, weight, price, color)
        {
        }
    }
}
