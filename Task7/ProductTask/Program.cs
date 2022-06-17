using System;
using System.IO;
using ProductProject;

class Program
{
	static void Main(string[] args)
	{
		try
		{
			Storage storage = new Storage();
			LogHandler<Product> logHandler = new LogHandler<Product>(@"D:\allprjcts\MyProjects\Task7\ProductTask\RegistLogs.txt");
			storage.AddItemsFromFile(@"D:\allprjcts\MyProjects\Task7\ProductTask\ProductList.txt", logHandler);
            Console.WriteLine(storage[1]); // object before change
			logHandler.GetLogObject(1).ChangePrice(70); // to change object from logs
            Console.WriteLine(storage[1]); // object after change
			
		}
		catch(FileNotFoundException ex)
        {
            Console.WriteLine(ex);
        }
		catch(Exception ex)
        {
            Console.WriteLine(ex);
        }
	}
}