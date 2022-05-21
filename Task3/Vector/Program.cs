using System;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector arr = new Vector(8);
            Console.WriteLine("Random Initialization:");
            arr.RandomInitialization(0, 10);
            Console.WriteLine(arr);
            Console.WriteLine("Shuffle: ");
            arr.InitShuffle();
            Console.WriteLine(arr);
            Console.WriteLine("Sequence: ");
            arr.RandomInitialization(1, 3);
            Console.WriteLine(arr);
            Console.WriteLine(arr.FindMaxSequence());

            //демонстрація використання реверсу

            int[] someArray = new int[] { 5, 4, 3, 2, 1 };
            Array.Reverse<int>(someArray);
            foreach (var item in someArray)
            {
                Console.Write(" " + item);
            }

            Console.WriteLine();
            arr.Reverse();
            Console.WriteLine(arr);
        }
    }
}
