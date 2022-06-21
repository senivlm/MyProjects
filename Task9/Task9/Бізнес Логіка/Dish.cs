namespace Task9
{
    class Dish
    {
        public string Name { get; private set; }
        private Dictionary<string, double> ingridients;

        public Dish(string name)
        {
            Name = name;
            ingridients = new();
        }

        public Dish(string name, Dictionary<string, double> ingridients) : this(name)
        {
            this.ingridients = new(ingridients); 
        }
        public Dish(Dish dish)
        {
            Name = dish.Name;
            ingridients = new(dish.ingridients);
        }

        public IEnumerable<string> GetIngridients => ingridients.Keys;

        public void AddIngridient(string name, double weight)
        {
            ingridients[name] = weight;
        }

        public void AddIngridient(KeyValuePair<string, double> ingridient)
        {
            ingridients.Add(ingridient.Key, ingridient.Value);
        }

        public double this[string name]
        {
            get
            {
                if(ingridients.ContainsKey(name))
                    return ingridients[name];
                throw new IndexOutOfRangeException();
            }
        }

        public double Weight
        {
            get
            {
                double weight = 0.0;
                foreach (var value in ingridients.Values) weight += value;
                return weight;
            }
        }

        public double GetSumPrice(PriceKurant priceKurant)
        {
            double sumPrice = 0.0;
            foreach (var item in ingridients.Keys)
            { 
                if(!priceKurant.TryGetProductPrice(item, out double price)){
                    throw new FormatException();
                }
                sumPrice += price;
            }
            return sumPrice;    
        }
    }
}