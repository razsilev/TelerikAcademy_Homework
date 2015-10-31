using System;
using System.Linq;
using System.Diagnostics;

class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array can not be null.");
        Debug.Assert(arr.Length > 0, "Given array can not be empty.");

        for (int index = 0; index < arr.Length-1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }
  
    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array can not be null.");
        Debug.Assert(arr.Length > 0, "Given array can not be empty.");
        Debug.Assert(0 <= startIndex && startIndex < arr.Length, "startIndex is outside of boundary of the array.");
        Debug.Assert(0 <= endIndex && endIndex < arr.Length, "endIndex is outside of boundary of the array.");
        Debug.Assert(startIndex <= endIndex, "endIndex can not be less then startIndex.");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        Debug.Assert(startIndex <= minElementIndex && minElementIndex <= endIndex, "Invalid minElementIndex.");

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array can not be null.");
        Debug.Assert(arr.Length > 0, "Given array can not be empty.");
        Debug.Assert(value != null, "searched value can not be null.");

        int index = BinarySearch(arr, value, 0, arr.Length - 1);

        Debug.Assert(index < arr.Length, "Invalid element index.");

        return index;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array can not be null.");
        Debug.Assert(arr.Length > 0, "Given array can not be empty.");
        Debug.Assert(0 <= startIndex && startIndex < arr.Length, "startIndex is outside of boundary of the array.");
        Debug.Assert(0 <= endIndex && endIndex < arr.Length, "endIndex is outside of boundary of the array.");
        Debug.Assert(startIndex <= endIndex, "endIndex can not be less then startIndex.");
        Debug.Assert(value != null, "searched value can not be null.");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                Debug.Assert(startIndex <= midIndex && midIndex <= endIndex, "Invalid midIndex.");

                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the left half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        // Test sorting null array
        var nullArr = new int[1];
        nullArr = null;
        SelectionSort(nullArr);

        // Test sorting empty array
        SelectionSort(new int[0]);
        
        // Test sorting single element array
        int[] singleElementArray = new int[1];
        SelectionSort(singleElementArray);

        // Test search in array null value
        Console.WriteLine(BinarySearch(new string[1], null));

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
