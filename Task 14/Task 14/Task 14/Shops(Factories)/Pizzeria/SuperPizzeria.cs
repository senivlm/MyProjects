using Task_14.Enums;
using Task_14.Products.Foods;
using Task_14.Products.Foods.SubclassesOfPizza;
using Task_14.Products.Interfaces;

namespace Task_14.Shops_Fabrics_.Pizzeria
{
    public class SuperPizzeria : Pizzeria
    {
        private Dictionary<PizzaTypes, NYPizza> pizzesMenu;

        public SuperPizzeria(string Xmlpath = @"D:\MyProjects\Task 14\Task 14\Task 14\PizzaRecepies2.xml")
        {
            var tempMenu = XmlSerializator.XmlDeserialize<List<Pizza>>(Xmlpath);
            pizzesMenu = tempMenu.Select(ipizza => (NYPizza)ipizza).ToDictionary(x => x.Type);
        }

        public void AddPizza(NYPizza pizza) => pizzesMenu[pizza.Type] = (NYPizza)pizza.Clone();

        public override IFood GetDrink()
        {
            return new OtherFood("Juice", 15, 0.9);
        }

        public override IPizza GetPizza(PizzaTypes pizzaType)
        {
            return pizzesMenu[pizzaType];
        }
    }
}
