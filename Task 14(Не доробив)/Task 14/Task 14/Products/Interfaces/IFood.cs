namespace Task_14.Products.Interfaces
{
    public interface IFood : IProduct, IEquatable<object>
    {
        public double Weight { get; }
    }
}

