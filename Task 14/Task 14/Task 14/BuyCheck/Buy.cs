using System;
using System.Collections.Generic;
using Task_11.Storage;
using Task_14.Products.Interfaces;

namespace Task_11.BuyCheck
{
    public class Buy
    {
        public int ProductsAmount
        {
            get => allProducts.Count;
        }
        public int TotalPrice { get; private set; }

        private List<IProduct> allProducts;

        public Buy()
        {
            TotalPrice = 0;
            allProducts = new List<IProduct>();
        }

        public Buy(params IProduct[] products)
        {
            allProducts = new List<IProduct>();
            foreach (var item in products)
            {
                TotalPrice += item.Price;
                allProducts.Add(item);
            }
        }

        public IProduct this[int index]
        {
            get
            {
                if (index >= 0 && index < allProducts.Count)
                    return allProducts[index];
                throw new ArgumentException();
            }
        }

        public void AddItem(IProduct item)
        {
            if (item != null)
            {
                allProducts.Add(item);
                TotalPrice += item.Price;
            }
        }

        public void RemoveItem(IProduct item)
        {
            if (item != null && allProducts.Contains(item))
            {
                allProducts.Remove(item);
                TotalPrice -= item.Price;
            }
        }

        public IProduct GetProduct(int index)
        {
            if (index < allProducts.Count && index >= 0)
            {
                return allProducts[index];
            }
            throw new ArgumentException();
        }

        public override bool Equals(object? obj)
        {
            return obj is Buy buy &&
                   ProductsAmount == buy.ProductsAmount &&
                   TotalPrice == buy.TotalPrice &&
                   EqualityComparer<List<IProduct>>.Default.Equals(allProducts, buy.allProducts);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductsAmount, TotalPrice, allProducts);
        }
    }
}
