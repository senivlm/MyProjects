namespace Task9
{
    static class MenuReader
    {
        public static Menu GetMenuListFromFile(string pathToMenu)
        {
            if (!File.Exists(pathToMenu))
            {
                throw new ArgumentException("File not found");
            }
            var menu = new List<Dish>();
            try
            {
                using (var sr = new StreamReader(pathToMenu))
                {
                    while (!sr.EndOfStream)
                    {
                        string? name = sr.ReadLine();
                        if (name == null && name == string.Empty)
                        {
                            break;
                        }
                        var dish = new Dish(name);
                        string? ingridientData = "";
                        while ((ingridientData = sr.ReadLine()) != string.Empty && ingridientData != null)
                        {
                            var ingridient = ingridientData.Split(',', StringSplitOptions.RemoveEmptyEntries);
                            dish.AddIngridient(ingridient[0], double.Parse(ingridient[1]));
                        }
                        menu.Add(dish);
                    }
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
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
            return new Menu(menu);
        }

        public static PriceKurant GetPriceKurantFromFile(string pathToPrices)
        {
            if (!File.Exists(pathToPrices))
            {
                throw new ArgumentException("File not found");
            }
            var priceKurant = new PriceKurant();
            try
            {
                using (var sr = new StreamReader(pathToPrices))
                {
                    while (!sr.EndOfStream)
                    {
                        var priceInfo = sr.ReadLine()?.Split('-', StringSplitOptions.RemoveEmptyEntries);
                        string? name = priceInfo[0];
                        double price = 0;
                        if (!double.TryParse(priceInfo[1], out price))
                        {
                            throw new FormatException("Wrong price format");
                        }
                        priceKurant.AddProduct(name, price);
                    }
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
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
            return priceKurant;
        }
    }
}