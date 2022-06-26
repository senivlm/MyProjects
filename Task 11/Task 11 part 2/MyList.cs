using System.Collections;

namespace ASDF
{
    public class Comparer<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            return y.CompareTo(x);
        }
    }
    internal class MyList<T> : IList<T> where T : IComparable<T>
    {
        List<T> _list;

        public MyList()
        {
            _list = new();
        }

        public MyList(params T[] items)
        {
            _list = new(items);
        }

        private int FindIndex(int left, int right, T item)
        {
            if (right - left <= 0)
            {
                return _list[left].CompareTo(item) == 0 ? left : -1;
            }

            int middle = (left + right) / 2;

            if (_list[middle].CompareTo(item) == 0)
            {
                return middle;
            }

            if (_list[middle].CompareTo(item) > 0)
            {
                right = middle;
            }
            else
            {
                left = middle;
            }
            return FindIndex(left, right, item);
        }

        public int FindIndex(T item)
        {
            int left = 0;
            int right = _list.Count;

            _list.Sort();

            return FindIndex(left, right, item);
        }

        public T this[int index] {
            get
            {
                if(index <= _list.Count && index >= 0)
                {
                    return _list[index];
                }
                throw new IndexOutOfRangeException();
            }
            set {
                _list[index] = value;
            }
        }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Sort()
        {
            // _list.Sort(new Comparer());
            _list.Sort((T x, T y) => x.CompareTo(y));
        }

        public void Add(T item)
        {
            _list.Add(item);
        }

        public override string ToString()
        {
            string ans = "";
            foreach(var item in _list)
            {
                ans += item + " ";
            }
            return ans;
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _list.Count - 1; i >= 0; i--)
            {
                yield return _list[i];
            }        
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }


    interface IPrint<T>
    {
        public void Print(T obj);
    }

    public class MyPrinter<T> : IPrint<T>
    {
        private T _field = default;
        public void Print(T obj)
        {
            if (_field is null)
            {
                Console.WriteLine("value is null");
            }
        }
    }
}
