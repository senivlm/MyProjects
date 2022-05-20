using System;
using System.Collections.Generic;

namespace ProductProject
{
    public class Storage
    {
        private List<Product> _products;
        protected List<Product> products
        {
            get
            {
                return _products;
            }
        }

        public Storage()
        {
            _products = new List<Product>();
        }

        public Storage(params Product[] products)
        {
            _products = new List<Product>();
            foreach(var item in products)
            {
                _products.Add(item);
            }
        }

        public Product this[int i]
        {
            get
            {
                if(i >= 0 && i < _products.Count)
                    return _products[i];
                throw new ArgumentException();
            }
        }

        public void AddItem(Product item)
        {
            if (item != null)
            {
                _products.Add(item);
            }
        }

        public bool TryToFindAllMeat()
        {
            bool isFound = false;
            foreach(var item in _products)
            {
                if(item is Meat)
                {
                    Console.WriteLine("Meat named {0} was found", item.Name);
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
                    Console.WriteLine("Meat named {0} was found", item.Name);
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

        public void ShowInfo()
        {
            for (int i = 0; i < _products.Count; i++)
            {
                Console.WriteLine("{0} grn, {1} kg, {2} name", _products[i].Price,
                    _products[i].Weight, _products[i].Name);
            }
        }
    }
}
