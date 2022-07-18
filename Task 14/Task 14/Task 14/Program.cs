using Task_11.LogHandler;
using Task_11.Storage;
using System.IO;
using Task_14.Products.Foods;
using Task_14.Products.Interfaces;
using Task_14.Enums;

class Program
{
	static void Main(string[] args)
	{
        //cеріалізація\десереалізація складу
        var storage = Storage<IFood>.GetInstance();
        storage.AddItem(new OtherFood("apple", 50, 2), 1);
        storage.AddItem(new OtherFood("banana", 60, 1), 1);
        DataSerializator.XmlSerialize<Storage<IFood>>(storage, @"D:\MyProjects\Task 14\Task 14\Task 14\Storage.xml");
        storage = DataSerializator.XmlDeserialize<Storage<IFood>>(@"D:\MyProjects\Task 14\Task 14\Task 14\Storage.xml");
        foreach (var item in storage)
        {
            Console.WriteLine(item);
        }

        DataSerializator.BinarySerialize(storage, @"D:\MyProjects\Task 14\Task 14\Task 14\BinaryStorage.txt");
        storage = DataSerializator.BinaryDeserialize<Storage<IFood>>(@"D:\MyProjects\Task 14\Task 14\Task 14\BinaryStorage.txt");
        foreach (var item in storage)
        {
            Console.WriteLine(item);
        }
    }
    //Серіалізував дані для піцерії, щоб не було хардкоду.
    //Тобто піцерія буде брати меню з посторонього файлу
    static void AddMenu()
    {
        string a = @"D:\MyProjects\Task 14\Task 14\Task 14\PizzaRecepies1.xml";
        string b = @"D:\MyProjects\Task 14\Task 14\Task 14\PizzaRecepies2.xml";
        List<Pizza> pizzas1 = new List<Pizza>();
        pizzas1.Add(new Pizza("Італійська піца", 180, 0.6d, PizzaTypes.Italian, new DateTime(2023, 10, 5),
                new OtherFood("Тісто", 10, 0.2d),
                new OtherFood("Cир", 30, 0.15d),
                new OtherFood("Шинка", 20, 0.1d),
                new OtherFood("Курка", 40, 0.15d))
                );
        pizzas1.Add(new Pizza("Беконова", 180, 0.6d, PizzaTypes.Bacon, new DateTime(2023, 10, 5),
            new OtherFood("Тісто", 10, 0.2d),
            new OtherFood("Cир", 30, 0.15d),
            new OtherFood("Бекон", 20, 0.1d),
            new OtherFood("Курка", 40, 0.15d))
            );

        List<Pizza> pizzas2 = new List<Pizza>();
        pizzas2.Add(new Pizza("Чилі піца", 180, 0.6d, PizzaTypes.ChiliPepper, new DateTime(2023, 10, 5),
                new OtherFood("Тісто", 10, 0.2d),
                new OtherFood("Cир", 30, 0.15d),
                new OtherFood("Чилі", 20, 0.1d),
                new OtherFood("Курка", 40, 0.15d))
                );
        pizzas2.Add(new Pizza("Беконова", 180, 0.6d, PizzaTypes.Shrimp, new DateTime(2023, 10, 5),
            new OtherFood("Тісто", 10, 0.2d),
            new OtherFood("Cир", 30, 0.15d),
            new OtherFood("Бекон", 20, 0.1d),
            new OtherFood("Криветки", 40, 0.15d))
            );
        DataSerializator.XmlSerialize<List<Pizza>>(pizzas1, a);
        DataSerializator.XmlSerialize<List<Pizza>>(pizzas2, b);
    }
}