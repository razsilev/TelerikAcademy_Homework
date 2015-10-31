using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGenericMatrix
{
    public class Matrix<T>
    {
        private T[,] matrix;
        private int rows;
        private int cols;

        public int Rows
        {
            get
            {
                return this.rows;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }
        }

        public Matrix(T[,] matrix)
        {
            this.matrix = matrix;
            this.rows = matrix.GetLength(0);
            this.cols = matrix.GetLength(1);
        }

        public T this[int row, int col]
        {
            get
            {
                if (IsValidIndexes(row, col))
                {
                    return this.matrix[row, col];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is outside of bounds of the matrix.");
                }
            }

            set
            {
                if (IsValidIndexes(row, col))
                {
                    this.matrix[row, col] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is outside of bounds of the matrix.");
                }
            }
        }

        private bool IsValidIndexes(int row, int col)
        {
            if (row >= 0 && row < this.rows &&
                col >= 0 && col < this.cols)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.rows == second.Rows && first.Cols == second.Cols)
            {
                T[,] result = new T[first.Cols, first.Cols];

                for (int row = 0; row < result.GetLength(0); row++)
                {
                    for (int col = 0; col < result.GetLength(1); col++)
                    {
                        checked
                        {
                            result[row, col] = (dynamic)first[row, col] + (dynamic)second[row, col];
                        }
                    }
                }

                return new Matrix<T>(result);
            }
            else
            {
                throw new ArgumentException("Matrix does not have equal dimentions.");
            }
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows == second.Rows && first.Cols == second.Cols)
            {
                T[,] result = new T[first.Cols, first.Cols];

                for (int row = 0; row < result.GetLength(0); row++)
                {
                    for (int col = 0; col < result.GetLength(1); col++)
                    {
                        checked
                        {
                            result[row, col] = (dynamic)first[row, col] - (dynamic)second[row, col];
                        }
                    }
                }

                return new Matrix<T>(result);
            }
            else
            {
                throw new ArgumentException("Matrix does not have equal dimentions.");
            }
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first.Cols != second.Rows)
            {
                throw new ArgumentException("Matrix who want to multiplying have invalid dimensions!");
            }

            Matrix<T> result = new Matrix<T>(new T[first.Rows, second.Cols]);

            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    dynamic sum = 0;
                    for (int index = 0; index < first.Cols; index++)
                    {
                        checked
                        {
                            sum += (dynamic)first[row, index] * (dynamic)second[index, col];
                        }
                    }

                    result[row, col] = sum;
                }
            }

            return result;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.rows; row++)
			{
                for (int col = 0; col < matrix.cols; col++)
                {
                    if ((dynamic)matrix[row, col] != 0)
                    {
                        return true;
                    }
                }
			}

            return false;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.rows; row++)
            {
                for (int col = 0; col < matrix.cols; col++)
                {
                    if ((dynamic)matrix[row, col] != 0)
                    {
                        return true ;
                    }
                }
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < rows; row++)
            {
                result.AppendFormat("[{0}", this.matrix[row, 0]);

                for (int col = 1; col < cols; col++)
                {
                    result.AppendFormat(", {0}", this.matrix[row, col]);
                }

                result.Append(']');
                result.AppendLine();
            }

            return result.ToString().TrimEnd(); ;
        }
    }
}
