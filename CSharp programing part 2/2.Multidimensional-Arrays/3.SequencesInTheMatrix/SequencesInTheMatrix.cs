using System;
using System.Collections.Generic;

class SequencesInTheMatrix
{
    static void Main()
    {
        Console.Write("Enter number of columns >= 2: ");
        int columns = int.Parse(Console.ReadLine());

        Console.Write("Enter number of rows >= 2: ");
        int rows = int.Parse(Console.ReadLine());

        if (columns < 2 || rows < 2)
        {
            Console.WriteLine("Error little rows or columns!!!");
            return;
        }

        string[,] matrix = new string[rows, columns];

        FillMatrix(matrix);
        SequencesMaxLength(matrix);
        PrintMatrix(matrix);
    }

    private static void SequencesMaxLength(string[,] matrix)
    {
        Dictionary<int, string> sequences = new Dictionary<int, string>();
        
        string str = "";
        int count = MaxRowLength(matrix, out str);

        sequences.Add(count, str);

        count = MaxColumnLength(matrix, out str);

        if (!sequences.ContainsKey(count))
        {
            sequences.Add(count, str);
        }

        count = HightToLessDiagonal(matrix, out str);

        if (!sequences.ContainsKey(count))
        {
            sequences.Add(count, str);
        }

        count = LessToHightDiagonal(matrix, out str);

        if (!sequences.ContainsKey(count))
        {
            sequences.Add(count, str);
        }

        // find max length sequences
        int max = 0;
        foreach (var item in sequences)
        {
            if (max < item.Key)
            {
                max = item.Key;
            }
        }

        PrintResult(sequences[max], max);
    }

    private static int LessToHightDiagonal(string[,] matrix, out string str)
    {
        int length = matrix.GetLength(0) * matrix.GetLength(1);
        string[] strArray = new string[length];
        int count = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                strArray[count] = matrix[row, col];
                count++;
            }
        }

        str = "";
        count = 0;
        int indexAdd = matrix.GetLength(1) - 1;

        for (int i = 1; i < strArray.Length - 1; i++)
        {
            int currentCount = 1;
            string curentStr = strArray[i];

            for (int col = i + indexAdd; col < strArray.Length - 1; col += indexAdd)
            {
                if (curentStr.Equals(strArray[col]))
                {
                    currentCount++;
                }
                else
                {
                    currentCount = 1;
                    curentStr = strArray[col];
                }

                if (currentCount > count)
                {
                    count = currentCount;
                    str = curentStr;
                }

                if (col % matrix.GetLength(1) == 0)
                {
                    break;
                }
            }
            
        }

        return count;
    }

    private static int HightToLessDiagonal(string[,] matrix, out string str)
    {
        int row = matrix.GetLength(0) - 2;
        int col = 0;
        int maxCount = 0;
        str = "";

        while (col < (matrix.GetLength(1) - 1))
        {
            if (row > 0)
            {
                row--;
            }
            else
            {
                col++;
            }

            string currentStr = "";
            int currentCount = HLDiadonal(matrix, out currentStr, row, col);

            if (maxCount < currentCount)
            {
                maxCount = currentCount;
                str = currentStr;
            }
        }

        return maxCount;
    }

    private static int HLDiadonal(string[,] matrix, out string str, int rowStart, int colStart)
    {
        int max = 0;
        int count = 1;
        str = "";
        string currentStr = matrix[rowStart, colStart];
        rowStart++;
        colStart++;
        
        while ((rowStart < matrix.GetLength(0)) && (colStart < matrix.GetLength(1)))
        {
            if (currentStr.Equals(matrix[rowStart, colStart]))
            {
                count++;
            }
            else
            {
                count = 1;
                currentStr = matrix[rowStart, colStart];
            }

            if (max < count)
            {
                max = count;
                str = currentStr;
            }

            rowStart++;
            colStart++;
        }

        return max;
    }

    private static void PrintResult(string str, int max)
    {
        Console.WriteLine("\nMax sequences is: ");

        for (int i = 0; i < max; i++)
        {
            Console.Write("{0}  ", str);
        }

        Console.WriteLine();
    }

    private static int MaxRowLength(string[,] matrix, out string rowString)
    {
        int lenght = 0;
        rowString = ""; 

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string currentStr = matrix[row, 0];
            int currentLength = 1;

            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                if (currentStr.Equals(matrix[row, col]))
                {
                    currentLength++;
                }
                else
                {
                    currentLength = 1;
                    currentStr = matrix[row, col];
                }

                if (lenght < currentLength)
                {
                    lenght = currentLength;
                    rowString = currentStr;
                }
            }
        }

        return lenght;
    }

    private static int MaxColumnLength(string[,] matrix, out string colString)
    {
        int lenght = 0;
        colString = "";

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            string currentStr = matrix[0, col];
            int currentLength = 1;

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                if (currentStr.Equals(matrix[row, col]))
                {
                    currentLength++;
                }
                else
                {
                    currentLength = 1;
                    currentStr = matrix[row, col];
                }

                if (lenght < currentLength)
                {
                    lenght = currentLength;
                    colString = currentStr;
                }
            }
        }

        return lenght;
    }

    private static void FillMatrix(string[,] matrix)
    {
        Console.WriteLine("\nEnter elements of the matrix.");
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("Enter [{0}][{1}] element: ", row, col);

                matrix[row, col] = Console.ReadLine();
            }
        }
    }

    private static void PrintMatrix(string[,] matrix)
    {
        Console.WriteLine("\nMatrix:");

        for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
        {
            for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
            {
                Console.Write("{0,5} ", matrix[rowIndex, colIndex]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
