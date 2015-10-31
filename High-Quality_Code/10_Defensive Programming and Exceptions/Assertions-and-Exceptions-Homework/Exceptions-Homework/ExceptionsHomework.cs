using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null)
        {
            throw new ArgumentNullException("given array can not be null.");
        }

        if (arr.Length == 0)
        {
            throw new ArgumentOutOfRangeException("given array can not be empty.");
        }

        if (!(0 <= startIndex && startIndex < arr.Length))
        {
            throw new ArgumentOutOfRangeException("start index is outside of boundary of the array.");
        }

        if (count <= 0)
        {
            throw new ArgumentOutOfRangeException("Count can not be less then or equal to zero.");
        }

        if ((startIndex + count) > arr.Length)
        {
            throw new ArgumentOutOfRangeException("Count is too bigger, array does not have enough elements.");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (str == null)
        {
            throw new ArgumentNullException("given string can not be null.");
        }

        if (str.Length == 0)
        {
            throw new ArgumentOutOfRangeException("given string can not be empty.");
        }

        if (count > str.Length)
        {
            //throw new ArgumentOutOfRangeException("Invalid count! Count can not be bigger then string length.");

            count = str.Length;
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        if (number < 1)
        {
            return false;
        }

        bool isPrime = true;

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                isPrime = false;
                break;
            }
        }

        return isPrime;
    }

    static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

//      var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
//      Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        Console.WriteLine(ExtractEnding("Hi", 100));

        bool isPrime = CheckPrime(23);
        if (isPrime)
        {
            Console.WriteLine("23 is prime.");
        }
        else
        {
            Console.WriteLine("23 is not prime");
        }

        isPrime = CheckPrime(33);
        if (isPrime)
        {
            Console.WriteLine("33 is prime.");
        }
        else
        {
            Console.WriteLine("33 is not prime");
        }

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
