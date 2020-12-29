using System;

namespace _19._Thea_The_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {
            long picturesCount = long.Parse(Console.ReadLine());
            long filterForOnePictureSeconds = long.Parse(Console.ReadLine());
            long goodPictures = long.Parse(Console.ReadLine());
            long uploadingTimeInSeconds = long.Parse(Console.ReadLine());

            double goodPhotos = Math.Ceiling(picturesCount * (double)goodPictures / 100);

            long totalSecondsNeededForFilter = picturesCount * filterForOnePictureSeconds;
            long uploadingFilteredPicturesInSeconds = (int)goodPhotos * uploadingTimeInSeconds;
            long totalSeconds = totalSecondsNeededForFilter + uploadingFilteredPicturesInSeconds;
            long days = totalSeconds / 86400;
            totalSeconds %= 86400;
            long hours = totalSeconds / 3600;
            totalSeconds %= 3600;
            long minutes = totalSeconds / 60;
            totalSeconds %= 60;

            Console.WriteLine($"{days}:{hours:D2}:{minutes:D2}:{totalSeconds:D2}");


        }
    }
}
