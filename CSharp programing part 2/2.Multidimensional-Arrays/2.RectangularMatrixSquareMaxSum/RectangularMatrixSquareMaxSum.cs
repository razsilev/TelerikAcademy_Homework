using System;

class RectangularMatrixSquareMaxSum
{
    static void Main()
    {
        Console.Write("Enter number of columns > 2: ");
        int columns = int.Parse(Console.ReadLine());

        Console.Write("Enter number of rows > 2: ");
        int rows = int.Parse(Console.ReadLine());

        if (columns < 3 || rows < 3)
        {
            Console.WriteLine("Error little rows or columns!!!");
            return;
        }

        int[,] matrix = new int[rows, columns];

        FillMatrix(matrix);
        ShowSquareWhitMaxSum(matrix);
        PrintMatrix(matrix);
    }

    private static void ShowSquareWhitMaxSum(int[,] matrix)
    {
        long maxSum = 0;
        int squareStartRow = 0;
        int squareStartCol = 0;
        int correction = 2;

        for (int row = 0; row < matrix.GetLength(0) - correction; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - correction; col++)
            {
                long curentSum = CalculateSruareSum(matrix, row, col);

                if (curentSum > maxSum)
                {
                    maxSum = curentSum;
                    squareStartRow = row;
                    squareStartCol = col;
                }
            }
        }

        Console.WriteLine("\nSquare:");
        Console.WriteLine("Max sum is: {0}", maxSum);
        PrintSquare(matrix, squareStartRow, squareStartCol);
    }

    private static void PrintSquare(int[,] matrix, int row, int col)
    {
        int squareLength = 3;

        for (int rowIndex = row; rowIndex < (row + squareLength); rowIndex++)
        {
            for (int colIndex = col; colIndex < (col + squareLength); colIndex++)
            {
                Console.Write("{0,3} ", matrix[rowIndex, colIndex]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    private static long CalculateSruareSum(int[,] matrix, int row, int col)
    {
        long sum = 0;
        int squareLength = 3;

        for (int rowIndex = row; rowIndex < (row + squareLength); rowIndex++)
        {
            for (int colIndex = col; colIndex < (col + squareLength); colIndex++)
            {
                sum += matrix[rowIndex, colIndex];
            }
        }

        return sum;
    }

    private static void FillMatrix(int[,] matrix)
    {
        Console.WriteLine("Enter elements of the matrix.");
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("Enter [{0}][{1}] element: ", row, col);

                matrix[row, col] = int.Parse(Console.ReadLine());
            }
        }
    }

    private static void PrintMatrix(int[,] matrix)
    {
        Console.WriteLine("Matrix:");

        for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
        {
            for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
            {
                Console.Write("{0,3} ", matrix[rowIndex, colIndex]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}