using Task_14.Enums;
using Task_14.Products.Foods;
using Task_14.Products.Interfaces;

namespace Task_14.Shops_Fabrics_.Pizzeria
{
    public class ItalianPizzeria : Pizzeria
    {
        private Dictionary<PizzaTypes, IPizza> pizzesMenu;
        public ItalianPizzeria(string Xmlpath = @"D:\MyProjects\Task 14\Task 14\Task 14\PizzaRecepies1.xml")
        {
            pizzesMenu = new();
            var temp = XmlSerializator.XmlDeserialize<List<Pizza>>(Xmlpath);
            foreach (var item in temp)
            {
                pizzesMenu[item.Type] = item;
            }
        }

        public void AddPizza(IPizza pizza) => pizzesMenu[pizza.Type] = (IPizza)((Pizza)pizza).Clone();

        public override IFood GetDrink()
        {
            return new OtherFood("CocaCola", 20, 0.6);
        }

        public override IPizza GetPizza(PizzaTypes pizzaType)
        {
            return pizzesMenu[pizzaType];
        }
    }
}
