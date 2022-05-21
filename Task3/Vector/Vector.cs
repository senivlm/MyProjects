using System;

namespace Vector
{
    class Vector
    {
        private int[] array;

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

        public Vector()
        {
            array = new int[5];
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
