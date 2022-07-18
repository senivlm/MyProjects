using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_14.Enums;

namespace Task_14.Products.Instruments
{
    public abstract class Shovel : Instrument
    {
        public Shovel(string name, double weight, int price, Colors color) : base(name, weight, price, color)
        {
        }
    }
}
