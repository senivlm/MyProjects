namespace Task9
{
    class PriceKurant
    {
        private Dictionary<string, double> productPrice;
        public event Func<string, PriceKurant, bool> PriceWasNotFound;
        public PriceKurant()
        {
            productPrice = new();
        }

        public PriceKurant(Dictionary<string, double> productPrice) : this()
        {
            this.productPrice = new(productPrice);
        }

        public void AddProduct(string name, double price)
        {   if(name == null || name == string.Empty)
            {
                throw new ArgumentException("Name is null");
            }
            productPrice[name] = price;
        }

        public bool TryGetProductPrice(string productName, out double price)
        {
            if (!productPrice.ContainsKey(productName))
            {
                if (!PriceWasNotFound.Invoke(productName, this))
                {
                    price = default;
                    return false;
                }
            }
            double result = productPrice[productName];
            price = (result / 1000) * productPrice[productName];
            return true;
        }
    }
}