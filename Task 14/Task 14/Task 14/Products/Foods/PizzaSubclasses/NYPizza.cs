using System.Runtime.Serialization;
using Task_14.Enums;

namespace Task_14.Products.Foods.SubclassesOfPizza
{
    [Serializable]
    [DataContract]
    public class NYPizza : Pizza
    {
        public NYPizza(string? name, int price, double weight, PizzaTypes type, DateTime date, params Food[] ingridients) : base(name, price, weight, type, date, ingridients)
        {
        }

        public override string ToString()
        {
            return string.Format($"~~~{Name}, {Weight} Kg, {Price} UAH~~~");
        }
    }
}
