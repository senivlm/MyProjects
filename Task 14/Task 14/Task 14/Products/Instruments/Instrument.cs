using Task_14.Enums;
using Task_14.Products.Interfaces;

namespace Task_14.Products.Instruments
{
    public abstract class Instrument : IInstrument
    {
        public string Name { get; }
        public double Weight { get; }
        public int Price { get; private set; }

        public Colors Color { get; }

        public Instrument(string name, double weight, int price, Colors color)
        {
            Name = name;
            Weight = weight;
            Price = price;
            Color = color;
        }

        public void ChangePrice(int percentage)
        {
            Price = (int)(Price * (percentage / 100f));
        }

        public override string ToString()
        {
            return String.Format($"{Name}, {Color} color, {Weight} Kg, {Price} UAH");
        }

        public abstract IInstrument Clone();
    }
}
