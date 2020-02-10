using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        //         Puzzles
        // The following problems are just continuing practice on all the things we have learned so far.

        // [x]Random Array
        // Create a function called RandomArray() that returns an integer array
        // x[]Place 10 random integer values between 5-25 into the array
        // [x]Print the min and max values of the array
        // []Print the sum of all the values
        public static void RandomArray()
        {
            int sum = 0;
            int[] numbers = new int[10];
            Random rand = new Random();
            for (int val = 0; val < 10; val++)
            // sum starts at 0, there is a int array that is empty called numbers with 10 things. 
            // within the first forloop val is 0 and if val is less than 10 add +1 per instance.
            {
                numbers[val] = rand.Next(5, 25);
                // this logic ^^^^ replacing all current values between 5 to 25 with a length of 10.
            }
            int max = numbers[0];
            int min = numbers[0];
            for (int val = 0; val < 10; val++)
            {
                sum = sum + numbers[val];
                if (numbers[val] > max)
                {
                    max = numbers[val];
                }
                if (numbers[val] < min)
                {
                    min = numbers[val];
                }
                Console.WriteLine(numbers[val]);
            }
            Console.WriteLine("max is " + max);
            Console.WriteLine(min);
            Console.WriteLine(sum);
        }

        // Create another function called TossMultipleCoins(int num) that returns a Double
        // []Have the function call the tossCoin function multiple times based on num value
        // []Have the function return a Double that reflects the ratio of head toss to total toss
        public static string TossCoin()
        // [x]Have the function print "Tossing a Coin!"
        {
            Random rand = new Random();
            string result = "null";
            for (int val = 0; val < 2; val++)
            {
                int num = rand.Next(0, 2);
                if (num == 1){
                Console.WriteLine("Tossing a coin");
        // []Randomize a coin toss with a result signaling either side of the coin 
                
                    result = "heads";
                }
                else
                {
                
                    result = "tails";
                }
            }
            Console.WriteLine(result);
        // Create a function called TossCoin() that returns a string
        // []Coin Flip
        // []Have the function print either "Heads" or "Tails"
        // []Finally, return the result
            return result;
        }
        // Names
        // Build a function Names that returns a list of strings.  In this function:
        // []Create a list with the values: Todd, Tiffany, Charlie, Geneva, Sydney
        // []Shuffle the list and print the values in the new order
        // []Return a list that only includes names longer than 5 characters
        public static List<string> Namelist()
        {
            List<string> names = new List<string>();
            names.Add("Todd");
            names.Add("Tiffany");
            names.Add("Charlie");
            names.Add("Geneva");
            names.Add("Sydney");
            Random rng = new Random();
            int n = names.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = names[k];
                names[k] = names[n];
                names[n] = value;
            }
            for (var i = 0; i < names.Count; i++)
            {
                System.Console.WriteLine("-" + names[i]);
            }
            return names;
        }

        static void Main(string[] args)
        {
            RandomArray();
            TossCoin();
            Namelist();
        }
    }
}