using Task_14.Enums;
using Task_14.Products.Foods;
using Task_14.Products.Interfaces;

namespace Task_14.Shops_Fabrics_.Pizzeria
{
    public class SuperPizzeria : Pizzeria
    {
        private Dictionary<PizzaTypes, IPizza> pizzesMenu;

        public SuperPizzeria(string Xmlpath = @"D:\MyProjects\Task 14\Task 14\Task 14\PizzaRecepies2.xml")
        {
            pizzesMenu = new();
            var temp = XmlSerializator.XmlDeserialize<List<Pizza>>(Xmlpath);
            pizzesMenu = temp.Select(ipizza => (IPizza)ipizza).ToDictionary(x => x.Type);
        }

        public void AddPizza(IPizza pizza) => pizzesMenu[pizza.Type] = (IPizza)((Pizza)pizza).Clone();

        public override IFood GetDrink()
        {
            return new OtherFood("Juice", 15, 0.9);
        }

        public override IPizza GetPizza(PizzaTypes pizzaType)
        {
            throw new NotImplementedException();
        }
    }
}
