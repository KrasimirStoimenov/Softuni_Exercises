using System;
using System.Collections.Generic;

namespace _04._Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Songs> songList = new List<Songs>();
            Proccessing(songList);
            PrintOutput(songList);
        }

        static void PrintOutput(List<Songs> songList)
        {
            string typeSongToPrint = Console.ReadLine();
            if (typeSongToPrint == "all")
            {
                foreach (Songs song in songList)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (var song in songList)
                {
                    if (song.TypeList == typeSongToPrint)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }

        static void Proccessing(List<Songs> songList)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfSongs; i++)
            {
                //"{typeList}_{name}_{time}"

                string[] cmdArgs = Console.ReadLine().Split("_");

                Songs song = new Songs(cmdArgs[0], cmdArgs[1], cmdArgs[2]);
                songList.Add(song);

            }
        }
    }
    //class Songs
    //{
    //    public Songs(string type, string name, string time)
    //    {
    //        this.TypeList = type;
    //        this.Name = name;
    //        this.Time = time;
    //    }
    //    public string TypeList { get; set; }
    //    public string Name { get; set; }
    //    public string Time { get; set; }
    //}
}
