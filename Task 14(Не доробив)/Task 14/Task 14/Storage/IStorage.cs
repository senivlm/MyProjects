using Task_14.Products.Interfaces;

namespace Task_11.Storage
{
    public interface IStorage<T> : IEnumerable<KeyValuePair<T, int>> where T : IProduct
    {
        public KeyValuePair<T, int> this[int i] { get; }
        public int ProductAmount { get; }
        public event Action<T> ProductAvaliableEvent;
    }
}
