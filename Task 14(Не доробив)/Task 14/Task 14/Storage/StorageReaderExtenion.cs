using Task_11.LogHandler;
using Task_14.Products.Interfaces;
using Task_11.Enums;
using Task_14.Products.Foods;

namespace Task_11.Storage
{
    static class StorageReaderExtenion
    {
        public static void AddItemsFromFile<T, G>(this T storage, string? path, LogHandler<IProduct> logHandler)
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
                    string[] words = sr.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (words[0] != null)
                    {
                        name = char.ToUpper(words[0][0]) + words[0][1..words[0].Length];
                    }
                    else
                    {
                        logHandler.AddErorrLog("Wrong format for name ");
                    }
                    if (!int.TryParse(words[1], out price))
                    {
                        logHandler.AddErorrLog("Wrong format for price ");
                        occuredProblem = true;
                    }
                    if (!double.TryParse(words[2], out weight))
                    {
                        logHandler.AddErorrLog("Wrong format for weight ");
                        occuredProblem = true;
                    }
                    if (words.Length == 6 && !occuredProblem)
                    {
                        Species species = default;
                        Category category = default;
                        DateTime timeExpire;
                        if (Enum.TryParse(typeof(Species), words[3], out object? temp))
                        {
                            if (temp is Species specieTemp)
                                species = specieTemp;
                        }
                        else
                        {
                            logHandler.AddErorrLog("Wrong format for species ");
                            occuredProblem = true;
                        }
                        if (Enum.TryParse(typeof(Category), words[4], out temp))
                        {
                            if (temp is Category categTemp)
                                category = categTemp;
                        }
                        else
                        {
                            logHandler.AddErorrLog("Wrong format for category ");
                            occuredProblem = true;
                        }
                        if (!DateTime.TryParse(words[5], out timeExpire))
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
                    else if (words.Length == 4 && !occuredProblem)
                    {
                        DateTime timeExpire;
                        if (!DateTime.TryParse(words[3], out timeExpire))
                        {
                            logHandler.AddErorrLog("Wrong format for time ");
                            occuredProblem = true;
                        }
                        if (!occuredProblem)
                        {
                            var _product = new Milk(name, price, weight, timeExpire);
                            logHandler.AddCreatedObjectLog(_product);
                            storage.AddItem(_product);
                        }
                    }
                    else if (!occuredProblem)
                    {
                        var _product = new OtherFood(name, price, weight);
                        logHandler.AddCreatedObjectLog(_product);
                        storage.AddItem(_product);
                    }
                }
            }
        }
    }
}