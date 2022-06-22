using System;
using System.Collections.Generic;

namespace ProductProject
{
    public class Storage
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
            foreach(var item in _products)
            {
                if(item is Meat)
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
