using Task_14.Enums;
using Task_14.Factories.PatternStratehy;
using Task_14.Products.Foods;
using Task_14.Products.Foods.SubclassesOfPizza;
using Task_14.Products.Interfaces;

namespace Task_14.Shops_Fabrics_.Pizzeria
{
    public class ItalianPizzeria : Pizzeria
    {
        private Dictionary<PizzaTypes, ItalianPizza> pizzesMenu;
        public ItalianPizzeria(IDialogueStrategy dialogue,
            string Xmlpath = @"D:\MyProjects\Task 14\Task 14\Task 14\PizzaRecepies1.xml") : base(dialogue)
        {
            var tempMenu = XmlSerializator.XmlDeserialize<List<Pizza>>(Xmlpath);
            pizzesMenu = tempMenu.Select(ipizza => (ItalianPizza)ipizza).ToDictionary(x => x.Type);
        }

        public void AddPizza(ItalianPizza pizza) => pizzesMenu[pizza.Type] = (ItalianPizza)pizza.Clone();

        public override IFood GetDrink()
        {
            return new Water("Water", 15, 0.4);
        }

        public override IPizza GetPizza(PizzaTypes pizzaType)
        {
            return pizzesMenu[pizzaType];
        }
    }
}
