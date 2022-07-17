using Task_14.Products.Interfaces;

namespace Task_11.Storage
{
    static class StorageComparerExtension
    {
        public static IEnumerable<T> NotRepetitiveElementsInCompareTo<T>(this IStorage<T> storage1, IStorage<T> storage2)
            where T : IProduct
        {
            return storage1.ElementsInCompareTo(storage2, false);
        }

        public static IEnumerable<T> MutualElementsInCompareTo<T>(this IStorage<T> storage1, IStorage<T> storage2)
            where T : IProduct
        {
            return storage1.ElementsInCompareTo(storage2, true);
        }

        public static IEnumerable<T> UniqueMutualElementsInCompareTo<T>(this IStorage<T> storage1, IStorage<T> storage2)
            where T : IProduct
        {
            var products = new List<IProduct>();
            foreach (var item1 in storage1)
            {
                bool Change = false;
                foreach (var item2 in storage2)
                {
                    if (item1.Equals(item2))
                    {
                        Change = true;
                    }
                }
                if (Change && !products.Contains(item1.Key))
                {
                    products.Add(item1.Key);
                }
            }
            return (IEnumerable<T>)products;
        }

        private static IEnumerable<T> ElementsInCompareTo<T>(this IStorage<T> storage1, IStorage<T> storage2, bool isRepititive)
            where T : IProduct
        {
            var products = new List<IProduct>();
            foreach (var item1 in storage1)
            {
                bool Change = !isRepititive;
                foreach (var item2 in storage2)
                {
                    if (item1.Equals(item2))
                    {
                        Change = isRepititive;
                        break;
                    }
                }
                if (Change)
                {
                    products.Add(item1.Key);
                }
            }
            return (IEnumerable<T>)products;
        }
    }
}
