using System;

namespace _6.MatrixClass
{
    class Matrix
    {
        private int[,] matrix;

        public Matrix(int[,] matrix)
        {
            this.matrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    this.matrix[row, col] = matrix[row, col];
                }
            }
        }

        public int this[int rowIndex, int columnIndex]
        {
            get
            {
                return matrix[rowIndex, columnIndex];
            }

            set
            {
                if (rowIndex >= matrix.GetLength(0) ||
                    rowIndex < 0)
                {
                    throw new IndexOutOfRangeException("rowIndex was outside the bounds of the array.");
                }

                if (columnIndex >= matrix.GetLength(1) ||
                    columnIndex < 0)
                {
                    throw new IndexOutOfRangeException("columnIndex was outside the bounds of the array.!");
                }

                matrix[rowIndex, columnIndex] = value;
            }
        }

        public static Matrix operator +(Matrix first, Matrix second)
        {
            if ((first.GetLength(0) != second.GetLength(0)) ||
                (first.GetLength(1) != second.GetLength(1)))
            {
                throw new ArgumentException("Matrix who want to adding have different dimensions!");
            }

            Matrix result = new Matrix(new int[first.GetLength(0), first.GetLength(1)]);

            for (int row = 0; row < result.GetLength(0); row++)
            {
                for (int col = 0; col < result.GetLength(1); col++)
                {
                    checked
                    {
                        result[row, col] = first[row, col] + second[row, col];
                    }
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix first, Matrix second)
        {
            if ((first.GetLength(0) != second.GetLength(0)) ||
                (first.GetLength(1) != second.GetLength(1)))
            {
                throw new ArgumentException("Matrix who want to subtracting have different dimensions!");
            }

            Matrix result = new Matrix(new int[first.GetLength(0), first.GetLength(1)]);

            for (int row = 0; row < result.GetLength(0); row++)
            {
                for (int col = 0; col < result.GetLength(1); col++)
                {
                    checked
                    {
                        result[row, col] = first[row, col] - second[row, col];
                    }
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix first, Matrix second)
        {
            if (first.GetLength(1) != second.GetLength(0))
            {
                throw new ArgumentException("Matrix who want to multiplying have different dimensions!");
            }

            Matrix result = new Matrix(new int[first.GetLength(0), second.GetLength(1)]);

            for (int row = 0; row < result.GetLength(0); row++)
            {
                for (int col = 0; col < result.GetLength(1); col++)
                {
                    int sum = 0;
                    for (int index = 0; index < first.GetLength(1); index++)
                    {
                        checked
                        {
                            sum += first[row, index] * second[index, col];
                        }
                    }

                    result[row, col] = sum;
                }
            }

            return result;
        }

        public void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,2} ", matrix[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public int GetLength(int dimension)
        {
            if (dimension == 0)
            {
                return matrix.GetLength(0);
            }
            else if (dimension == 1)
            {
                return matrix.GetLength(1);
            }

            throw new ArgumentOutOfRangeException();
        }

        public override string ToString()
        {
            return string.Format("You call override method ToString() on class.Matrix");
        }
    }
}
