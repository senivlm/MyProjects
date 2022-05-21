using System;
using System.Collections.Generic;

namespace ProductProject
{
    public class Buy
    {
        public int ProductsAmount { get; private set; }
        public int TotalPrice { get; private set; }
        public double TotalWeight { get; private set; }

        private List<Product> allProducts;

        public Buy()
        {
            ProductsAmount = 0;
            TotalPrice = 0;
            TotalWeight = 0;
            allProducts = new List<Product>();
        }

        public Buy(params Product[] products)
        {
            ProductsAmount = products.Length;
            allProducts = new List<Product>();
            foreach(var item in products)
            {
                TotalPrice += item.Price;
                TotalWeight += item.Weight;
                allProducts.Add(item);
            }
        }
        
        public void AddProduct(Product product)
        {
            if (product != null)
            {
                allProducts.Add(product);
                TotalPrice += product.Price;
                TotalWeight += product.Weight;
                ProductsAmount += 1;
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

        public Product this[int index]
        {
            get
            {
                if (index >= 0 && index < allProducts.Count)
                    return allProducts[index];
                throw new ArgumentException();
            }
        }
    }
}
