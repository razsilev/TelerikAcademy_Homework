using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06MyTreeTest
{
    class MyTreeTest
    {
        static void Main()
        {
            BinarySearchTree<int> intTree = new BinarySearchTree<int>();

            intTree.Add(3);
            intTree.Add(1);
            intTree.Add(6);

            Console.WriteLine("Call intTree.ToString();");
            Console.WriteLine(intTree);

            Console.WriteLine("\nUse foreach:");

            foreach (var item in intTree)
            {
                Console.WriteLine(item);
            }

            BinarySearchTree<int> compareTree = intTree;

            Console.WriteLine("\nIs intTree equals with compareTree: {0}", compareTree.Equals(intTree));

            compareTree = new BinarySearchTree<int>();
            compareTree.Add(7);

            Console.WriteLine("\nIs intTree != with compareTree: {0}", compareTree != intTree);
            Console.WriteLine("\nIs intTree equals with compareTree: {0}", compareTree.Equals(intTree));

            Console.WriteLine("\nTest Clone");

            compareTree = intTree.Clone();

            Console.WriteLine("intTree: {0}", intTree);
            Console.WriteLine("compareTree: {0}", compareTree);

            int searchedNumber = -3;

            Console.WriteLine("\nintTree contains {0} = {1}", searchedNumber, intTree.Contains(searchedNumber));

            int deleteNumber = 3;
            intTree.Add(3);

            Console.WriteLine("\nintTree before deleting: {0}", intTree);
            Console.WriteLine("\nintTree Delete {0}, deleted elements are: {1}", deleteNumber, intTree.Delete(deleteNumber));
            Console.WriteLine("\nintTree after deleting: {0}", intTree);

        }
    }
}
