using Task_14.Enums;
using Task_14.Products.Foods;
using Task_14.Products.Interfaces;

namespace Task_14.Shops_Fabrics_.Pizzeria
{
    public class ItalianPizzeria : Pizzeria
    {
        private Dictionary<PizzaTypes, IPizza> pizzesMenu;
        public ItalianPizzeria()
        {
            pizzesMenu = new();
            
        }

        public override IFood GetDrink()
        {
            throw new NotImplementedException();
        }

        public override IPizza GetPizza(PizzaTypes pizzaType)
        {
            throw new NotImplementedException();
        }
    }
}
