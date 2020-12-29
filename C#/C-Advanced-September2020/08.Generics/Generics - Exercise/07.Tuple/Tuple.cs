using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    public class Tuple<T1, T2>
    {
        private T1 firstElement;
        private T2 secondElement;

        public Tuple(T1 first, T2 second)
        {
            this.firstElement = first;
            this.secondElement = second;
        }

        public override string ToString()
        {
            return $"{this.firstElement} -> {this.secondElement}";
        }
    }
}
