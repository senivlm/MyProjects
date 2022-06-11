using System;
using System.Collections.Generic;
using System.IO;

namespace ProductProject
{
    public class Storage : IBusketWithProducts
    {
        private List<Product> _products;

        public int ProductAmount
        {
            get => _products.Count;
        }

        public Storage()
        {
            _products = new List<Product>();
        }

        public Storage(params Product[] products)
        {
            _products = new List<Product>();
            foreach (var item in products)
            {
                _products.Add(item);
            }
        }

        public Product this[int i]
        {
            get
            {
                if (i >= 0 && i < _products.Count)
                    return _products[i];
                throw new ArgumentException();
            }
        }

        public void AddItemsFromFile(string path, LogHandler<Product> logHandler)
        {
            for (int i = 0; Path.GetFileName(path) == null && i < 3; i++)
            {
                Console.WriteLine("Try to enter the path again");
                path = Console.ReadLine();
            }
            using (var sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string name = "";
                    int price;
                    double weight;
                    bool occuredProblem = false;
                    string[] text = sr.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
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
                    if (!occuredProblem)
                    {
                        var _product = new SomeProduct(name, price, weight);
                        logHandler.AddCreatedObjectLog(_product);
                        _products.Add(_product);
                    }
                }
            }
        }

        public void AddItem(Product item)
        {
            if (item != null)
            {
                _products.Add(item);
            }
        }

        public void RemoveItem(Product item)
        {
            if (item != null)
            {
                _products.Remove(item);
            }
        }

        public bool TryToFindAllMeat()
        {
            bool isFound = false;
            foreach (var item in _products)
            {
                if (item is Meat)
                {
                    isFound = true;
                }
            }
            return isFound;
        }

        public bool TryToFindAllMilkProduct()
        {
            bool isFound = false;
            foreach (var item in _products)
            {
                if (item is MilkProducts)
                {
                    isFound = true;
                }
            }
            return isFound;
        }

        public void ChangePriceOfAllProducts(int percentage)
        {
            foreach (var item in _products)
            {
                item.ChangePrice(percentage);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Storage storage &&
                   EqualityComparer<List<Product>>.Default.Equals(_products, storage._products);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_products);
        }
    }
}
