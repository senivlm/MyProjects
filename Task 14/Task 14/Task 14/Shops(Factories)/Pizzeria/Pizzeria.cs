using Task_14.Enums;
using Task_14.Products.Interfaces;

namespace Task_14.Shops_Fabrics_.Pizzeria
{
    //Реалізація піцерії більше схожа на фабричний метод,
    //але легко розширити її до абстрактної фабрики.
    public abstract class Pizzeria
    {
        public abstract IPizza GetPizza(PizzaTypes pizzaType);
        public abstract IFood GetDrink();
    }
}
