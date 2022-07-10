using Task_11.Products;

namespace Task_11.Storage
{
    public interface IStoragable<T> where T : IProduct
    {
        public void AddItem(T item);
        public void RemoveItem(T item);
    }
}
