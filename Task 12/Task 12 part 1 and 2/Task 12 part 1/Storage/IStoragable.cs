using Task_11.Products;

namespace Task_11.Storage
{
    public interface IStoragable
    {
        public void AddItem(object item);
        public void RemoveItem(object item);
    }
}
