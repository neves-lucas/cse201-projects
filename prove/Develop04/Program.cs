using System;

namespace MindfulnessProgram
{
    // This is the main class that runs the program
    class Program
    {
        // This is the main method that executes the program
        static void Main(string[] args)
        {
            // Create an object of each activity class
            BreathingActivity breathing = new BreathingActivity();
            ReflectionActivity reflection = new ReflectionActivity();
            ListingActivity listing = new ListingActivity();

            // Initialize a variable to store the user's choice
            int choice = 0;

            // Loop until the user chooses to exit
            while (choice != 4)
            {
                // Display the menu and prompt the user to choose an activity
                Console.Clear();
                Console.WriteLine("Welcome to the Mindfulness Program.");
                Console.WriteLine("Please choose an activity:");
                Console.WriteLine("1. Breathing");
                Console.WriteLine("2. Reflection");
                Console.WriteLine("3. Listing");
                Console.WriteLine("4. Exit");
                choice = int.Parse(Console.ReadLine());

                // Perform the corresponding activity based on the user's choice
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        breathing.Perform();
                        break;
                    case 2:
                        Console.Clear();
                        reflection.Perform();
                        break;
                    case 3:
                        Console.Clear();
                        listing.Perform();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Thank you for using the Mindfulness Program. Have a nice day!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
