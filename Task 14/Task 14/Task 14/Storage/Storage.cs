using System.Collections;
using System.Reflection;
using System.Runtime.Serialization;
using Task_14.Products.Foods;
using Task_14.Products.Interfaces;

namespace Task_11.Storage
{// не побачила реалізації абстрактної фабрики.
    [Serializable]
    [KnownType(typeof(Dictionary<Food, int>))]
    [KnownType(typeof(KeyValuePair<Food, int>))]
    [KnownType(typeof(OtherFood))]
    [KnownType(typeof(Meat))]
    [KnownType(typeof(Milk))]
    [DataContract]
    public class Storage<T> : IStorage<T>, IStoragable
        where T : IProduct, ICloneable<T>
    {
        [DataMember]
        private static Lazy<Storage<T>> instance = new(() => new Storage<T>());
        [DataMember]
        private Dictionary<T, int> _products;
        
        public virtual event Action<T>? ProductAvaliableEvent;
        public virtual event Action<T>? ProductIsExpiredEvent;

        public int ProductAmount
        {
            get => _products.Count;
        }

        private Storage()
        {
            _products = new();
        }

        public static Storage<T> GetInstance()
        {
            return instance.Value;
        }

        public void AddProducts(params KeyValuePair<T, int>[] products)
        {
            _products = new();
            foreach (var item in products)
            {
                if (!_products.Contains(item))
                    ProductAvaliableEvent?.Invoke(item.Key);
                _products.Add(item.Key, item.Value);
                if (isExpired(item.Key))
                {
                    ProductIsExpiredEvent?.Invoke(item.Key);
                }
            }
        }

        public KeyValuePair<T, int> this[int i]
        {
            get
            {
                if (i >= 0 && i < _products.Count)
                    return _products.ToArray()[i];
                throw new ArgumentException();
            }
        }

        //пошук по предикату
        public IEnumerable<KeyValuePair<T, int>> Select(Func<KeyValuePair<T, int>, bool> predicate)
        {
            return _products.Where(x => predicate(x));
        }

        //універсальний пошук по предикату 
        public ICollection<T> FindWithPredicate(Func<PropertyInfo, bool> predicate)
        {
            List<T> list = new List<T>();
            try
            {
                foreach (var item in this)
                {
                    Type type = item.GetType();
                    foreach (PropertyInfo field in type.GetProperties())
                    {
                        if (predicate(field))
                        {
                            list.Add(item.Key.Clone());
                        }
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return list;
        }

        public void AddItem(object item, int quantity)
        {
            if (item == null)
            {
                return;
            }
            var temp = (T)item;
            _products.Add(temp, quantity);

            if (isExpired((T)item))
            {
                ProductIsExpiredEvent?.Invoke((T)item);
            }
        }

        public void AddItem(object item)
        {
            if (item == null)
            {
                return;
            }
            else if (!_products.Keys.Contains((T)item))
            {
                ProductAvaliableEvent?.Invoke((T)item);
            }
            var temp = (KeyValuePair<T, int>)item;
            _products.Add(temp.Key, temp.Value);

            if (isExpired((T)item))
            {
                ProductIsExpiredEvent?.Invoke((T)item);
            }
        }

        private bool isExpired(T? item)
        {
            if (item is IExpirable expirableProduct
               && expirableProduct.TimeToExpire < DateTime.Now)
            {
                return true;
            }
            return false;
        }

        public void RemoveItem(object item)
        {
            if (item != null)
            {
                _products.Remove((T)item);
            }
        }

        public bool TryToFindSpecialType<Type>(out IEnumerable<T> products)
        {
            products = _products.Keys.Where(x => x is Type);
            return products.Count() > 0;
        }

        public void ChangePriceOfAllProducts(int percentage)
        {
            foreach (var item in _products)
            {
                item.Key.ChangePrice(percentage);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Storage<T> storage &&
                   EqualityComparer<Dictionary<T, int>>.Default.Equals(_products, storage._products);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_products);
        }

        public IEnumerator<KeyValuePair<T, int>> GetEnumerator()
        {
            for (int i = 0; i < _products.Count; i++)
            {
                yield return new KeyValuePair<T, int>
                    (_products.Keys.ToArray()[i].Clone(), _products.Count);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
