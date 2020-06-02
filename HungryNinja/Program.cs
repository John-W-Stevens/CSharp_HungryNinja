using System;
using System.Collections.Generic;

namespace HungryNinja
{

    // Create a Food class
    public class Food
    {
        public string Name;
        public int Calories;
        public bool IsSpicy;
        public bool IsSweet;

        // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
        public Food(string name, int calories, bool isSpicy, bool isSweet)
        {
            Name = name;
            Calories = calories;
            IsSpicy = isSpicy;
            IsSweet = isSweet;
        }
    }

    public class Buffet
    {
        public List<Food> Menu;

        // add a constructor and set Menu to a hard coded list of 7 or more Food objects you instantiate manually
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Donut", 800, false, true),
                new Food("Bagel", 600, false, false),
                new Food("Apple", 300, false, true),
                new Food("Carrot", 70, false, false),
                new Food("Pizza", 1200, true, false),
                new Food("Hamburger", 800, false, false),
                new Food("Taco", 350, true, false),

            };
        }

        // build out a Serve method that randomly selects a Food object from the Menu list and returns the Food object
        public Food Serve()
        {
            Random rand = new Random();
            int idx = rand.Next(0, this.Menu.Count);
            return this.Menu[idx];
        }
    }

    public class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;

        // add a constructor that sets calorieIntake to 0 and creates a new, empty list of Food objects to FoodHistory
        public Ninja()
        {
            this.calorieIntake = 0;
            this.FoodHistory = new List<Food> { };
        }


        public int CalorieIntake
        {
            get
            {
                return this.calorieIntake;
            }
            set
            {
                calorieIntake = value;
            }
        }

        // add a public "getter" property called "IsFull" that returns a boolean based on if the Ninja's calorie intake is greater than 1200 calories
        public bool IsFull
        {
            get
            {
                return this.calorieIntake > 1200;
            }
        }

        // Add an Eat method to the Ninja class
        public void Eat(Food item)
        {
            // If the ninja is not full:
            if (!this.IsFull)
            {
                // add calorie value to ninja's total calorieIntake
                this.calorieIntake += item.Calories;
                // add the randomly selected Food object to ninja's FoodHistory list
                this.FoodHistory.Add(item);
                // write the Food's Name - and if it is spicy/sweet to the console
                string spicy = "is not spicy";
                string sweet = " is not sweet.";
                if (item.IsSpicy == true) { spicy = "is spicy"; }
                if (item.IsSweet == true) { sweet = " is sweet."; }

                Console.WriteLine($"Ninja ate a {item.Name} which {spicy} and {sweet}");
            }
            // If the Ninja is full:
            else
            {
                // issue a warning to the console that the ninja is full and cannot eat anymore
                Console.WriteLine("The ninja is full, and cannot eat any more food.");
            }

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Test Food class: 
            // Food Pizza = new Food("Pizza", 1200, true, false);
            // Console.WriteLine($"Name: {Pizza.Name}, Calories {Pizza.Calories}, Spicy: {Pizza.IsSpicy}, Sweet: {Pizza.IsSweet}.");

            // Test Buffet class:
            Buffet GoldenCorral = new Buffet();
            // Console.WriteLine(GoldenCorral.Serve().Name);
            // Console.WriteLine(GoldenCorral.Serve().Name);

            // Test Ninja class:
            Ninja Wadoo = new Ninja();
            //Console.WriteLine($"Calorie intake: {Wadoo.CalorieIntake}"); // Get method
            //Console.WriteLine($"Calorie intake: {Wadoo.CalorieIntake = 1201}"); // Set method
            //Console.WriteLine(Wadoo.IsFull); // IsFull method

            // In your Program's Main method, instantiate a Buffet and Ninja object, and have the Ninja eat until they are full!
            while (Wadoo.CalorieIntake < 1200)
            {
                Wadoo.Eat(GoldenCorral.Serve());
            }
            Wadoo.Eat(GoldenCorral.Serve());


        }
    }
}
