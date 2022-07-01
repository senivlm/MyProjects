using Task_11.LogHandler;
using Task_11.Products;
using Task_11.Storage;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		var storage = new Storage<Product>();
		storage.ProductAvaliableEvent += prod => Console.WriteLine($"({prod}) is available!");
		storage.ProductIsExpiredEvent += prod =>
		{
			using(var sw = new StreamWriter(@"D:\MyProjects\Task 12\Task 12 part 1\Task 12 part 1\GarbageList.txt", true))
            {
				sw.WriteLine($"{prod} is expired. It was thrown");
            }
		};
		var someProduct1 = new SomeProduct("apple", 10, 1);
		var someProduct2 = new SomeProduct("banana", 10, 2);
		var someProduct3 = new SomeProduct("apple", 15, 1);
		var expiredProduct = new MilkProduct("chicken", 100, 2, new DateTime(2008,4,15));
		storage.AddItem(someProduct1);
		storage.AddItem(someProduct2);
		storage.AddItem(someProduct3);
		storage.AddItem(expiredProduct);

		var products = storage.FindWithNameAndValue("Price", 10);
        foreach (var item in products)
        {
            Console.WriteLine(item);
        }
	}
}