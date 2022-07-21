using Task_14.Enums;
using Task_14.Factories;
using Task_14.Factories.PatternStratehy;
using Task_14.Products.Interfaces;

namespace Task_14.Shops_Fabrics_.Pizzeria
{
    public abstract class Pizzeria : Shop
    {
        public Pizzeria(IDialogueStrategy dialogue) : base(dialogue)
        {
        }

        [NameLabel("Buy a pizza")]
        public abstract IPizza GetPizza(PizzaTypes pizzaType);
        [NameLabel("Buy a drink")]
        public abstract IFood GetDrink();
    }
}
