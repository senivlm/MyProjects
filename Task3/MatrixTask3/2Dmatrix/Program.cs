using System;

namespace _2Dmatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix();
            Console.WriteLine("start direction is down:");
            matrix.SortMatrixDiagonal(4 , Directions.Down);
            Console.WriteLine(matrix);
            Console.WriteLine("start direction is right:");
            matrix.SortMatrixDiagonal(4, Directions.Right);
            Console.WriteLine(matrix);
            //matrix.SpiralSnake(5, 7);
            //Console.WriteLine(matrix);
            //matrix.VerticalSnake(6, 4);
            //Console.WriteLine(matrix);
        }
    }
}
