using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodString
{
    public class Box<T>
    {
        private List<T> list;
        public Box()
        {
            this.list = new List<T>();
        }

        public void Add(T element)
        {
            this.list.Add(element);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in this.list)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
