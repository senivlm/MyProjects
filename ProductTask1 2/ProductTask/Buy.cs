using System;
using System.Collections.Generic;

namespace ProductProject
{
    public class Buy
    {
        public int ProductsAmount 
        { 
            get => allProducts.Count;
        }
        public int TotalPrice { get; private set; }
        public double TotalWeight { get; private set; }

        private List<Product> allProducts;

        public Buy()
        {
            TotalPrice = 0;
            TotalWeight = 0;
            allProducts = new List<Product>();
        }

        public Buy(params Product[] products)
        {
            allProducts = new List<Product>();
            foreach(var item in products)
            {
                TotalPrice += item.Price;
                TotalWeight += item.Weight;
                allProducts.Add(item);
            }
        }

        public Product this[int index]
        {
            get
            {
                if (index >= 0 && index < allProducts.Count)
                    return allProducts[index];
                throw new ArgumentException();
            }
        }

        public void AddProduct(Product product)
        {
            if (product != null)
            {
                allProducts.Add(product);
                TotalPrice += product.Price;
                TotalWeight += product.Weight;
            }
        }

        public void RemoveProduct(Product product)
        {
            if (product != null && allProducts.Contains(product))
            {
                allProducts.Remove(product);
                TotalPrice -= product.Price;
                TotalWeight -= product.Weight;
            }
        }

        public Product GetProduct(int index)
        {
            if(index < allProducts.Count && index >= 0)
            {
                return allProducts[index];
            }
            throw new ArgumentException();
        }

        public override bool Equals(object obj)
        {
            return obj is Buy buy &&
                   ProductsAmount == buy.ProductsAmount &&
                   TotalPrice == buy.TotalPrice &&
                   TotalWeight == buy.TotalWeight &&
                   EqualityComparer<List<Product>>.Default.Equals(allProducts, buy.allProducts);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductsAmount, TotalPrice, TotalWeight, allProducts);
        }
    }
}
