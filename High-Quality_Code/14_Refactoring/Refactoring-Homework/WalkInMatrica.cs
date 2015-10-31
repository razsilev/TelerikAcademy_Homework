using GameFifteen;
using System;

namespace Task3
{
    public class WalkInMatrica
    {
        static void ChangeDirection(ref int dx, ref int dy)
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int cd = 0;

            for (int count = 0; count < 8; count++)
            {
                if (directionsX[count] == dx && directionsY[count] == dy)
                {
                    cd = count; break;
                }
            }

            if (cd == 7)
            {
                dx = directionsX[0];
                dy = directionsY[0];
                return;
            }

            dx = directionsX[cd + 1];
            dy = directionsY[cd + 1];
        }

        static bool HasValidPosition(int[,] matrix, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= matrix.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (y + dirY[i] >= matrix.GetLength(0) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (matrix[x + dirX[i], y + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static bool HasPositionWithZeroValue(int[,] matrix, out Position position)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        position = new Position(row, col);
                        return true;
                    }
                }
            }

            position = new Position(0, 0);
            return false;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine( "Enter a positive number " );
            //string input = Console.ReadLine(  );
            //int n = 0;
            //while ( !int.TryParse( input, out n ) || n < 0 || n > 100 )
            //{
            //    Console.WriteLine( "You haven't entered a correct positive number" );
            //    input = Console.ReadLine(  );
            //}
            int n = 6;
            int[,] matrix = new int[n, n];
            int step = n;
            int numberInCell = 1;
            Position start = new Position(0, 0);
            Position d = new Position(1, 1);

            WhileLoop(matrix, ref numberInCell, start, d);

            Position positionWithValueZero = new Position(0, 0);

            bool hasZeroInMatrix = HasPositionWithZeroValue(matrix, out positionWithValueZero);

            if (hasZeroInMatrix)
            {
                numberInCell += 1;
                WhileLoop(matrix, ref numberInCell, positionWithValueZero, d);
            }

            Print(matrix);
        }

        private static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,4}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void WhileLoop(int[,] matrica, ref int numberInCell, Position position, Position d)
        {
            int n = matrica.GetLength(0);
            int row = position.Row;
            int col = position.Column;
            int dx = d.Row;
            int dy = d.Column;

            while (true)
            { //malko e kofti tova uslovie, no break-a raboti 100% : )
                matrica[row, col] = numberInCell;

                if (!HasValidPosition(matrica, row, col))
                {
                    break; // prekusvame ako sme se zadunili
                }

                if (row + dx >= n || row + dx < 0 || col + dy >= n || col + dy < 0 || matrica[row + dx, col + dy] != 0)
                {

                    while ((row + dx >= n || row + dx < 0 || col + dy >= n || col + dy < 0 || matrica[row + dx, col + dy] != 0))
                    {
                        ChangeDirection(ref dx, ref dy);
                    }
                }

                row += dx;
                col += dy;
                numberInCell++;
            }
        }
    }
}
