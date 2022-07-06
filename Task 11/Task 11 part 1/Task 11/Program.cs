using Task_11.LogHandler;
using Task_11.Products;
using Task_11.Storage;

class Program
{
	static void Main(string[] args)
	{
		var storage = new Storage<Product>();
		// Вдале використання лямбди
		storage.ProductAvaliableEvent += a => Console.WriteLine($"({a}) is available!");
		SomeProduct someProduct = new SomeProduct("apple", 10, 10);
		SomeProduct someProduct1 = new SomeProduct("apple", 15, 10);
		storage.AddItem(someProduct);
		storage.AddItem(someProduct1);
	}
}
