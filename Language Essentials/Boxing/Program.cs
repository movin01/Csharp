using System;
using System.Collections.Generic;

namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            //  Create an empty List of type object
            //  Add the following values to the list: 7, 28, -1, true, "chair"
            //  Loop through the list and print all values (Hint: Type Inference might help here!)
            //  Add all values that are Int type together and output the sum
            List<object> things = new List<object>();
            things.Add(7);
            things.Add(28);
            things.Add(-1);
            things.Add(true);
            things.Add("chair");
            for (int i = 0; i < things.Count; i++){
                System.Console.WriteLine($"{i}= {things[i]}");
        }
            foreach (object i in things){
                if (i is int){
                    sum = sum + Convert.ToInt32(i);
                Console.WriteLine(sum);
                }
                
                }

            }
        }
    }

