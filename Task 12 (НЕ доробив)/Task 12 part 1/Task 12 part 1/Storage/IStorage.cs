using Task_11.Products;

namespace Task_11.Storage
{
    public interface IStorage<T>
        where T : Product
    {
        public T this[int i] { get; }
        public int ProductAmount { get; }
        public event Action<T> ProductAvaliableEvent;
        public void AddItem(T item);
        public void RemoveItem(T item);
        public void ChangePriceOfAllProducts(int percentage);
    }
}
