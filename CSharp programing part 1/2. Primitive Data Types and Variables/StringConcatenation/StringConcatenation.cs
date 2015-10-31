using System;

    class StringConcatenation
    {
        static void Main()
        {
            string hello = "Hello";
            string world = "World";
            string concatenatedString = "";

            object helloWorldObject = new object();

            helloWorldObject = hello + " " + world;

            concatenatedString = (string)helloWorldObject;

            Console.WriteLine(concatenatedString);
        }
    }