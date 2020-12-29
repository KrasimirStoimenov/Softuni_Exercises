using System;

namespace _04._Photo_Gallery
{
    class Program
    {
        static void Main(string[] args)
        {
            int photoNumber = int.Parse(Console.ReadLine());
            int dayPhotoTaken = int.Parse(Console.ReadLine());
            int monthPhotoTaken = int.Parse(Console.ReadLine());
            int yearPhotoTaken = int.Parse(Console.ReadLine());
            int hourPhotoTaken = int.Parse(Console.ReadLine());
            int minutePhotoTaken = int.Parse(Console.ReadLine());
            double sizeOfPhotoBytes = double.Parse(Console.ReadLine());
            int widthPhoto = int.Parse(Console.ReadLine());
            int lenghtPhoto = int.Parse(Console.ReadLine());


            Console.WriteLine($"Name: DSC_{photoNumber:D4}.jpg");
            Console.WriteLine($"Date Taken: {dayPhotoTaken:D2}/{monthPhotoTaken:D2}/{yearPhotoTaken:D4} {hourPhotoTaken:D2}:{minutePhotoTaken:D2}");

            if (sizeOfPhotoBytes > 1000000)
            {
                sizeOfPhotoBytes /= 1000000;
                Console.WriteLine($"Size: {sizeOfPhotoBytes}MB");
            }
            else if (sizeOfPhotoBytes > 1000)
            {
                sizeOfPhotoBytes /= 1000;
                Console.WriteLine($"Size: {sizeOfPhotoBytes}KB");
            }
            else
            {
                Console.WriteLine($"Size: {sizeOfPhotoBytes}B");
            }

            if (widthPhoto > lenghtPhoto)
            {
                Console.WriteLine($"Resolution: {widthPhoto}x{lenghtPhoto} (landscape)");
            }
            else if (lenghtPhoto > widthPhoto)
            {
                Console.WriteLine($"Resolution: {widthPhoto}x{lenghtPhoto} (portrait)");
            }
            else
            {
                Console.WriteLine($"Resolution: {widthPhoto}x{lenghtPhoto} (square)");
            }


        }
    }
}
