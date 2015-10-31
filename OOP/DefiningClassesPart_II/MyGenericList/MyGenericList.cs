using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGenericList
{
    class MyGenericList
    {
        static void Main(string[] args)
        {
            GenericList<string> list = new GenericList<string>();

            list.Add("1");
            list.Add("Pesho");

            Console.WriteLine("Start content: {0}", list);

            list.RemoveAt(0);

            Console.WriteLine("\nContent after remove element on index 0 \n{0}", list);

            list.Insert(0, "zero");
            list.Insert(1, "JAVA");

            Console.WriteLine("\nContent after insert on position 0 \"zero\" and 1 \"JAVA\":");
            Console.WriteLine(list);

            string item = "JAVA";
            Console.WriteLine("\nindex of \"{0}\" is: {1}\n", item, list.Find(item));

            Console.WriteLine("In GenericList objects use method ToString();\n{0}", list);

            list.Clear();
            Console.WriteLine("\nList content after clear: \n{0}", list);

            // Test auto-grow functionality
            GenericList<char> autoGrowTestList = new GenericList<char>(2);
            autoGrowTestList.Add('a');
            autoGrowTestList.Add('b');

            Console.WriteLine("\nnew list capacity: {0}", autoGrowTestList.Capacity);
            Console.WriteLine("content: {0}", autoGrowTestList);

            autoGrowTestList.Add('1');

            Console.WriteLine("\nAdd \"1\" in list");
            Console.WriteLine("list capacity after overflow start capacity: {0}", autoGrowTestList.Capacity);
            Console.WriteLine("\nnew list content: {0}", autoGrowTestList);

            Console.WriteLine("\nMin elenemt is: {0}", autoGrowTestList.Min());
            Console.WriteLine("\nMax element is: {0}", autoGrowTestList.Max());

            Console.WriteLine("\nMin string between \"me\" and \"you\" is: {0}",
                GenericList<string>.Min("me", "you"));
        }
    }
}
