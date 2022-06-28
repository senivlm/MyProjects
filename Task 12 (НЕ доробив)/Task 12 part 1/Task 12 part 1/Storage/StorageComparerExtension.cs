using Task_11.Products;

namespace Task_11.Storage
{
    static class StorageComparerExtension
    {
        public static IEnumerable<Product> NotRepetitiveElementsInCompareTo(this Storage storage1, Storage storage2)
        {
            return storage1.ElementsInCompareTo(storage2, false);
        }

        public static IEnumerable<Product> MutualElementsInCompareTo(this Storage storage1, Storage storage2)
        {
            return storage1.ElementsInCompareTo(storage2, true);
        }

        public static IEnumerable<Product> UniqueMutualElementsInCompareTo(this Storage storage1, Storage storage2)
        {
            var products = new List<Product>();
            foreach (var item1 in storage1)
            {
                bool Change = false;
                foreach (var item2 in storage2)
                {
                    if (item1 == item2)
                    {
                        Change = true;
                    }
                }
                if (Change && !products.Contains(item1))
                {
                    products.Add(item1);
                }
            }
            return products;
        }

        private static IEnumerable<Product> ElementsInCompareTo(this Storage storage1, Storage storage2, bool isRepititive)
        {
            var products = new List<Product>();
            foreach (var item1 in storage1)
            {
                bool Change = !isRepititive;
                foreach (var item2 in storage2)
                {
                    if (item1 == item2)
                    {
                        Change = isRepititive;
                        break;
                    }
                }
                if (Change)
                {
                    products.Add(item1);
                }
            }
            return products;
        }
    }
}
