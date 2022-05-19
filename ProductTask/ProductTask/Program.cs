using System;
using ProductProject;

class Program
{
	static void Main(string[] args)
	{
		MilkProducts milk = new MilkProducts("milk", 50, 0.5, new DateTime(2022, 1, 15));
		milk.Parse("milk5 70 1 2023,1,15");
		Console.WriteLine(milk);
		Console.WriteLine("Enter the name");
		string name = Console.ReadLine();
		Console.WriteLine("Enter the price");
		int price = int.Parse(Console.ReadLine());
		Console.WriteLine("Enter the weight");
		double weight = double.Parse(Console.ReadLine());
		var product = new Product(name, price, weight);
		Console.WriteLine(product);
		var meat = new Meat("bacon", 100, 1.2, new DateTime(2012, 1, 1), Category.HighSort1, Species.chicken);
        Console.WriteLine(meat);
	}
}