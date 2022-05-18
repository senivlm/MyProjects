using System;

namespace _2Dmatrix
{
    public static class SortMatrix
    {
        public static void DisplayMatrix(int[,] matrix)
        {
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("\t {0}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static void VerticalSnake(int[,] matrix)
        {
            int number = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (i % 2 == 0)
                    {
                        matrix[j, i] = ++number;
                    }
                    else
                    {
                        matrix[matrix.GetLength(0) - 1 - j, i] = ++number;
                    }
                }
            }
        }
        public static void DiagonalSnake(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException();
            }
            int number = 0;
            int X = 0;
            int Y = 0;
            for (int i = 0; i < matrix.GetLength(0) + matrix.GetLength(1) -1; i++)
            {
                if (X + Y < matrix.GetLength(0))
                {
                    if ((X + Y) % 2 != 0)
                    {
                        var iterCount = X + Y;
                        for (int j = 0; j <= iterCount; j++)
                        {
                            matrix[Y, X] = ++number;
                            X--;
                            Y++;
                        }
                        X = Y;
                        Y = 0;
                    }
                    else
                    {
                        var iterCount = X + Y;
                        for (int j = 0; j <= iterCount; j++)
                        {
                            matrix[X, Y] = ++number;
                            X--;
                            Y++;
                        }
                        X = Y;
                        Y = 0;
                    }
                }
                else
                {
                    if (X >= matrix.GetLength(0)) X -= 1;
                    if ((X + Y) % 2 == 0)
                    {
                        Y += 1;
                        var iterCount = X - Y;
                        for (int j = 0; j <= iterCount; j++)
                        {
                            matrix[Y, X] = ++number;
                            X--;
                            Y++;
                        }
                        int tempX = X + 1;
                        X = Y - 1;
                        Y = tempX;
                    }
                    else
                    {
                        Y += 1;
                        var iterCount = X - Y;
                        for (int j = 0; j <= iterCount; j++)
                        {
                            matrix[X, Y] = ++number;
                            X--;
                            Y++;
                        }
                        int tempX = X + 1;
                        X = Y - 1;
                        Y = tempX;
                    }
                }
            }
        }
        public static void SpiralSnake(int[,] matrix)
        {
            int number = 0;
            for (int j = 0; j < (matrix.GetLength(0) + matrix.GetLength(1)) / 2 - 2; j++)
            {
                for (int i = j; i < matrix.GetLength(0) - j; i++)
                {
                    matrix[i, j] = ++number;
                }
                for (int i = j + 1; i < matrix.GetLength(1) - j - 1; i++)
                {
                    matrix[matrix.GetLength(0) - 1 - j, i] = ++number;
                }
                for (int i = matrix.GetLength(0) - 1 - j; i > j; i--)
                {
                    matrix[i, matrix.GetLength(1) - 1 - j] = ++number;
                }
                for (int i = matrix.GetLength(1) - 1 - j; i > j; i--)
                {
                    matrix[j, i] = ++number;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[7, 10];
            SortMatrix.SpiralSnake(matrix);
            SortMatrix.DisplayMatrix(matrix);

        }
    }
}
