using System;

namespace _1_Portals
{
    class Portals
    {
        private static int[,] labirint;

        private static int startRow;
        private static int startCol;

        private static int rows;
        private static int cols;

        private static long max = 0;

        private static bool[,] visited;

        static void Main()
        {
            var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            startRow = int.Parse(tokens[0]);
            startCol = int.Parse(tokens[1]);

            tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            rows = int.Parse(tokens[0]);
            cols = int.Parse(tokens[1]);

            labirint = new int[rows, cols];
            visited = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < tokens.Length; j++)
                {
                    if (tokens[j] == "#")
                    {
                        labirint[i, j] = -5;
                    }
                    else
                    {
                        labirint[i, j] = int.Parse(tokens[j]);
                    }
                }
            }


            Solve(startRow, startCol, 0, startRow, startCol);

            if (labirint[startRow, startCol] > max)
            {
                Console.WriteLine(labirint[startRow, startCol]);
            }
            else
            {
                Console.WriteLine(max);
            }

            //PrintLabirint();
        }

        private static void Solve(int row, int col, long currentSum, int oldRow, int oldCol)
        {

            if (row < 0 || row >= rows || col < 0 || col >= cols)
            {
                currentSum -= labirint[oldRow, oldCol];

                if (max < currentSum)
                {
                    max = currentSum;
                }

                return;
            }

            if (visited[row, col])
            {
                if (max < currentSum)
                {
                    max = currentSum;
                }

                return;
            }

            visited[row, col] = true;

            long jumpNumber = labirint[row, col];
            if (jumpNumber > 0)
            {
                // left move
                Solve(row, col - labirint[row, col], currentSum + jumpNumber, row, col);
                // right move
                Solve(row, col + labirint[row, col], currentSum + jumpNumber, row, col);
                // up move
                Solve(row - labirint[row, col], col, currentSum + jumpNumber, row, col);
                // down move
                Solve(row + labirint[row, col], col, currentSum + jumpNumber, row, col);
            }

            visited[row, col] = false;
        }

        private static void PrintLabirint()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(" " + labirint[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
