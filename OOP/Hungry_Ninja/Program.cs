using System;
using System.Collections.Generic;
// ^^^^^^^^^^^^^^^ needs this to use list
namespace Hungry_Ninja
{
    class Program
    {
        // [x]Create a Food classVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVstarts here
        class Food
        {
            public string Name;
            public int Calories;
            // Foods can be Spicy and/or Sweet
            public bool IsSpicy;
            public bool IsSweet;
            // []add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
            public Food(string name, int _calories, bool _issspicy, bool _issweet)
            {
                // food can have these attributes/ parameteres^^^^^^
                Name = name;
                Calories = _calories;
                IsSpicy = _issspicy;
                IsSweet = _issweet;
            }
        }
        // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ class food ends here
        // Create a Buffet class, which will contain a Menu of Food objects
        // add a constructor and set Menu to a hard coded list of 7 or more Food objects you instantiate manually
        // build out a Serve method that randomly selects a Food object from the Menu list and returns the Food object
        class Buffet
        {
            public List<Food> Menu;
            //constructor
            public Buffet()
            {
                Menu = new List<Food>()
                {
                    new Food("pizza", 800, false, false),
                    new Food("cheeseburger", 3000, false, false),
                    new Food("fries", 2500, false, false),
                    new Food("macaroni", 1200, false, false),
                    new Food("porkribs", 2000, false, false),
                    new Food("steak", 2500, false, false),
                    new Food("dinosaur", 5000, false, false),
                };
            }
            public Food Serve()
            {
                Random rand_food = new Random();
                int index = rand_food.Next(Menu.Count);
                return Menu[index];
            }
        }

        // build out the Eat method that: if the Ninja is NOT full
        // adds calorie value to ninja's total calorieIntake
        // adds the randomly selected Food object to ninja's FoodHistory list
        // writes the Food's Name - and if it is spicy/sweet to the console
        // if the Ninja IS full
        // issues a warning to the console that the ninja is full and cannot eat anymore
        // Create a Ninja class
        class Ninja
        {

            // add a constructor that sets calorieIntake to 0 and creates a new, empty list of Food objects to FoodHistory
            private int calorieIntake;
            public List<Food> FoodHistory;
            // add a constructor
            public Ninja()
            {
                calorieIntake = 0;
                FoodHistory = new List<Food>();
            }
            // add a public "getter" property called "IsFull"
            public bool IsFull
            {
                get
                {
                    // add a public "getter" property called "IsFull" that returns a boolean based on if the Ninja's calorie intake is greater than 1200 calories
                    if (calorieIntake > 1200)
                    {
                        return true;
                    }
                    else { return false; }
                }
            }


            // build out the Eat method
            public void Eat(Food item)
            {
                Console.WriteLine($"Ninja 1 {item.Name}");
                if (this.IsFull)
                {
                    Console.WriteLine("Full stomach, we should stop feeding me");
                }
                else
                {
                    this.calorieIntake += item.Calories;
                    this.FoodHistory.Add(item);
                }
            }
        }

        static void Main(string[] args)
        {
 
            Console.WriteLine();
        }
    }
}
