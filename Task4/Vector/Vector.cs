using System;

namespace Vector
{
    class Vector
    {
        private int[] array;

        public int GetLenght
        {
            get
            {
                if(array == null)
                {
                    throw new NullReferenceException();
                }
                return array.Length;
            }
        }
        public int this[int index]
        {
            get
            { 
                if(index >= 0 && index < array.Length)
                {
                    return array[index];
                }
                else
                {
                    throw new Exception("Index out of range array");
                }
            }
            set 
            {
                array[index] = value;
            }
        }

        public Vector(int[] arr)
        {
            this.array = arr;
        }

        public Vector(int n)
        {
            array = new int[n];
        }

        public Vector() : this(5)
        {

        }

        public void QuickSort(Pivots pivot)
        {
            switch (pivot)
            {
                case Pivots.FirstPivot:
                    quickSortWithFirstPivot(0, array.Length - 1);
                    break;
                case Pivots.LastPivot:
                    quickSortWithLastPivot(0, array.Length - 1);
                    break;
                case Pivots.MiddlePivot:
                    quickSortWithMiddlePivot(0, array.Length - 1);
                    break;
            }
        }
// краще було організувати один метод з параметром, який задає індекс опорного елемента. Повтор коду - це завжди проюлема.
        private void quickSortWithLastPivot(int start, int end)
        {
            if (start > end)
            {
                return;
            }
            int pivotIndex = end;
            int leftIndex = start;
            for (int i = start; i < end; i++)
            {
                if (array[i] < array[pivotIndex])
                {
                    array.Swap(i, leftIndex);
                    leftIndex++;
                }
            }
            array.Swap(leftIndex, pivotIndex);
            quickSortWithLastPivot(start, leftIndex - 1);
            quickSortWithLastPivot(leftIndex + 1, end);
        }

        private void quickSortWithFirstPivot(int start, int end)
        {
            if (start > end)
            {
                return;
            }
            int pivotIndex = start;
            int rightIndex = end;
            for (int i = end; i > 0; i--)
            {
                if (array[i] > array[pivotIndex])
                {
                    array.Swap(i, rightIndex);
                    rightIndex--;
                }
            }
            array.Swap(rightIndex, pivotIndex);
            quickSortWithFirstPivot(start, rightIndex - 1);
            quickSortWithFirstPivot(rightIndex + 1, end);
        }

        private void quickSortWithMiddlePivot(int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int leftIndex = start;
            int rightIndex = end;
            int pivotIndex = (end + start) / 2;
            while (leftIndex <= rightIndex)
            {
                while (array[leftIndex] < array[pivotIndex])
                {
                    leftIndex++;
                }
                while (array[rightIndex] > array[pivotIndex])
                {
                    rightIndex--;
                }
                if (leftIndex <= rightIndex)
                {
                    array.Swap(leftIndex, rightIndex);
                    leftIndex++;
                    rightIndex--;
                }
            }
            if (start < rightIndex)
            {
                quickSortWithMiddlePivot(start, rightIndex);
            }
            if (leftIndex < end)
            {
                quickSortWithMiddlePivot(leftIndex, end);
            }
        }

        public void Reverse()
        {
            int halfSize = array.Length / 2;
            for (int i = 0; i < halfSize; i++)
            {
                int item = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = item;
            }
        }

        public void InitShuffle()
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int number = random.Next(0, array.Length + 1);
                while(Array.IndexOf(array, number) != -1)
                {
                    number = random.Next(0, array.Length + 1);
                }
                array[i] = number;
            }
        }

        public SequenceInfo FindMaxSequence() //найдовша послідовність
        {
            int maxIndex = -1;
            int number = int.MinValue;
            int maxSequenceCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int sequenceCount = 1;
                int index = i;
                for (int j = i + 1; j < array.Length - 1 && array[i] == array[j]; j++)
                {
                    sequenceCount++;
                }
                if(sequenceCount > maxSequenceCount)
                {
                    maxSequenceCount = sequenceCount;
                    maxIndex = index;
                    number = array[i];
                }
            }
            return new SequenceInfo(maxIndex, number, maxSequenceCount);
        }

        public bool IsPalindromas() 
        {
            int halfSize = array.Length / 2;
            bool isPalindromas = true;
            for (int i = 0; i < halfSize; i++)
            {
                if(array[i] != array[array.Length - 1 - i])
                {
                    isPalindromas = false;
                }
            }
            return isPalindromas;
        }

        public void RandomInitialization(int a, int b)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(a, b);
            }
        }

        public Pair[] CalculateFrequence()
        {
            
            Pair[] pairs = new Pair[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                pairs[i] = new Pair(0,0);

            }
            int countDifference = 0;

            for (int i = 0; i < array.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if(array[i] == pairs[j].Number)
                    {
                        pairs[j].Freq++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Freq++;
                    pairs[countDifference].Number = array[i];
                    countDifference++;
                }
            }

            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < countDifference; i++)
            {
                result[i] = pairs[i];
            }

            return result;
        }

        public override string ToString()
        {
            string str = "[ ";
            for (int i = 0; i < array.Length; i++)
            {
                if (i < array.Length - 1)
                {
                    str += array[i] + ", ";
                }
                else
                {
                    str += array[i] + " ]";
                }
            }
            return str;
        }
    }
}
