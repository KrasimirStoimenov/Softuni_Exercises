using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodString
{
    public class CompareClass
    {
        public static int Compare<T>(List<T>list,T element)
            where T:IComparable
        {
            int count = 0;
            foreach (var item in list)
            {
                if (item.CompareTo(element)==1)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
