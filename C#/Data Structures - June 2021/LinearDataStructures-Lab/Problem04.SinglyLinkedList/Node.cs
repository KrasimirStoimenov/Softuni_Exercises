namespace Problem04.SinglyLinkedList
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }

        public Node<T> Next { get; set; }
    }
}