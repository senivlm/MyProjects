using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ProductProject;

class Program
{
	static void Main(string[] args)
	{
		try
		{
			Storage storage1 = new Storage();
			Storage storage2 = new Storage();
			LogHandler<Product> logHandler = new LogHandler<Product>(@"D:\allprjcts\MyProjects\Task8\Task8 part3\Task8 part3\RegistLogs.txt");
			storage1.AddItemsFromFile(@"D:\allprjcts\MyProjects\Task8\Task8 part3\Task8 part3\productList.txt", logHandler);
			storage2.AddItemsFromFile(@"D:\allprjcts\MyProjects\Task8\Task8 part3\Task8 part3\productList2.txt", logHandler);
			using (var sr = new StreamWriter(@"D:\allprjcts\MyProjects\Task8\Task8 part3\Task8 part3\Result.txt", true))
			{
				IEnumerable<Product> collection = storage1.MutualElementsInCompareTo(storage2);
				sr.WriteLine("Cпільні продукти: ");
				foreach(var item in collection)
                {
                    sr.WriteLine(item);
                }
				sr.WriteLine("--------------------");
				collection = storage1.NotRepetitiveElementsInCompareTo(storage2);
				sr.WriteLine("Продукти які не повторюються: ");
				foreach (var item in collection)
				{
					sr.WriteLine(item);
				}
				sr.WriteLine("--------------------");
				collection = storage1.UniqueMutualElementsInCompareTo(storage2);
				sr.WriteLine("Унікальні спільні продукти(без повторів): ");
                foreach (var item in collection)
                {
					sr.WriteLine(item);
				}
				sr.WriteLine("--------------------");
			}

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