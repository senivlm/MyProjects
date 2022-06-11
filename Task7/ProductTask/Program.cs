using System;
using ProductProject;

class Program
{
	static void Main(string[] args)
	{
		try
		{
			Storage storage = new Storage();
			LogHandler<Product> logHandler = new LogHandler<Product>(@"D:\allprjcts\MyProjects\Task7\ProductTask\RegistLogs.txt");
			storage.AddItemsFromFile(@"D:\allprjcts\MyProjects\Task7\ProductTask\TextFile.txt", logHandler);
            Console.WriteLine(storage[1]); // object before change
			logHandler.GetLogObject(1).ChangePrice(70);
            Console.WriteLine(storage[1]); // object after change
			
		}
		catch(Exception ex)
        {
            Console.WriteLine(ex);
        }
	}
}