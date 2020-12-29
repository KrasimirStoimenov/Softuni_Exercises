using System;
using System.IO;

namespace _05.SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using var reader = new FileStream("../../../sliceMe.txt", FileMode.Open);

            int parts = 4;
            long equalParts = reader.Length / 4;
            byte[] buffer = new byte[equalParts];

            for (int i = 0; i < parts; i++)
            {
                using var writer = new FileStream($"../../../Part-{i + 1}.txt", FileMode.OpenOrCreate);
                reader.Read(buffer, 0, buffer.Length);
                writer.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
