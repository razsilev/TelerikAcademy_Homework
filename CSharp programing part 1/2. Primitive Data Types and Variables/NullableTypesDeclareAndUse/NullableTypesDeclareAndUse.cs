using System;

class NullableTypesDeclareAndUse
{
    static void Main()
    {
        int? nullableInt = 5;
        double? nullableDouble = 7.6;

        Console.WriteLine(nullableInt);
        Console.WriteLine(nullableDouble);

        Console.WriteLine(new string('-', 50));

        nullableInt = null;
        nullableDouble = null;

        Console.WriteLine(nullableInt);
        Console.WriteLine(nullableDouble);

        Console.WriteLine(new string('-', 50));

        Console.WriteLine(nullableInt.GetValueOrDefault());
        Console.WriteLine(nullableDouble.GetValueOrDefault());

        Console.WriteLine(new string('-', 50));
    }
}