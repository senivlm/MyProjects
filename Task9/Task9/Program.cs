namespace Task9
{
    class Program
    {
        public static void Main()
        {
            //зчитування даних
            var menu = MenuReader.GetMenuListFromFile(@"D:\MyProjects\Task9\Task9\Menu.txt");
            var priceKurant = MenuReader.GetPriceKurantFromFile(@"D:\MyProjects\Task9\Task9\Prices.txt");
            // прив*язання до події коли ми не можемо зчитати прайскурант відповідної функції
            priceKurant.PriceWasNotFound += PriceKurantHandler.TryToEnterPriceConsole;

            CurrencyExchange.ReadExchangeRateFromFile(@"D:\MyProjects\Task9\Task9\Course.txt");

            //Вивід для різних валют:
            PriceKurantHandler.PrintPriceKurant(menu, priceKurant, Currencies.USD, @"D:\MyProjects\Task9\Task9\result.txt");
            PriceKurantHandler.PrintPriceKurant(menu, priceKurant, Currencies.UAH, @"D:\MyProjects\Task9\Task9\result.txt");
            PriceKurantHandler.PrintPriceKurant(menu, priceKurant, Currencies.EURO, @"D:\MyProjects\Task9\Task9\result.txt");
        }
    }
}