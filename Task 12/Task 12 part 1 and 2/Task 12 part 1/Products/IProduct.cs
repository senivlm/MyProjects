namespace Task_11.Products
{
    public interface IProduct
    {
        public string Name { get; }
        public int Price { get; }
        public void ChangePrice(int percentage);
        public IProduct Clone();
        public void Parse(string text);
    }
}

