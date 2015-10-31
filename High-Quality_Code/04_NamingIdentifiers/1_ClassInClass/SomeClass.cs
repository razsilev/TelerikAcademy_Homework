namespace _1_ClassInClass
{
    using System;

    public class SomeClass
    {
        private const int MAX_COUNT = 6;

        public static void Main()
        {
            SomeClass.ConsoleWriter writer = new SomeClass.ConsoleWriter();

            writer.Print(true);
        }

        public class ConsoleWriter
        {
            public void Print(bool value)
            {
                string str = value.ToString();

                Console.WriteLine(str);
            }
        }
    }
}
