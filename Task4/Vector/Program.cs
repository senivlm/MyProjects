using System;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vec = new Vector(6);
            Console.WriteLine("Sorting using last element as a fixed index");
            vec.RandomInitialization(0, 30);
            Console.WriteLine(vec);

            vec.QuickSort(vec.GetLenght - 1);
            Console.WriteLine(vec);

            Console.WriteLine("Sorting using middle element as a fixed index");
            vec.RandomInitialization(0, 30);
            Console.WriteLine(vec);

            vec.QuickSort(vec.GetLenght / 2);
            Console.WriteLine(vec);

            Console.WriteLine("Sorting using first element as a fixed index");
            vec.RandomInitialization(0, 30);
            Console.WriteLine(vec);

            vec.QuickSort(0);
            Console.WriteLine(vec);

        }
    }
}
