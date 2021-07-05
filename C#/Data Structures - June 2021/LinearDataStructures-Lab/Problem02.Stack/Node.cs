﻿namespace Problem02.Stack
{
    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public Node<T> Next { get; set; }
    }
}