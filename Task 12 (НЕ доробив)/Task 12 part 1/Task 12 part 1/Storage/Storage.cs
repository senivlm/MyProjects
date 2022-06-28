using System.Collections;
using Task_11.Products;

namespace Task_11.Storage
{
    public class Storage : IStorage<Product>, IEnumerable<Product>
    {
        private List<Product> _products;

        public virtual event Action<Product> ProductAvaliableEvent;

        public int ProductAmount
        {
            get => _products.Count;
        }

        public Storage()
        {
            _products = new List<Product>();
        }

        public Storage(params Product[] products)
        {
            _products = new List<Product>();
            foreach (var item in products)
            {
                if (!_products.Contains(item))
                    ProductAvaliableEvent?.Invoke(item);
                _products.Add(item);
            }
        }

        public Product this[int i]
        {
            get
            {
                if (i >= 0 && i < _products.Count)
                    return _products[i];
                throw new ArgumentException();
            }
        }

        public void AddItem(Product? item)
        {
            if (item != null)
            {
                if (!_products.Contains(item))
                    ProductAvaliableEvent?.Invoke(item);
                _products.Add(item);
            }
        }

        public void RemoveItem(Product? item)
        {
            if (item != null)
            {
                _products.Remove(item);
            }
        }

        public bool TryToFindSpecialType<Type>(out Type? obj)
        {
            obj = default;
            bool isFound = false;
            foreach (var item in _products)
            {
                if (item is Type someProduct)
                {
                    obj = someProduct;
                    isFound = true;
                }
            }
            return isFound;
        }

        public void ChangePriceOfAllProducts(int percentage)
        {
            foreach (var item in _products)
            {
                item.ChangePrice(percentage);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Storage storage &&
                   EqualityComparer<List<Product>>.Default.Equals(_products, storage._products);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_products);
        }

        public IEnumerator<Product> GetEnumerator()
        {
            for (int i = 0; i < _products.Count; i++)
            {
                yield return _products[i].Clone();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
