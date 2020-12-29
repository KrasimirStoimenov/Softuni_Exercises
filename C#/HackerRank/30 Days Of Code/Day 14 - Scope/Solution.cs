using System;
using System.Linq;

class Difference
{
    private int[] elements;
    public int maximumDifference;

    public Difference(int[] elements)
    {
        this.elements = elements;
    }

    public int computeDifference()
    {
        for (int i = 0; i < this.elements.Length; i++)
        {
            for (int j = i; j < this.elements.Length; j++)
            {
                int currentDiff = Math.Abs(this.elements[i] - this.elements[j]);
                if (currentDiff > maximumDifference)
                {
                    this.maximumDifference = currentDiff;
                }
            }
        }

        return this.maximumDifference;
    }

}

class Solution
{
    static void Main(string[] args)
    {
        Convert.ToInt32(Console.ReadLine());

        int[] a = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

        Difference d = new Difference(a);

        d.computeDifference();

        Console.Write(d.maximumDifference);
    }
}