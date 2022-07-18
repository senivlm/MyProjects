namespace Task_14.Products.Interfaces
{
    public interface IProduct
    {
        public string Name { get; }
        public int Price { get; }
        public void ChangePrice(int percentage);
    }
}

