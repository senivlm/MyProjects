using Task_14.Enums;

namespace Task_14.Products.Instruments
{
    public abstract class Trowel : Instrument
    {
        public Trowel(string name, double weight, int price, Colors color) : base(name, weight, price, color)
        {
        }
    }
}
