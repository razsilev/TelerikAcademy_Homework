namespace _11_ImplementLinkedList
{
    public class ListItem <T>
    {
        public ListItem(T value)
        {
            this.Next = null;
            this.Value = value;
        }

        public ListItem<T> Next { get; set; }

        public T Value { get; set; }
    }
}
