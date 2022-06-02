using System;
using System.IO;

namespace Vector
{
    class Vector
    {
        private int[] array;

        public int GetLenght
        {
            get
            {
                if (array == null)
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
                if (index >= 0 && index < array.Length)
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

        private void readFromFileInto2Arrays(string filePath, out int[] leftHalf, out int[] rightHalf)
        {
            int lenght = 0;
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    while (char.IsDigit(Convert.ToChar(sr.Read())) && !sr.EndOfStream)
                    {
                    }
                    lenght++;
                }
            }
            using (StreamReader sr = new StreamReader(filePath))
            {
                int i = 0;
                leftHalf = new int[lenght / 2];
                rightHalf = new int[lenght - lenght / 2];
                while (!sr.EndOfStream)
                {
                    int multiplier = 1;
                    int number = 0;
                    char c = Convert.ToChar(sr.Read());

                    while (char.IsDigit(c) && !sr.EndOfStream)
                    {
                        number = (c - '0') + (number * multiplier);
                        multiplier = 10;
                        if (!sr.EndOfStream)
                            c = Convert.ToChar(sr.Read());
                    }
                    if (sr.EndOfStream)
                    {
                        number = (c - '0') + (number * multiplier);
                    }
                    if (i < leftHalf.Length)
                    {
                        leftHalf[i] = number;
                    }
                    else
                    {
                        if (i < rightHalf.Length)
                            i++;
                        rightHalf[i - rightHalf.Length] = number;
                    }
                    i++;
                }

            }
        }

        public void MergeSortInTxtFile(string pathOfFile = @"Test.txt")
        {
            // array must be pre-written in file
            try
            {
                mergeSort(pathOfFile, true); // sort and write sorted array to file txt
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void mergeSort(string path, bool firstTime, int[] array = null)
        {
            if (array != null && array.Length < 2)
            {
                return;
            }

            int[] leftHalf;
            int[] rightHalf;
            if (firstTime)
            {
                readFromFileInto2Arrays(path, out leftHalf, out rightHalf);
                array = new int[leftHalf.Length + rightHalf.Length];
                this.array = array;
            }
            else
            {
                int midIndex = array.Length / 2;
                leftHalf = new int[midIndex];
                rightHalf = new int[array.Length - midIndex];

                for (int i = 0; i < midIndex; i++)
                {
                    leftHalf[i] = array[i];
                }
                for (int i = midIndex; i < array.Length; i++)
                {
                    rightHalf[i - midIndex] = array[i];
                }
            }

            mergeSort(path, false, leftHalf);
            mergeSort(path, false, rightHalf);

            merge(array, leftHalf, rightHalf, path);
        }

        private void merge(int[] array, int[] leftHalf, int[] rightHalf, string path)
        {
            int i = 0, j = 0, k = 0;
            if (array.Length == this.array.Length)
            {
                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine();
                while (i < leftHalf.Length && j < rightHalf.Length)
                {
                    if (leftHalf[i] <= rightHalf[j])
                    {
                        sw.Write(leftHalf[i]);
                        i++;
                    }
                    else
                    {
                        sw.Write(rightHalf[j]);
                        j++;
                    }
                    k++;
                    sw.Write(" ");
                }

                while (i < leftHalf.Length)
                {
                    sw.Write(leftHalf[i]);
                    i++;
                    k++;
                    sw.Write(" ");
                }

                while (j < rightHalf.Length)
                {
                    sw.Write(rightHalf[j]);
                    j++;
                    k++;
                    sw.Write(" ");
                }
                sw.Close();
            }
            else
            {
                while (i < leftHalf.Length && j < rightHalf.Length)
                {
                    if (leftHalf[i] <= rightHalf[j])
                    {
                        array[k] = leftHalf[i];
                        i++;
                    }
                    else
                    {
                        array[k] = rightHalf[j];
                        j++;
                    }
                    k++;
                }

                while (i < leftHalf.Length)
                {
                    array[k] = leftHalf[i];
                    i++;
                    k++;
                }

                while (j < rightHalf.Length)
                {
                    array[k] = rightHalf[j];
                    j++;
                    k++;
                }
            }
        }

        public void HeapSort()
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                moveTreeToLargest(n, i);


            for (int i = n - 1; i >= 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                moveTreeToLargest(i, 0);
            }
        }

        private void moveTreeToLargest(int n, int i)
        {
            int largest = i;
            int leftBucket = 2 * i + 1;
            int rightBucket = 2 * i + 2;

            if (leftBucket < n && array[leftBucket] > array[largest])
            {
                largest = leftBucket;
            }

            if (rightBucket < n && array[rightBucket] > array[largest])
            {
                largest = rightBucket;
            }

            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                moveTreeToLargest(n, largest);
            }
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
                while (Array.IndexOf(array, number) != -1)
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
                if (sequenceCount > maxSequenceCount)
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
                if (array[i] != array[array.Length - 1 - i])
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
                pairs[i] = new Pair(0, 0);

            }
            int countDifference = 0;

            for (int i = 0; i < array.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if (array[i] == pairs[j].Number)
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
