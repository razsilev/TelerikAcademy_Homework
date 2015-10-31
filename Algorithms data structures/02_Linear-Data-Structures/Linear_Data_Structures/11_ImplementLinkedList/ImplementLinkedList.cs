namespace _11_ImplementLinkedList
{
    public class ImplementLinkedList
    {
        public static void Main()
        {
            // test LinkedList
            var linkedList = new LinkedList<int>();

            linkedList.FirstElement = new ListItem<int>(5);
            var element = new ListItem<int>(3);
            linkedList.FirstElement.Next = element;
            element.Next = new ListItem<int>(8);

            var current = linkedList.FirstElement;
            while (current != null)
            {
                System.Console.WriteLine(current.Value);
                current = current.Next;
            }
        }
    }
}
