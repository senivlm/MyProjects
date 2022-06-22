namespace Task9
{
    static class PriceKurantHandler
    {
        public static void PrintPriceKurant(Menu menu, PriceKurant priceKurant, Currencies current, string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException("File not found");
            }
            try
            {
                using (var sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(new string('-', 8));
                    foreach (var dish in menu.GetDishes())
                    {
                        sw.WriteLine($"{dish.Name}");
                        foreach (var ingridient in dish.GetIngridients)
                        {
                            double price;
                            priceKurant.TryGetProductPrice(ingridient, out price);
                            sw.WriteLine($"{ingridient} - {Math.Round(CurrencyExchange.ConvertCurrency(price, 0, current), 2)} {current}");
                        }
                        sw.WriteLine($" = {Math.Round(CurrencyExchange.ConvertCurrency(dish.GetSumPrice(priceKurant), 0, current), 2)} {current}");
                        sw.WriteLine();
                    }
                    sw.WriteLine(new string('-', 8));
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}