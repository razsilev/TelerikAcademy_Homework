namespace _12_Stack
{
    public class TestStack
    {
        public static void Main()
        {
            var stack = new Stack<int>();

            stack.Push(3)
                 .Push(4)
                 .Push(5)
                 .Push(6);

            while (stack.Count > 0)
            {
                System.Console.WriteLine(stack.Pop());
            }
        }
    }
}