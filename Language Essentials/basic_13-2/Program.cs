using System;
using System.Collections.Generic;

namespace basic_13_2
{
    class Program
    {
        // Print 1-255
        public static void PrintNumbers()
        {
            // Print all of the integers from 1 to 255.
            for (int i = 1; i <= 255; i++)
            {
                System.Console.WriteLine(i);
            }
        }

        // Print odd numbers between 1-255
        public static void PrintOdds()
        {
            // Print all of the odd integers from 1 to 255.
            Console.WriteLine("Odd numbers from 1 to 255. Prints one number per line.");
            for (int n = 1; n < 256; n++)
            {
                if (n % 2 == 0)
                {
                    continue;
                }
                Console.WriteLine(n.ToString());
            }
        }

        // // Print Sum
        public static void PrintSum()
        {
            //     // Print all of the numbers from 0 to 255, 
            //     // but this time, also print the sum as you go. 
            //     // For example, your output should be something like this:
            //     // New number: 0 Sum: 0
            //     // New number: 1 Sum: 1
            //     // New Number: 2 Sum: 3


            Console.WriteLine("Print all of the numbers from 0 to 255 but this time, also print the sum as you go.");
            {
                int sum = 0;
                for (int i = 0; i <= 255; i++)
                {
                    sum = sum + i;
                    Console.WriteLine($"New Number: {i}, Sum: {sum}");
                }
            }

        }

        // Iterating through an Array
        public static void LoopArray(int[] numbers)
        {
            // Write a function that would iterate through each item of the given integer array and 
            // print each value to the console. 
            for (int i = 0; i < numbers.Length; i++)
            {
                System.Console.WriteLine(numbers[i]);
            }
        }



        // Find Max
        public static int FindMax(int[] numbers)
        {
            // Write a function that takes an integer array and prints and returns the maximum value in the array. 
            // Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), 
            // or even a mix of positive numbers, negative numbers and zero.
            int temp = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > temp)
                {
                    temp = numbers[i];
                }
            }
            System.Console.WriteLine(temp);
            return temp;
        }



        // Get Average
        public static void GetAverage(int[] numbers)
        {
            // Write a function that takes an integer array and prints the AVERAGE of the values in the array.
            // For example, with an array [2, 10, 3], your program should write 5 to the console.
            int sum = 0;
            double average = 0.0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum = sum + numbers[i];
            }
            average = (double)sum / numbers.Length;
            System.Console.WriteLine(average);
        }



        // Array with Odd Numbers
        public static int[] OddArray()
        {
            // Write a function that creates, and then returns, an array that contains all the odd numbers between 1 to 255. 
            // When the program is done, this array should have the values of [1, 3, 5, 7, ... 255].
            int[] numArray = new int[128];
            numArray[0] = 1;
            for (int i = 1; i < numArray.Length; i++)
            {
                numArray[i] = numArray[i - 1] + 2;
                System.Console.WriteLine(numArray[i]);
            }
            return numArray;
        }



        // Greater than Y
        public static int GreaterThanY(int[] numbers, int y)
        {
            // Write a function that takes an integer array, and a integer "y" and returns the number of array values 
            // That are greater than the "y" value. 
            // For example, if array = [1, 3, 5, 7] and y = 3. Your function should return 2 
            // (since there are two values in the array that are greater than 3).
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > y)
                {
                    count++;
                }
            }
            System.Console.WriteLine(count);
            return count;
        }



        // Square the Values
        public static void SquareArrayValues(int[] numbers)
        {
            // Write a function that takes an integer array "numbers", and then multiplies each value by itself.
            // For example, [1,5,10,-10] should become [1,25,100,100]
            {
                int square = 0;
                Console.WriteLine("SquareArrayValues Start -------------");
                for (int i = 0; i < numbers.Length; i++)
                {
                    square = (numbers[i]) * (numbers[i]);
                }
                Console.WriteLine("[{0}]", string.Join(", ", square));
                Console.WriteLine("SquareArrayValues End -------------");
            }


        }




        // Eliminate Negative Numbers*******could not get -2 to become 0
        public static void EliminateNegatives(int[] numbers)
        {
            // Given an integer array "numbers", say [1, 5, 10, -2], create a function that replaces any negative number with the value of 0. 
            // When the program is done, "numbers" should have no negative values, say [1, 5, 10, 0].
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] < 0)
                    {
                        numbers[i] = 0;
                    }
                }
                Console.WriteLine("[{0}]", string.Join(", ", numbers));
            }
        }



        // Min, Max, and Average
        public static void MinMaxAverage(int[] numbers)
        {
            // Given an integer array, say [1, 5, 10, -2], create a function that prints the maximum number in the array, 
            // the minimum value in the array, and the average of the values in the array.
            {
            int max = 0;
            int min = 0;
            int avg = 0;
            int sum = 0;
            Console.WriteLine("MinMaxAverage Start -----------------");
            for (int i = 0; i < numbers.Length; i++){
                sum = sum + i;
                avg = sum/numbers.Length;
                if (numbers[i] > max){
                    max = numbers[i];
                }
                if (numbers[i] < min){
                    min = numbers[i];
                }
            }
            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.WriteLine(avg);
            Console.WriteLine("MinMaxAverage End -----------------");
        }

        }



        // Shifting the values in an array**********could not return objectarray
        public static void ShiftValues(int[] numbers)
        {
            // Given an integer array, say [1, 5, 10, 7, -2], 
            // Write a function that shifts each number by one to the front and adds '0' to the end. 
            // For example, when the program is done, if the array [1, 5, 10, 7, -2] is passed to the function, 
            // it should become [5, 10, 7, -2, 0].
            Console.WriteLine("ShiftValues Start ------------------");
            for (int i = 0; i < numbers.Length; i++){
                if (numbers[i] == numbers[0]){

                }
                else {
                    numbers[i-1] = numbers[i];
                }
                if (numbers[i] == numbers[numbers.Length-1]){
                    numbers[numbers.Length-1] = 0;
                    break;
                }
            }
            Console.WriteLine("[{0}]", string.Join(", ", numbers));
            Console.WriteLine("ShiftValues End ------------------------");
        }




        // Number to String
        public static object[] NumToString(int[] numbers)
        {
            // Write a function that takes an integer array and returns an object array 
            // that replaces any negative number with the string 'Dojo'.
            // For example, if array "numbers" is initially [-1, -3, 2] 
            // your function should return an array with values ['Dojo', 'Dojo', 2].
            object[] objectArray = new object[numbers.Length];
            numbers.CopyTo(objectArray, 0);
            for (int i = 0; i < numbers.Length; i++){
                if (numbers[i] < 0){
                    objectArray[i] = "Dojo";
                }
            }
            Console.WriteLine("[{0}]", string.Join(", ", objectArray));
            return objectArray;
        }
        




        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // PrintNumbers();
            // PrintOdds();
            // PrintSum();
            // int[] numbers = { 1, 3, 5, 7, 9, 12 };
            // FindMax(numbers);
            // GetAverage(numbers);
            // OddArray();
            // int[] numbers = { 1, 5, 10, -10 };
            // GreaterThanY(numbers, 2);
            // SquareArrayValues(numbers);
            // int[] numbers = { 1, 5, 10, -2 };
            // EliminateNegatives(numbers);
            // MinMaxAverage(numbers);
            // ShiftValues(numbers);
            int[] numbers = { -1, -3, 2 };
            NumToString(numbers);
        }
    }
}
