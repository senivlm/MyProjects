using System;

namespace _2Dmatrix
{
    public class Matrix
    {
        private int[,] matrix;
        
        private int[,] initMatrix(int n1, int n2)
        {
            return new int[n1, n2];
        }

        public override string ToString()
        {
            if (matrix == null)
            {
                return "no matrix";
            }
            string str = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    str += string.Format("\t {0}", matrix[i, j]);
                }
                str += "\n";
            }
            return str;
        }

        public void VerticalSnake(int n1, int n2)
        {
            matrix = initMatrix(n1, n2);
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
        public void DiagonalSnake(int n1, int n2)
        {
            matrix = initMatrix(n1, n2);
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
        public void SpiralSnake(int n1, int n2)
        {
            matrix = initMatrix(n1, n2);
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
}
