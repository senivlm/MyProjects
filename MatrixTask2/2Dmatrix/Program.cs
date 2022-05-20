using System;

namespace _2Dmatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix();
            matrix.DiagonalSnake(5,5);
            Console.WriteLine(matrix);
            matrix.SpiralSnake(5, 7);
            Console.WriteLine(matrix);
            matrix.VerticalSnake(6, 4);
            Console.WriteLine(matrix);
        }
    }
}
