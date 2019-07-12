using System;

namespace Matrix
{
    class Program
    {
        static bool[,] _matrix = { { true, false, true, false, true },
                                  { true, false, false, false, true },
                                  { true, true, true, true, false },
                                  { true, false, true, false, false },
                                  { true, true, true, true, true } };

        static readonly int MatrixLength = _matrix.GetLength(0);

        static readonly int[] Rows = { 0, 1, 0, -1 };
        static readonly int[] Columns = { -1, 0, 1, 0 };

        static void Main(string[] args)
        {
            int sum = 0;

            PrintMatrix();

            for (int i = 0; i < MatrixLength; i++)
            {
                for (int j = 0; j < MatrixLength; j++)
                {
                    if (!_matrix[i, j])
                    {
                        ComputeNext(i, j);

                        PrintMatrix();
                        ++sum;
                    }
                }
            }

            Console.WriteLine($"map components: {sum}");

            Console.ReadLine();
        }

        private static void ComputeNext(int i, int j)
        {
            _matrix[i, j] = true;

            for (int pos = 0; pos < Rows.Length; pos++)
            {
                int x = i + Rows[pos];
                int y = j + Columns[pos];

                if (x < MatrixLength && x >= 0 && y < MatrixLength && y >= 0 && !_matrix[x, y])
                {
                    ComputeNext(x, y);
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < MatrixLength; i++)
            {
                for (int j = 0; j < MatrixLength; j++)
                {
                    Console.Write($"{_matrix[i, j]} ");
                }

                Console.Write(Environment.NewLine);
            }

            Console.WriteLine("--------------------------");
        }
    }
}
