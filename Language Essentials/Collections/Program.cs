using System;
using System.Collections.Generic;
namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {

            // Three Basic Arrays
            // Create an array to hold integer values 0 through 9
            // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            // Create an array of length 10 that alternates between true and false values, starting with true
            int[] numArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] nameArray = {"Martin", "Nikki", "Sara", "Tim"};
            bool[] boolArray = {true, false, true, false, true, false, true, false, true, false};

            // List of Flavors
            // Create a list of ice cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
            // Output the length of this list after building it
            // Output the third flavor in the list, then remove this value
            // Output the new length of the list (It should just be one fewer!)
            List<string> flavors = new List<string>();
            flavors.Add("chocolate");
            flavors.Add("vanilla");
            flavors.Add("greentea");
            flavors.Add("rockyroad");
            flavors.Add("tiramisu");
            System.Console.WriteLine(flavors.Count);
            System.Console.WriteLine(flavors[3]);
            flavors.Remove(flavors[3]);
            System.Console.WriteLine(flavors.Count);



            // [x]User Info Dictionary
            // [x]Create a dictionary that will store both string keys as well as string values
            // [x]Add key/value pairs to this dictionary where:
            // [x]each key is a name from your names array
            // [x]each value is a randomly select a flavor from your flavors list.
            // [x]Loop through the dictionary and print out each user's name and their associated ice cream flavor
            Dictionary<string,string> profile = new Dictionary<string,string>();
            profile.Add("Martin", "chocolate");
            profile.Add("Nikki", "vanilla");
            profile.Add("Sara", "greentea");
            profile.Add("Tim", "rockyroad");
            profile.Add("John", "tiramisu");
            foreach (KeyValuePair<string,string> entry in profile)
            {
            Console.WriteLine(entry.Key + " - " + entry.Value);
            }

        }
    }
}
