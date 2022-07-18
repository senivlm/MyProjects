namespace Task_14.Products.Interfaces
{
    public interface IFood : IProduct, IEquatable<object>, ICloneable<IFood>
    {
        public double Weight { get; }
    }
}

