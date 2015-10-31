using System;

namespace _6.MatrixClass
{
    class ClassMatrixUse
    {
        static void Main()
        {
            int[,] first = {
                                {3, 2}, 
                                {0, 1},
                                {2, 5}
                           };
            int[,] second = {
                                {2, 1}, 
                                {1, 1} 
                            };
            int[,] third = {
                                {4, 5}, 
                                {0, 3},
                                {8, 1}
                           };

            Matrix matrix1 = new Matrix(first);
            Console.WriteLine("matrix1 content:");
            matrix1.PrintMatrix();

            Matrix matrix2 = new Matrix(second);
            Console.WriteLine("matrix2 content:");
            matrix2.PrintMatrix();

            Matrix matrix3 = new Matrix(third);
            Console.WriteLine("matrix3 content:");
            matrix3.PrintMatrix();

            Matrix multiplaedMatrix = matrix1 * matrix2;
            Console.WriteLine(" matrix1 * matrix2 = multiplaed Matrix content:");
            multiplaedMatrix.PrintMatrix();

            Matrix addedMatrix = matrix1 + matrix3;
            Console.WriteLine(" matrix1 + matrix3 = added Matrix content:");
            addedMatrix.PrintMatrix();

            Matrix subtractedMatrix = matrix3 - matrix1;
            Console.WriteLine(" matrix3 - matrix1 = subtracted Matrix content:");
            subtractedMatrix.PrintMatrix();

            // call ToString() override method on class Matrix
            Console.WriteLine(matrix1);
            Console.WriteLine();
        }
        
    }
}
