using System.Runtime.Serialization;
using System.Xml.Serialization;
using Task_14.Enums;
using Task_14.Products.Interfaces;

namespace Task_14.Products.Foods
{
    [KnownType(typeof(Food))]
    [KnownType(typeof(OtherFood))]
    [KnownType(typeof(Meat))]
    [Serializable]
    [DataContract]
    public class Pizza : Food, IPizza
    {
        [DataMember]
        private List<Food> ingridients;
        [DataMember]
        public PizzaTypes Type { get; private set; }

        [DataMember]
        private DateTime timeToExpire;

        public ICollection<IFood> GetIngridients => new List<IFood>(ingridients);

        public DateTime TimeToExpire { get => timeToExpire; }

        public IFood GetIngridient(int id)
        {
            return ingridients[id].Clone();
        }

        public Pizza() : base("pizza", default, default)
        {
            this.ingridients = new();
        }

        public Pizza(string? name, int price, double weight, PizzaTypes type,  DateTime date, params Food[] ingridients)
            : base(name, price, weight)
        {
            timeToExpire = date;
            Type = type;
            this.ingridients = new (ingridients.ToList());
        }

        public Pizza(string? name, int price, double weight, PizzaTypes type, DateTime date, List<Food> ingridients)
           : base(name, price, weight)
        {
            timeToExpire = date;
            Type = type;
            this.ingridients = new List<Food>(ingridients);
        }

        public override string ToString()
        {
            return String.Format($"{Name}, {Weight} Kg, {Price} UAH");
        }

        public override IPizza Clone()
        {
            return new Pizza(name, price, weight, Type, TimeToExpire, ingridients);
        }
    }
}
