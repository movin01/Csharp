using System;

namespace Human
{
    // Create a Human class with four public fields: Name (string) , Strength (int), Intelligence (int), Dexterity (int)
    class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;

    // Add an additional private field for health (int), and a public property to access or "get" health
        private int _health;
        public int Health
        {
            get { return _health; }
        }

    // Add a constructor method that takes a string to initialize Name - and that will initialize Strength, Intelligence, and Dexterity to a default value of 3, and health to default value of 100
        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            _health = 100;
        }

    // Let's create an additional constructor that accepts 5 parameters, so we can set custom values for every field.
        public Human(string name, int strength, int intelligence, int dexterity, int health)
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            _health = health;
        }

    // Now add a new method called Attack, which when invoked, should reduce the health of a Human object that is passed as a parameter. 
        public int Attack(Human target)
        {
            // The damage done should be 5 * strength (5 points of damage to the attacked, for each 1 point of strength of the attacker). This method should return the remaining health of the target object.
            int damage = 5 * this.Strength;
            target._health -= damage;
            return target._health;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Human simba = new Human("Simba", 9001, 100, 500, 1000000);
            Human scar = new Human("Scar", 1, 1, 1, 1);

            simba.Attack(scar);
            System.Console.WriteLine(scar.Health);
        }
    }
}
