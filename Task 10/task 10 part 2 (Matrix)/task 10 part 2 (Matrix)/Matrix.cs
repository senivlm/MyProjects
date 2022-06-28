using System;
using System.Collections;

namespace _2Dmatrix
{
    public class Matrix : IEnumerable<int>
    {
        private int[,] matrix;
        public IEnumerator<int> GetEnumerator()
        {
            VerticalSnake(5, 5);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    yield return matrix[i, j];
                }
            }
        }
// я про цю частку хотіла б детальніше поговорити. Зголосіться на парі.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<int> GetEnumeratorDiagonalSnake(int n, Directions direction)
        {
            SortMatrixDiagonal(n, direction);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    yield return matrix[i, j];
                }
            }
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

        private bool IsDownWay(int line, Directions direction)
        {
            if(direction == Directions.Down)
            {
                return !(line % 2 == 0);
            }
            else
            {
                return line % 2 == 0;
            }
        }

        public void SortMatrixDiagonal(int n, Directions direction)
        {
            matrix = new int[n, n];
            int number = 0;
            int line = 0;
            for (line = 0; line < n; line++)
            {
                if (IsDownWay(line, direction))
                {
                    int i1 = line;
                    int j1 = 0;
                    for (int i = 0; i < line + 1; i++)
                    {
                        matrix[i1, j1] = ++number;
                        i1--;
                        j1++;
                    }
                }
                else
                {
                    int i1 = 0;
                    int j1 = line;
                    for (int i = 0; i < line + 1; i++)
                    {
                        matrix[i1, j1] = ++number;
                        i1++;
                        j1--;
                    }
                }
            }
            int startPos1 = 1;
            int startPos2 = line - 1;
            for (int linePart2 = line - 1; linePart2 > 0; linePart2--)
            {
                if(IsDownWay(linePart2, direction))
                {
                    int i1 = startPos1;
                    int j1 = startPos2;
                    for (int i = 0; i < linePart2; i++)
                    {
                        matrix[i1, j1] = ++number;
                        i1++;
                        j1--;
                    }
                }
                else
                {
                    int i1 = startPos2;
                    int j1 = startPos1;
                    for (int i = 0; i < linePart2; i++)
                    {
                        matrix[i1, j1] = ++number;
                        i1--;
                        j1++;
                    }
                }
                startPos1++;
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

        private int[,] initMatrix(int n1, int n2)
        {
            return new int[n1, n2];
        }
    }
}
