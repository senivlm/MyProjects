using System.Text;

namespace Task9
{
    class Menu
    {
        private List<Dish> menu;

        public Menu()
        {
            menu = new();
        }

        public Menu(params Dish[] dishes) : this()
        {
            menu = new(dishes);
        }

        public Menu(List<Dish> dishes) : this()
        {
            menu = new(dishes);
        }

        public IEnumerable<Dish> GetDishes()
        {
            foreach (var dish in menu)
            {
                yield return new Dish(dish);
            }
        }

        public bool TryToGetSumPrice(PriceKurant priceKurant, out double price)
        {
            double sum = 0.0;
            price = default;
            foreach (var item in menu)
            {
                if(!priceKurant.TryGetProductPrice(item.Name, out sum))
                {
                    return false;
                }
                price += sum; 
            }
            return true;
        }
    }
}