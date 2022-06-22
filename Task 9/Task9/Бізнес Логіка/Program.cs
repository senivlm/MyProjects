namespace Task9
{
    class Program
    {
        public static void Main()
        {
            //зчитування даних
            var menu = MenuReader.GetMenuListFromFile(@"D:\MyProjects\Task9\Task9\Menu.txt");
            var priceKurant = MenuReader.GetPriceKurantFromFile(@"D:\MyProjects\Task9\Task9\Prices.txt");
            // прив*язання до події відповідного методу, коли ми не можемо зчитати прайскурант по назві
            priceKurant.PriceWasNotFound += MenuReader.TryToEnterPriceConsole;

            CurrencyExchange.ReadExchangeRateFromFile(@"D:\MyProjects\Task9\Task9\Course.txt");

            Console.WriteLine("Введіть валюту ");
            string currency = Console.ReadLine();
            object res;
            if(Enum.TryParse(typeof(Currencies), currency, out res))
            {
                PriceKurantHandler.PrintPriceKurant(menu, priceKurant, (Currencies)res, @"D:\MyProjects\Task9\Task9\result.txt");
            }
            else
            {
                return;
            }

            //Вивід для різних валют:
            //PriceKurantHandler.PrintPriceKurant(menu, priceKurant, Currencies.USD, @"D:\MyProjects\Task9\Task9\result.txt");
            PriceKurantHandler.PrintPriceKurant(menu, priceKurant, Currencies.UAH, @"D:\MyProjects\Task9\Task9\result.txt");
            PriceKurantHandler.PrintPriceKurant(menu, priceKurant, Currencies.EURO, @"D:\MyProjects\Task9\Task9\result.txt");
        }
    }
}