using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGenericMatrix
{
    class MyGenericMatrix
    {
        static void Main()
        {
            int[,] firstTwoDimentionalArray = new int[,]
                                      {
                                        {4, 6},
                                        {8, 5}
                                      };

            int[,] secondTwoDimentionalArray = new int[,]
                                      {
                                        {6, 4},
                                        {2, 5}
                                      };

            Matrix<int> firstMatrix = new Matrix<int>(firstTwoDimentionalArray);
            Matrix<int> secondMatrix = new Matrix<int>(secondTwoDimentionalArray);

            Console.WriteLine("first matrix content: \n{0}", firstMatrix);
            Console.WriteLine("\nsecond matrix content: \n{0}", secondMatrix);

            secondMatrix[1, 1] = 0;

            Console.WriteLine("\nSet in second matrix position [1, 1] = 0;");
            Console.WriteLine("second matrix content: \n{0}", secondMatrix);
            
            Console.WriteLine("\nContent on row 0 col 1 in second matrix is: {0}", secondMatrix[0, 1]);

            Console.WriteLine("\nFirst matrix * second matrix: \n{0}", firstMatrix * secondMatrix);

            Console.WriteLine("\nFirst matrix - second matrix: \n{0}", firstMatrix - secondMatrix);

            Console.WriteLine("\nmatrix sum: \n{0}", firstMatrix + secondMatrix);

            Matrix<int> thirdMatrix = new Matrix<int>(new int[,]
                                                        {
                                                        {0, 0}, 
                                                        {0, 0}
                                                        });

            Console.WriteLine("\nIs thirdMatrix have values diferent then ZERO? -> {0}", thirdMatrix ? "Yes" : "No");
            Console.WriteLine("\nthirdMatrix content: \n{0}\n", thirdMatrix);
        }
    }
}
