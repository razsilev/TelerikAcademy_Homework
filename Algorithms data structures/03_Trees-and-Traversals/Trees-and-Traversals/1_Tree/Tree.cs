namespace _1_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Tree
    {
        private static HashSet<int> parents = new HashSet<int>();
        private static HashSet<int> children = new HashSet<int>();
        private static Dictionary<int, List<int>> tree = new Dictionary<int, List<int>>();

        public static void Main()
        {
            string[] input = new string[] { "7",
                                            "2 4",
                                            "3 2",
                                            "5 0",
                                            "3 5",
                                            "5 6",
                                            "5 1"};
            ReadInput(input);

            int root = FindRoot();
            Console.WriteLine("root: {0}", root);

            List<int> leafNodes = FindLeafNodes();
            Console.WriteLine("leaf nodes: {0}", string.Join(", ", leafNodes));

            List<int> middleNodes = FindMiddleNodes();
            Console.WriteLine("middle nodes: {0}", string.Join(", ",  middleNodes));

        }

        private static List<int> FindMiddleNodes()
        {
            var results = new List<int>();

            foreach (var item in children)
            {
                if (parents.Contains(item))
                {
                    results.Add(item);
                }
            }

            return results;
        }

        private static List<int> FindLeafNodes()
        {
            var results = new List<int>();

            foreach (var item in children)
            {
                if (!parents.Contains(item))
                {
                    results.Add(item);
                }
            }

            return results;
        }
        
        private static int FindRoot()
        {
            int root = 0;

            foreach (var item in parents)
            {
                if (!children.Contains(item))
                {
                    root = item;
                    break;
                }
            }

            return root;
        }

        private static void ReadInput(string[] input)
        {
            string[] tokens;

            for (int i = 1; i < input.Length; i++)
            {
                tokens = input[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int parent = int.Parse(tokens[0]);
                int child = int.Parse(tokens[1]);

                if (tree.ContainsKey(parent))
                {
                    tree[parent].Add(child);
                }
                else
                {
                    tree[parent] = new List<int>() { child };
                }

                parents.Add(parent);
                children.Add(child);
            }
        }
    }
}
