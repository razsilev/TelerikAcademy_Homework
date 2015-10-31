using System;

class MatrixSpiral
{
    static void Main()
    {
        Console.Write("Enter N for spiral matrix:\n\n N: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int count = 1;
        int k = 0;
        int row;
        int col;

        Console.WriteLine();
        while (n > (n / 2))
        {
            for (int i = k; i < n + k; i++)
            {
                row = k;
                col = i;
                matrix[row, col] = count++;
            }

            for (int i = 1 + k; i < n + k; i++)
            {
                row = i;
                col = n - 1 + k;
                matrix[row, col] = count++;
            }

            for (int i = n - 2 + k; i >= k; i--)
            {
                row = n - 1 + k;
                col = i;
                matrix[row, col] = count++;
            }

            for (int i = n - 2 + k; i > k; i--)
            {
                row = i;
                col = k;
                matrix[row, col] = count++;
            }

            k++;
            n -= 2;
        }

        PaintMatrix(matrix);
        Console.WriteLine();
    }

    static void PaintMatrix(int[,] result)
    {
        int totalWidth = (result.Length - 1).ToString().Length + 1;

        for (int row = 0; row < result.GetLength(0); row++)
        {
            for (int col = 0; col < result.GetLength(1); col++)
            {
                Console.Write(result[row, col].ToString().PadLeft(totalWidth, ' '));
            }
            Console.WriteLine();
        }
    }
}