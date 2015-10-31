using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

class NFactorial
{
    static void Main()
    {
        Console.Write("Enter N!: ");
        int nFactorial = int.Parse(Console.ReadLine());

        int[] result = Facturial(nFactorial);

        Console.Write("\n{0}! = ", nFactorial);
        PrintArray(result);
    }

    private static int[] Facturial(int nFactorial)
    {
        int[] result = NumberAsIntArray(nFactorial);

        while (nFactorial > 1)
        {
            int[] next = NumberAsIntArray(nFactorial - 1);

            //PrintArray(result);
            //PrintArray(next);

            result =  MultipliesNumberAsArray(result, next);

            nFactorial--;
        }

        return result;
    }

    private static int[] MultipliesNumberAsArray(int[] first, int[] second)
    {
        StringBuilder firstStr = new StringBuilder();
        StringBuilder secondStr = new StringBuilder();

        for (int i = 0; i < first.Length; i++)
        {
            firstStr.Append(first[i].ToString());
        }

        for (int i = 0; i < second.Length; i++)
        {
            secondStr.Append(second[i].ToString());
        }

        BigInteger numberOne = BigInteger.Parse(firstStr.ToString());
        BigInteger numberTwo = BigInteger.Parse(secondStr.ToString());

        BigInteger multipliesNumber = numberOne * numberTwo;

        string multipliesStr = Convert.ToString(multipliesNumber);

        int[] result = new int[multipliesStr.Length];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = int.Parse(multipliesStr[i].ToString());
        }

        return result;
    }

    private static int[] NumberAsIntArray(int nFactorial)
    {
        string strNumber = nFactorial.ToString();
        int[] result = new int[strNumber.Length];

        for (int i = 0; i < strNumber.Length; i++)
        {
            result[i] = int.Parse(strNumber[i].ToString());
        }
        
        return result;
    }

    private static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
        }

        Console.WriteLine();
    }
}