// Program.cs

using System;
using System.Collections.Generic;
using System.IO;

namespace GoalTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager(); // This is a goal manager object that handles all the logic and operations related to the goals and the score

            Console.WriteLine("Welcome to Goal Tracker!");
            Console.WriteLine("You have " + goalManager.GetScore() + " points.");

            bool quit = false; // This is a flag to indicate whether to quit the program or not

            while (!quit) // Loop until the user chooses to quit
            {
                Console.WriteLine();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine(); // Read the user's choice

                switch (choice) // Execute different actions based on the user's choice
                {
                    case "1": // Create new goal
                        goalManager.CreateNewGoal(); // Call the goal manager object's method to create a new goal and add it to the list of goals
                        break;
                    case "2": // List goals
                        goalManager.ListGoals(); // Call the goal manager object's method to list all the goals in the list of goals
                        break;
                    case "3": // Save goals
                        goalManager.SaveGoals(); // Call the goal manager object's method to save the list of goals and the score to a file
                        break;
                    case "4": // Load goals
                        goalManager.LoadGoals(); // Call the goal manager object's method to load the list of goals and the score from a file
                        break;
                    case "5": // Record event
                        goalManager.RecordEvent(); // Call the goal manager object's method to record an event and update the score
                        break;
                    case "6": // Quit
                        quit = true; // Set the quit flag to true
                        Console.WriteLine("Thank you for using Goal Tracker. Goodbye!");
                        break;
                    default: // Invalid choice
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                        break;
                }
            }
        }
    }
}