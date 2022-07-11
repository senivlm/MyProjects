using Task_11.LogHandler;
using Task_11.Products;
using Task_11.Enums;

namespace Task_11.Storage
{
    static class StorageReaderExtenion
    {
        public static void AddItemsFromFile<T, G>(this T storage, string path, LogHandler<Product> logHandler)
            where T : IStoragable, IStorage<G>
            where G : IProduct
        {
            for (int i = 0; Path.GetFileName(path) == null && i < 3; i++)
            {
                Console.WriteLine("Try to enter the path again");
                path = Console.ReadLine();
            }
            using (StreamReader sr = new(path))
            {
                while (!sr.EndOfStream)
                {
                    string name = "";
                    int price;
                    double weight;
                    bool occuredProblem = false;
                    string?[] text = sr.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (text[0] != null)
                    {
                        name = char.ToUpper(text[0][0]) + text[0][1..text[0].Length];
                    }
                    else
                    {
                        logHandler.AddErorrLog("Wrong format for name ");
                    }
                    if (!int.TryParse(text[1], out price))
                    {
                        logHandler.AddErorrLog("Wrong format for price ");
                        occuredProblem = true;
                    }
                    if (!double.TryParse(text[2], out weight))
                    {
                        logHandler.AddErorrLog("Wrong format for weight ");
                        occuredProblem = true;
                    }
                    if (text.Length == 6 && !occuredProblem)
                    {
                        Species species = default;
                        Category category = default;
                        DateTime timeExpire;
                        object? temp;
                        if (Enum.TryParse(typeof(Species), text[3], out temp))
                        {
                            species = (Species)temp;
                        }
                        else
                        {
                            logHandler.AddErorrLog("Wrong format for species ");
                            occuredProblem = true;
                        }
                        if (Enum.TryParse(typeof(Category), text[4], out temp))
                        {
                            category = (Category)temp;
                        }
                        else
                        {
                            logHandler.AddErorrLog("Wrong format for category ");
                            occuredProblem = true;
                        }
                        if (!DateTime.TryParse(text[5], out timeExpire))
                        {
                            logHandler.AddErorrLog("Wrong format for time ");
                            occuredProblem = true;
                        }
                        if (!occuredProblem)
                        {
                            var _product = new Meat(name, price, weight, timeExpire, category, species);
                            logHandler.AddCreatedObjectLog(_product);
                            storage.AddItem(_product);
                        }
                    }
                    else if (text.Length == 4 && !occuredProblem)
                    {
                        DateTime timeExpire;
                        if (!DateTime.TryParse(text[3], out timeExpire))
                        {
                            logHandler.AddErorrLog("Wrong format for time ");
                            occuredProblem = true;
                        }
                        if (!occuredProblem)
                        {
                            var _product = new MilkProduct(name, price, weight, timeExpire);
                            logHandler.AddCreatedObjectLog(_product);
                            storage.AddItem(_product);
                        }
                    }
                    else if (!occuredProblem)
                    {
                        var _product = new SomeProduct(name, price, weight);
                        logHandler.AddCreatedObjectLog(_product);
                        storage.AddItem(_product);
                    }
                }
            }
        }
    }
}