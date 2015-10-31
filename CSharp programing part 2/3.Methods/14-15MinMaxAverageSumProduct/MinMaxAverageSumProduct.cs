using System;

class MinMaxAverageProductSum
{
    static T Min<T>(params T[] array)
    {
        dynamic min = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            if (min > array[i])
            {
                min = array[i];
            }
        }

        return min;
    }

    static T Max<T>(params T[] array)
    {
        dynamic max = array[0];

        for (int i = 0; i < array.Length; i++)
        {
            if (max < array[i])
            {
                max = array[i];
            }
        }

        return max;
    }

    static T Average<T>(params T[] array)
    {
        dynamic sum = 0;

        foreach (T element in array)
        {
            sum += element;
        }

        return sum / array.Length;
    }

    static T Sum<T>(params T[] array)
    {
        dynamic sum = 0;

        foreach (T element in array)
        {
            sum += element;
        }

        return sum;
    }

    static T Product<T>(params T[] array)
    {
        dynamic result = 1;

        for (int i = 0; i < array.Length; i++)
        {
            result *= array[i];
        }

        return result;
    }

    static void Main()
    {
        int[] arrayInt = { 1, 2, 3, 4, 0 };

        int min = Min(arrayInt);
        int max = Max(arrayInt);
        decimal average = Average(4.28m, 6.6m, 4m);
        float sum = Sum(3.55f, 2.35f, 5.13f);
        int product = Product(1, 2, 3, 4);

        Console.WriteLine("The min number is: {0}", min);
        Console.WriteLine("The max number is: {0}", max);
        Console.WriteLine("The average number is: {0}", average);
        Console.WriteLine("The sum of numbers is: {0}", sum);
        Console.WriteLine("The product is: {0}", product);
    }
}