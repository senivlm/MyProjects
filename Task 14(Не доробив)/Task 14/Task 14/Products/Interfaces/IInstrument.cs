using Task_14.Enums;

namespace Task_14.Products.Interfaces
{
    public interface IInstrument : IProduct, ICloneable<IInstrument>, IEquatable<object>
    {
        public Colors Color { get; }
        public double Weight { get; }
    }
}
