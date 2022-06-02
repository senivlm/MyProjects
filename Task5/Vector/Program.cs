using System;
using System.IO;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vec = new Vector();
            Console.WriteLine("merge sort from file:");
            vec.MergeSortInTxtFile(); // as argument of mergesort method can be identify the path to file with array: vec.MergeSort(@"Text.txt");
            Console.WriteLine("succesfull");
            Console.WriteLine("heap sort:");
            vec.RandomInitialization(10, 20);
            Console.WriteLine(vec);
            vec.HeapSort();
            Console.WriteLine(vec);

        }
    }
}
