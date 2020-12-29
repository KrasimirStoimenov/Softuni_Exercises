using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceLength = int.Parse(Console.ReadLine());

            int sequenceCounter = 0;
            int bestSequenceLengthCounter = 0;
            int[] bestSequence = new int[sequenceLength];
            int bestSequenceIndex = 0;
            int bestSequenceSum = 0;
            int bestSequenceCounter = 0;

            string command;
            while ((command = Console.ReadLine()) != "Clone them!")
            {
                int[] sequence = command
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                sequenceCounter++;

                int currentSequenceSum = sequence.Sum();
                int sequenceStartingIndex = 0;
                int sequencelengthCounter = 1;

                for (int i = 0; i < sequence.Length - 1; i++)
                {
                    int currentNumber = sequence[i];
                    if (currentNumber != sequence[i + 1] && currentNumber == 1)
                    {
                        break;
                    }
                    sequencelengthCounter++;
                    sequenceStartingIndex = i;
                }

                if (sequencelengthCounter > bestSequenceLengthCounter
                    || sequenceStartingIndex < bestSequenceIndex
                    || currentSequenceSum > bestSequenceSum)
                {
                    bestSequenceCounter = sequenceCounter;
                    bestSequenceLengthCounter = sequencelengthCounter;
                    bestSequence = sequence;
                    bestSequenceIndex = sequenceStartingIndex;
                    bestSequenceSum = currentSequenceSum;
                }
            }

            Console.WriteLine($"Best DNA sample {bestSequenceCounter} with sum: {bestSequenceSum}.");
            Console.WriteLine(string.Join(' ', bestSequence));
        }
    }
}
