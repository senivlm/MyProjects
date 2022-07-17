using Task_14.Enums;
using Task_14.Products.Interfaces;

namespace Task_14.Shops_Fabrics_.Pizzeria
{
    //Абстрактна фабрика
    public abstract class Pizzeria
    {
        public abstract IPizza GetPizza(PizzaTypes pizzaType);
        public abstract IFood GetDrink();
    }
}
