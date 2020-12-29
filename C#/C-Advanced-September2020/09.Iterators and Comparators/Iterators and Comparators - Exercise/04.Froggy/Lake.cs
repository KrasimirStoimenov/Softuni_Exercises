using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] array;

        public Lake(int[] array)
        {
            this.array = array;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.array.Length; i += 2)
            {
                yield return this.array[i];
            }
            Array.Reverse(this.array);
            if (this.array.Length % 2 == 0)
            {
                for (int i = 0; i < this.array.Length; i += 2)
                {
                    yield return this.array[i];
                }
            }
            else
            {
                for (int i = 1; i < this.array.Length; i+=2)
                {
                    yield return this.array[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
