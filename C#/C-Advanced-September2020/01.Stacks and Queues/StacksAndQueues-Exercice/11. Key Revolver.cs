using System;
using System.Linq;
using System.Collections.Generic;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bullets = ReadIntArray();
            Stack<int> stackBullets = new Stack<int>(bullets);

            int[] locks = ReadIntArray();
            Queue<int> queueLocks = new Queue<int>(locks);

            int intelligenceValue = int.Parse(Console.ReadLine());
            int currentBarell = gunBarrelSize;
            while (stackBullets.Any() && queueLocks.Any())
            {
                int currentBulletStrength = stackBullets.Pop();
                intelligenceValue -= bulletPrice;
                int currentLockStrength = queueLocks.Peek();
                if (currentBulletStrength <= currentLockStrength)
                {
                    Console.WriteLine("Bang!");
                    queueLocks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                currentBarell--;
                if (currentBarell == 0&&stackBullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    currentBarell = gunBarrelSize;
                }
            }
            if (queueLocks.Count == 0)
            {
                Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${intelligenceValue}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
            }

        }
        static int[] ReadIntArray() => Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
    }
}
