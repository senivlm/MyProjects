using System;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vec = new Vector(8);
            Console.WriteLine("Before sort:");
            vec.RandomInitialization(0, 30);
            Console.WriteLine(vec);
            Console.WriteLine("Sorting using last element as a fixed index");
            vec.QuickSort(Pivots.LastPivot);
            Console.WriteLine(vec);

            Console.WriteLine("Before sort:");
            vec.RandomInitialization(0, 30);
            Console.WriteLine(vec);

            Console.WriteLine("Sorting using middle element as a fixed index");
            vec.QuickSort(Pivots.MiddlePivot);
            Console.WriteLine(vec);


            Console.WriteLine("Before sort:");
            vec.RandomInitialization(0, 30);
            Console.WriteLine(vec);

            Console.WriteLine("Sorting using first element as a fixed index");
            vec.QuickSort(Pivots.FirstPivot);
            Console.WriteLine(vec);

        }
    }
}
