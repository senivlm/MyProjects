using Task_11.Storage;
using Task_14.Products.Foods;
using Task_14.Products.Interfaces;
using Task_14.Enums;
using Task_14.Shops_Fabrics_.InstrumentShop;
using Task_14.Products.Instruments;
using Task_14.Products.Foods.SubclassesOfPizza;

class Program
{
	static void Main(string[] args)
	{
        //cеріалізація\десереалізація складу

        //xml cеріалізація
        var storage = Storage<IFood>.GetInstance();
        storage.AddItem(new OtherFood("apple", 50, 2), 1);
        storage.AddItem(new OtherFood("banana", 60, 1), 1);
        XmlSerializator.XmlSerialize<Storage<IFood>>(storage, @"D:\MyProjects\Task 14\Task 14\Task 14\Storage.xml");
        storage = XmlSerializator.XmlDeserialize<Storage<IFood>>(@"D:\MyProjects\Task 14\Task 14\Task 14\Storage.xml");
        foreach (var item in storage)
        {
            Console.WriteLine(item);
        }

        //бінарна серіалізація
        BinarySerializator.BinarySerialize(storage, @"D:\MyProjects\Task 14\Task 14\Task 14\BinaryStorage.txt");
        storage = BinarySerializator.BinaryDeserialize<Storage<IFood>>(@"D:\MyProjects\Task 14\Task 14\Task 14\BinaryStorage.txt");
        foreach (var item in storage)
        {
            Console.WriteLine(item);
        }
        //---------------------------------
        //використання патерну стратегія
        //узагальнена абстрактна фабрика приймає конкретну фабрику
        InstrumentFactory factory = new IronFactory();
        //змінна з узагальненим типом абстрактного класу інструменту приймає конкретний інстурмент
        Shovel instrument = factory.GetShovel();
        Console.WriteLine(instrument);
    }

    //Серіалізував дані для піцерії, щоб не було хардкоду.
    //Тобто піцерія буде брати меню з посторонього файлу
    static void AddMenu()
    {
        string a = @"D:\MyProjects\Task 14\Task 14\Task 14\PizzaRecepies1.xml";
        string b = @"D:\MyProjects\Task 14\Task 14\Task 14\PizzaRecepies2.xml";
        List<ItalianPizza> pizzas1 = new();
        pizzas1.Add(new ItalianPizza("Італійська піца", 180, 0.6d, PizzaTypes.Italian, new DateTime(2023, 10, 5),
                new OtherFood("Тісто", 10, 0.2d),
                new OtherFood("Cир", 30, 0.15d),
                new OtherFood("Шинка", 20, 0.1d),
                new OtherFood("Курка", 40, 0.15d))
                );
        pizzas1.Add(new ItalianPizza("Беконова", 180, 0.6d, PizzaTypes.Bacon, new DateTime(2023, 10, 5),
            new OtherFood("Тісто", 10, 0.2d),
            new OtherFood("Cир", 30, 0.15d),
            new OtherFood("Бекон", 20, 0.1d),
            new OtherFood("Курка", 40, 0.15d))
            );

        List<NYPizza> pizzas2 = new();
        pizzas2.Add(new NYPizza("Чилі піца", 180, 0.6d, PizzaTypes.ChiliPepper, new DateTime(2023, 10, 5),
                new OtherFood("Тісто", 10, 0.2d),
                new OtherFood("Cир", 30, 0.15d),
                new OtherFood("Чилі", 20, 0.1d),
                new OtherFood("Курка", 40, 0.15d))
                );
        pizzas2.Add(new NYPizza("Беконова", 180, 0.6d, PizzaTypes.Shrimp, new DateTime(2023, 10, 5),
            new OtherFood("Тісто", 10, 0.2d),
            new OtherFood("Cир", 30, 0.15d),
            new OtherFood("Бекон", 20, 0.1d),
            new OtherFood("Криветки", 40, 0.15d))
            );
        XmlSerializator.XmlSerialize<List<ItalianPizza>>(pizzas1, a);
        XmlSerializator.XmlSerialize<List<NYPizza>>(pizzas2, b);
    }
}