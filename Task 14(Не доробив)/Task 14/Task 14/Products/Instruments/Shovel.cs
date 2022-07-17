using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_14.Enums;
using Task_14.Products.Interfaces;

namespace Task_14.Products.Instruments
{
    public class Shovel : Instrument
    {
        public Shovel(string name, double weight, int price, Colors color) : base(name, weight, price, color)
        {
        }

        public override IInstrument Clone()
        {
            return new Shovel(Name, Weight, Price, Color);
        }
    }
}
