using System;

namespace PersonTest
{
    class PersonTest
    {
        static void Main()
        {
            Person pepi = new Person("Pepi", 29);
            Person mimi = new Person("Mimi");

            Console.WriteLine(pepi);
            Console.WriteLine(mimi);
        }
    }
}
