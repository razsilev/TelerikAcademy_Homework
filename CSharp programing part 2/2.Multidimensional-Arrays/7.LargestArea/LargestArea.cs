using System;
using System.Collections.Generic;

class LargestArea
{
    static void Main()
    {
        int[,] matrix = {
                            {1, 3, 2, 2, 1, 4},
                            {3, 3, 3, 2, 1, 4},
                            {4, 3, 1, 2, 3, 3},
                            {4, 3, 1, 3, 3, 1},
                            {4, 3, 3, 3, 1, 1}
                        };

        int maxLength = FindMaxLength(matrix);
        Console.WriteLine("Largest area of equal neighbor have: {0} elements.", maxLength);
        Console.WriteLine();
    }

    private static int FindMaxLength(int[,] matrix)
    {
        int maxCount = 0;

        bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (visited[row, col])
                {
                    continue;
                }

                int currentCount = CheckCount(matrix, visited, row, col, 0);

                if (maxCount < currentCount)
                {
                    maxCount = currentCount;
                }
            }
        }

        return maxCount;
    }

    private static int CheckCount(int[,] matrix, bool[,] visited, int row, int col, int count)
    {
        visited[row, col] = true;

        // check elements around the given coordinates row col
        for (int currentRow = row - 1; currentRow <= row + 1; currentRow++)
        {
            if ((currentRow >= matrix.GetLength(0)) || (currentRow < 0))
            {
                continue;
            }

            for (int currentCol = col - 1; currentCol <= col + 1; currentCol++)
            {
                // check for valid current coordinates
                if ((currentCol >= matrix.GetLength(1)) || (currentCol < 0))
                {
                    continue;
                }

                // do not check corner elements
                if ((currentRow == row - 1 && currentCol == col - 1) ||
                    (currentRow == row + 1 && currentCol == col + 1) ||
                    (currentRow == row - 1 && currentCol == col + 1) ||
                    (currentRow == row + 1 && currentCol == col - 1))
                {
                    continue;
                }

                if (visited[currentRow, currentCol])
                {
                    continue;
                }

                if (matrix[row, col] == matrix[currentRow, currentCol])
                {
                    count = CheckCount(matrix, visited, currentRow, currentCol, count);
                }
            }
        }

        return count + 1;
    }
}