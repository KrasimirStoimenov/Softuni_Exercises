using System;
using System.IO;

namespace _06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("../../../TestFolder");

            double bytesSum = 0;
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                bytesSum += fileInfo.Length;
            }

            double bytesInMegabytes = bytesSum / 1024 / 1024;

            File.WriteAllText("../../../Output.txt", bytesInMegabytes.ToString());
        }
    }
}
