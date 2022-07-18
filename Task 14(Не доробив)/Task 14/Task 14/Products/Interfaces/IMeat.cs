using Task_11.Enums;

namespace Task_14.Products.Interfaces
{
    public interface IMeat : IFood, IExpirable, ICloneable<IFood>
    {
        public Category MeatCategory { get; }
        public Species MeatSpecies { get; }
    }
}

