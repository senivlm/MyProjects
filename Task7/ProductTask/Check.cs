using System;
using System.Collections.Generic;
using System.Text;

namespace ProductProject
{
    public static class Check
    {
        public static void ShowInfo(Buy buy)
        {
            for (int i = 0; i < buy.ProductsAmount; i++)
            {
                Console.WriteLine("{0} grn, {1} kg, {2} name", buy[i].Price,
                    buy[i].Weight, buy[i].Name);
            }
            Console.WriteLine("Total price: {0}", buy.TotalPrice);
        }
    }
}
