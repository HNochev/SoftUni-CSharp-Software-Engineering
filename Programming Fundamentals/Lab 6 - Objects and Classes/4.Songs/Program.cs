using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] info = Console.ReadLine()
                    .Split('_', StringSplitOptions.RemoveEmptyEntries);

                string type = info[0];
                string name = info[1];
                string time = info[2];

                Song song = new Song();

                song.TypeList = type;
                song.Name = name;
                song.Time = time;

                songs.Add(song);
            }

            string songType = Console.ReadLine();

            if(songType == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                List<Song> result = songs
                    .Where(n => n.TypeList == songType)
                    .ToList();
                foreach (Song song in result)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
}
