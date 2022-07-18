using Task_14.Enums;
using Task_14.Products.Foods;

namespace Task_14.Products.Interfaces
{
    public interface IPizza : IFood, IExpirable, ICloneable<IPizza>
    {
        public PizzaTypes Type { get; }
        public IFood GetIngridient(int id);
        public ICollection<IFood> GetIngridients { get; }

    }
}
