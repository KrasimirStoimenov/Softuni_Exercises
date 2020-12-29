using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
    public class Threeuple<T1, T2, T3>
    {
        private T1 firstElement;
        private T2 secondElement;
        private T3 thirdElement;

        public Threeuple(T1 first, T2 second, T3 third)
        {
            this.firstElement = first;
            this.secondElement = second;
            this.thirdElement = third;
        }

        public override string ToString()
        {
            return $"{this.firstElement} -> {this.secondElement} -> {this.thirdElement}";
        }
    }
}
