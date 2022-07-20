﻿using Task_14.Products.Interfaces;

namespace Task_14.Products.Foods
{
    class SoftDrink : Food
    {
        public SoftDrink(string? name, int price, double weight) : base(name, price, weight)
        {
        }

        public override IFood Clone()
        {
            return new Water(Name, Price, Weight);
        }

        public override string ToString()
        {
            return "Soft Drink: " + base.ToString();
        }
    }
}

