using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> filesInfo = new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo directoryInfo = new DirectoryInfo("../../../");
            var files = directoryInfo.GetFiles();

            FillFilesInformationDictionary(filesInfo, files);
            WriteFilesInOutputFile(filesInfo);
        }

        private static void WriteFilesInOutputFile(Dictionary<string, Dictionary<string, double>> filesInfo)
        {
            using var writer = new StreamWriter($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/report.txt");
            foreach (var kvp in filesInfo.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                writer.WriteLine(kvp.Key);
                foreach (var (file,size) in kvp.Value.OrderBy(x=>x.Value))
                {
                    writer.WriteLine($"--{file} - {size} kb.");
                }
            }
        }

        private static void FillFilesInformationDictionary(Dictionary<string, Dictionary<string, double>> filesInfo, FileInfo[] files)
        {
            for (int i = 0; i < files.Length; i++)
            {
                var currentFile = files[i];
                if (!filesInfo.ContainsKey(currentFile.Extension))
                {
                    filesInfo.Add(currentFile.Extension, new Dictionary<string, double>());
                }
                filesInfo[currentFile.Extension].Add(currentFile.Name, currentFile.Length / 1024.00);
            }
        }
    }
}
