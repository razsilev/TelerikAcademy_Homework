using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PerformanceTests
{
    public class PerformanceTests
    {
        static void Main()
        {
            // Task 2
            // Write a program to compare the performance of
            // add, subtract, increment, multiply, divide for
            // int, long, float, double and decimal values.
            Console.WriteLine("---------- Task 2 ---------");
            SolveTaskTwo();

            // TASK 3
            // Write a program to compare the performance of
            // square root, natural logarithm, sinus for
            // float, double and decimal values.
            Console.WriteLine("---------- Task 3 ---------");
            SolveTaskThree();
        }

        private static void SolveTaskTwo()
        {
            string[] times = null;
            int iterations = 100100;

            // Add
            times = TestAdd(iterations);
            Console.WriteLine(" Add               time");
            Print(times);

            // Substract
            times = TestSubstract(iterations);
            Console.WriteLine(" Substract         time");
            Print(times);

            // Increment
            times = TestIncrement(iterations);
            Console.WriteLine(" Increment         time");
            Print(times);

            // Multiply
            times = TestMultiply(iterations);
            Console.WriteLine(" Multiply          time");
            Print(times);

            // Divide
            times = TestDivide(iterations);
            Console.WriteLine(" Divide            time");
            Print(times);
        }

        private static void Print(string[] arr)
        {
            Debug.Assert(arr.Length >= 5, "Mising performance result result");
            if (arr.Length < 5)
            {
                throw new ArgumentOutOfRangeException("Mising performance result result");
            }

            Console.WriteLine("int:       " + arr[0]);
            Console.WriteLine("long:      " + arr[1]);
            Console.WriteLine("float:     " + arr[2]);
            Console.WriteLine("double:    " + arr[3]);
            Console.WriteLine("decimal:   " + arr[4]);
            Console.WriteLine();
        }

        private static string[] TestAdd(int numberOfIterations)
        {
            string[] results = new string[5];
            Stopwatch stopwatch = new Stopwatch();
            int intAddNumber = 954676;
            long longAddNumber = intAddNumber;
            float floatAddNumber = intAddNumber;
            double doubleAddNumber = intAddNumber;
            decimal decimalAddNumber = intAddNumber;

            // int
            int intAdd = 0;
            stopwatch.Start();
            for (int i = 0; i < numberOfIterations; i++)
            {
                intAdd = i + intAddNumber;
            }

            stopwatch.Stop();
            results[0] = stopwatch.Elapsed.ToString();

            // long
            long longAdd = 0;
            stopwatch.Restart();
            for (long i = 0; i < numberOfIterations; i++)
            {
                longAdd = i + longAddNumber;
            }

            stopwatch.Stop();
            results[1] = stopwatch.Elapsed.ToString();

            // float
            float floatAdd = 0;
            stopwatch.Restart();
            for (float i = 0; i < numberOfIterations; i++)
            {
                floatAdd = i + floatAddNumber;
            }

            stopwatch.Stop();
            results[2] = stopwatch.Elapsed.ToString();

            // double
            double doubleAdd = 0;
            stopwatch.Restart();
            for (double i = 0; i < numberOfIterations; i++)
            {
                doubleAdd = i + doubleAddNumber;
            }

            stopwatch.Stop();
            results[3] = stopwatch.Elapsed.ToString();

            // decimal
            decimal decimalAdd = 0;
            stopwatch.Restart();
            for (decimal i = 0; i < numberOfIterations; i++)
            {
                decimalAdd = i + decimalAddNumber;
            }

            stopwatch.Stop();
            results[4] = stopwatch.Elapsed.ToString();

            return results;
        }

        private static string[] TestSubstract(int numberOfIterations)
        {
            List<string> results = new List<string>(5);
            Stopwatch stopwatch = new Stopwatch();
            int number = 2096481543;
            long longNumber = number;
            float floatNumber = number;
            double doubleNumber = number;
            decimal decimalNumber = number;

            // int
            int intResult = 0;
            stopwatch.Start();
            for (int i = 0; i < numberOfIterations; i++)
            {
                intResult = number - i;
            }

            stopwatch.Stop();
            results.Add(stopwatch.Elapsed.ToString());

            // long
            long longResult = 0;
            stopwatch.Restart();
            for (long i = 0; i < numberOfIterations; i++)
            {
                longResult = longNumber - i;
            }

            stopwatch.Stop();
            results.Add(stopwatch.Elapsed.ToString());

            // float
            float floatResult = 0;
            stopwatch.Restart();
            for (float i = 0; i < numberOfIterations; i++)
            {
                floatResult = floatNumber - i;
            }

            stopwatch.Stop();
            results.Add(stopwatch.Elapsed.ToString());

            // double
            double doubleResult = 0;
            stopwatch.Restart();
            for (double i = 0; i < numberOfIterations; i++)
            {
                doubleResult = doubleNumber - i;
            }

            stopwatch.Stop();
            results.Add(stopwatch.Elapsed.ToString());

            // decimal
            decimal decimalResult = 0;
            stopwatch.Restart();
            for (decimal i = 0; i < numberOfIterations; i++)
            {
                decimalResult = decimalNumber - i;
            }

            stopwatch.Stop();
            results.Add(stopwatch.Elapsed.ToString());

            return results.ToArray();
        }

        private static string[] TestIncrement(int numberOfIterations)
        {
            string[] results = new string[5];
            Stopwatch stopwatch = new Stopwatch();
            int increment = 2;
            long longNumber = increment;
            float floatNumber = increment;
            double doubleNumber = increment;
            decimal decimalNumber = increment;

            // int
            int intAdd = 0;
            stopwatch.Start();
            for (int i = 0; i < numberOfIterations; i++)
            {
                intAdd += increment;
            }

            stopwatch.Stop();
            results[0] = stopwatch.Elapsed.ToString();

            // long
            long longAdd = 0;
            stopwatch.Restart();
            for (int i = 0; i < numberOfIterations; i++)
            {
                longAdd += longNumber;
            }

            stopwatch.Stop();
            results[1] = stopwatch.Elapsed.ToString();

            // float
            float floatAdd = 0;
            stopwatch.Restart();
            for (int i = 0; i < numberOfIterations; i++)
            {
                floatAdd += floatNumber;
            }

            stopwatch.Stop();
            results[2] = stopwatch.Elapsed.ToString();

            // double
            double doubleAdd = 0;
            stopwatch.Restart();
            for (int i = 0; i < numberOfIterations; i++)
            {
                doubleAdd += doubleNumber;
            }

            stopwatch.Stop();
            results[3] = stopwatch.Elapsed.ToString();

            // decimal
            decimal decimalAdd = 0;
            stopwatch.Restart();
            for (int i = 0; i < numberOfIterations; i++)
            {
                decimalAdd += decimalNumber;
            }

            stopwatch.Stop();
            results[4] = stopwatch.Elapsed.ToString();

            return results;
        }

        private static string[] TestMultiply(int numberOfIterations)
        {
            List<string> results = new List<string>(5);
            Stopwatch stopwatch = new Stopwatch();
            int multiply = 3;
            long longNumber = multiply;
            float floatNumber = multiply;
            double doubleNumber = multiply;
            decimal decimalNumber = multiply;

            // int
            int intAdd = 0;
            stopwatch.Start();
            for (int i = 0; i < numberOfIterations; i++)
            {
                intAdd = i * multiply;
            }

            stopwatch.Stop();
            results.Add(stopwatch.Elapsed.ToString());

            // long
            long longAdd = 0;
            stopwatch.Restart();
            for (long i = 0; i < numberOfIterations; i++)
            {
                longAdd = i * longNumber;
            }

            stopwatch.Stop();
            results.Add(stopwatch.Elapsed.ToString());

            // float
            float floatAdd = 0;
            stopwatch.Restart();
            for (float i = 0; i < numberOfIterations; i++)
            {
                floatAdd = i * floatNumber;
            }

            stopwatch.Stop();
            results.Add(stopwatch.Elapsed.ToString());

            // double
            double doubleAdd = 0;
            stopwatch.Restart();
            for (double i = 0; i < numberOfIterations; i++)
            {
                doubleAdd = i * doubleNumber;
            }

            stopwatch.Stop();
            results.Add(stopwatch.Elapsed.ToString());

            // decimal
            decimal decimalAdd = 0;
            stopwatch.Restart();
            for (decimal i = 0; i < numberOfIterations; i++)
            {
                decimalAdd = i * decimalNumber;
            }

            stopwatch.Stop();
            results.Add(stopwatch.Elapsed.ToString());

            return results.ToArray();
        }

        private static string[] TestDivide(int numberOfIterations)
        {
            List<string> results = new List<string>(5);
            Stopwatch stopwatch = new Stopwatch();
            int number = 130954676;
            long longNumber = number;
            float floatNumber = number;
            double doubleNumber = number;
            decimal decimalNumber = number;

            // int
            int intAdd = 0;
            stopwatch.Start();
            for (int i = 1; i < numberOfIterations; i++)
            {
                intAdd = number / i;
            }

            stopwatch.Stop();
            results.Add(stopwatch.Elapsed.ToString());

            // long
            long longAdd = 0;
            stopwatch.Restart();
            for (int i = 1; i < numberOfIterations; i++)
            {
                longAdd = longNumber / i;
            }

            stopwatch.Stop();
            results.Add(stopwatch.Elapsed.ToString());

            // float
            float floatAdd = 0;
            stopwatch.Restart();
            for (int i = 1; i < numberOfIterations; i++)
            {
                floatAdd = floatNumber / i;
            }

            stopwatch.Stop();
            results.Add(stopwatch.Elapsed.ToString());

            // double
            double doubleAdd = 0;
            stopwatch.Restart();
            for (int i = 1; i < numberOfIterations; i++)
            {
                doubleAdd = doubleNumber / i;
            }

            stopwatch.Stop();
            results.Add(stopwatch.Elapsed.ToString());

            // decimal
            decimal decimalAdd = 0;
            stopwatch.Restart();
            for (int i = 1; i < numberOfIterations; i++)
            {
                decimalAdd = decimalNumber / i;
            }

            stopwatch.Stop();
            results.Add(stopwatch.Elapsed.ToString());

            return results.ToArray();
        }

        private static void SolveTaskThree()
        {
            string[] times = null;
            int iterations = 1000;

            // Add
            times = TestSquareRoot(iterations);
            Console.WriteLine(" square root          time");
            PrintTaskTwo(times);

            // Substract
            times = TestNaturalLogarithm(iterations);
            Console.WriteLine(" natural logarithm    time");
            PrintTaskTwo(times);

            // Increment
            times = TestSinus(iterations);
            Console.WriteLine(" sinus              time");
            PrintTaskTwo(times);
        }

        private static void PrintTaskTwo(string[] arr)
        {
            Debug.Assert(arr.Length >= 3, "Mising performance result result");
            if (arr.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Mising performance result result");
            }

            Console.WriteLine("float:     " + arr[0]);
            Console.WriteLine("double:    " + arr[1]);
            Console.WriteLine("decimal:   " + arr[2]);
            Console.WriteLine();
        }

        private static string[] TestSquareRoot(int numberOfIterations)
        {
            string[] results = new string[3];
            Stopwatch stopwatch = new Stopwatch();

            // float
            float floatAdd = 0;
            stopwatch.Start();
            for (float i = 0; i < numberOfIterations; i++)
            {
                floatAdd = (float)Math.Sqrt(i);
            }

            stopwatch.Stop();
            results[0] = stopwatch.Elapsed.ToString();

            // double
            double doubleAdd = 0;
            stopwatch.Restart();
            for (double i = 0; i < numberOfIterations; i++)
            {
                doubleAdd = Math.Sqrt(i);
            }

            stopwatch.Stop();
            results[1] = stopwatch.Elapsed.ToString();

            // decimal
            decimal decimalAdd = 0;
            stopwatch.Restart();
            for (decimal i = 0; i < numberOfIterations; i++)
            {
                decimalAdd = (decimal)Math.Sqrt((double)i);
            }

            stopwatch.Stop();
            results[2] = stopwatch.Elapsed.ToString();

            return results;
        }

        private static string[] TestNaturalLogarithm(int numberOfIterations)
        {
            string[] results = new string[3];
            Stopwatch stopwatch = new Stopwatch();

            // float
            float floatAdd = 0;
            stopwatch.Start();
            for (float i = 0; i < numberOfIterations; i++)
            {
                floatAdd = (float)Math.Log(i);
            }

            stopwatch.Stop();
            results[0] = stopwatch.Elapsed.ToString();

            // double
            double doubleAdd = 0;
            stopwatch.Restart();
            for (double i = 0; i < numberOfIterations; i++)
            {
                doubleAdd = Math.Log(i);
            }

            stopwatch.Stop();
            results[1] = stopwatch.Elapsed.ToString();

            // decimal
            decimal decimalAdd = 0;
            stopwatch.Restart();
            for (decimal i = 1; i < numberOfIterations; i++)
            {
                decimalAdd = (decimal)Math.Log((double)i);
            }

            stopwatch.Stop();
            results[2] = stopwatch.Elapsed.ToString();

            return results;
        }

        private static string[] TestSinus(int numberOfIterations)
        {
            string[] results = new string[3];
            Stopwatch stopwatch = new Stopwatch();

            // float
            float floatAdd = 0;
            stopwatch.Start();
            for (float i = 0; i < numberOfIterations; i++)
            {
                floatAdd = (float)Math.Sin((i * Math.PI) / 180);
            }

            stopwatch.Stop();
            results[0] = stopwatch.Elapsed.ToString();

            // double
            double doubleAdd = 0;
            stopwatch.Restart();
            for (int i = 0; i < numberOfIterations; i++)
            {
                doubleAdd = Math.Sin((i * Math.PI) / 180);
            }

            stopwatch.Stop();
            results[1] = stopwatch.Elapsed.ToString();

            // decimal
            decimal decimalAdd = 0;
            stopwatch.Restart();
            for (decimal i = 0; i < numberOfIterations; i++)
            {
                decimalAdd = (decimal)Math.Sin(((double)i * Math.PI) / 180);
            }

            stopwatch.Stop();
            results[2] = stopwatch.Elapsed.ToString();

            return results;
        }
    }
}