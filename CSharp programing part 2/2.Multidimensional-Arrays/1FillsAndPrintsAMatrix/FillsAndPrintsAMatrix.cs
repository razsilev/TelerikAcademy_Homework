using System;

class FillsAndPrintsAMatrix
{
    static void Main()
    {
        Console.Write("Please Enter matrix Length N: ");
        int length = int.Parse(Console.ReadLine());

        Console.WriteLine("\nShow matrix a)");
        ShowMatrixA(length);

        Console.WriteLine("\nShow matrix b)");
        ShowMatrixB(length);

        Console.WriteLine("\nShow matrix c)");
        ShowMatrixC(length);

        Console.WriteLine("\nShow matrix d)");
        ShowMatrixD(length);
    }

    private static void ShowMatrixA(int length)
    {
        int[,] matrix = new int[length, length];
        int count = 1;

        for (int column = 0; column < matrix.GetLength(0); column++)
        {
            for (int row = 0; row < matrix.GetLength(1); row++)
            {
                matrix[row, column] = count;
                count++;
            }
        }

        PrintMatrix(matrix);
    }

    private static void ShowMatrixB(int length)
    {
        int[,] matrix = new int[length, length];
        int count = 1;

        for (int column = 0; column < matrix.GetLength(0); column++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (column % 2 == 0)
                {
                    matrix[j, column] = count;
                    count++;
                }
                else
                {
                    int row = matrix.GetLength(1) - j - 1;
                    matrix[row, column] = count;
                    count++;
                }
            }
        }

        PrintMatrix(matrix);
    }

    private static void ShowMatrixC(int length)
    {
        int[,] matrix = new int[length, length];
        int count = 1;
        int lastStep = length * 2; // number of backslash
        int row = length - 1;
        int col = 0;

        for (int step = 1; step < lastStep; step++)
        {
            int currentRow = row;
            int currentCol = col;

            while ((currentRow < length) && (currentCol < length))
            {
                matrix[currentRow, currentCol] = count;
                count++;
                currentRow++;
                currentCol++;
            }

            if (row > 0)
            {
                row--;
            }
            else
            {
                col++;
            }

        }

        PrintMatrix(matrix);

    }

    private static void ShowMatrixD(int length)
    {
        int[,] matrix = new int[length, length];
        int count = 1;
        int lastStep = length * 2; // number of backslash
        int row = 0;
        int col = 0;

        string direction = "down";

        while (true)
        {
            if (direction == "down" && (row == length || matrix[row, col] != 0))
            {
                direction = "right";
                row--;
                col++;
            }
            if (direction == "right" && (col == length || matrix[row, col] != 0))
            {
                direction = "up";
                row--;
                col--;
            }
            if (direction == "up" && (row == -1 || matrix[row, col] != 0))
            {
                direction = "left";
                row++;
                col--;
            }
            if (direction == "left" && (col == -1 || matrix[row, col] != 0))
            {
                direction = "down";
                row++;
                col++;
            }

            if (matrix[row, col] != 0)
            {
                break;
            }

            matrix[row, col] = count;
            count++;

            if (direction == "down")
            {
                row++;
            }
            else if (direction == "right")
            {
                col++;
            }
            else if (direction == "up")
            {
                row--;
            }
            else if (direction == "left")
            {
                col--;
            }
        }

        PrintMatrix(matrix);

    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                Console.Write("{0,3} ", matrix[row, column]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}