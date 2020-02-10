using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = MusicStore.GetData().AllArtists;
            List<Group> Groups = MusicStore.GetData().AllGroups;

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            IEnumerable<Artist> Mountvernonartist = Artists.Where( a => a.Hometown =="Mount Vernon");
            foreach(var b in Mountvernonartist)
            {
                System.Console.WriteLine(b.ArtistName +" and "+ b.Hometown);
            }
            Console.WriteLine("\n~~~~~~~~~\n");

            //Who is the youngest artist in our collection of artists?
            int YoungestArtist = Artists.Min(b => b.Age);
            Artist artistname = Artists.FirstOrDefault(b =>b.Age ==YoungestArtist );
            {
                System.Console.WriteLine(YoungestArtist +""+ artistname.RealName);
            }
            //Display all artists with 'William' somewhere in their real name
            IEnumerable<Artist> Wartists = Artists.Where(b =>b.RealName.Contains ("William"));
            System.Console.WriteLine("These artist's names are William");
            foreach (var Artist in Wartists)
            System.Console.WriteLine(Artist.RealName);
            System.Console.WriteLine(".......................................................");
        

            //Display the 3 oldest artist from Atlanta
            var atOldest = Artists
            .Where(art => art.Hometown =="Atlanta")
            .OrderByDescending(art => art.Age)
            .Take(3);
            System.Console.WriteLine("The three oldest artists from atlanta =");
            foreach (var artist in atOldest)
            System.Console.WriteLine(artist.ArtistName);
            System.Console.WriteLine(".....................................................");

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
	        // Console.WriteLine(Groups.Count);
        }
    }
}
