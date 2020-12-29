using System;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory("../../../CopyMe", "../../../zipped.zip");
            ZipFile.ExtractToDirectory("../../../zipped.zip", "../../../");
        }
    }
}
