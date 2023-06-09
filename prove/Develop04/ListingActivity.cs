using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    // This is a subclass of PromptActivity that represents the listing activity
    public class ListingActivity : PromptActivity
    {
        // This is a private member variable to store the count of items entered by the user
        private int _count;

        // This is a constructor that calls the base constructor with the description and the list of prompts
        public ListingActivity() : base("reflect on the good things in your life by having you list as many things as you can in a certain area", new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        })
        {
            // Initialize the count to zero
            _count = 0;
        }

        // This is a method that overrides the Perform method from the base class
        public override void Perform()
        {
            // Display the starting message
            StartMessage();

            // Get the duration of the activity
            int duration = GetDuration();

            // Initialize a variable to store the start time
            DateTime start = DateTime.Now;

            // Display a new prompt and pause for 5 seconds
            NewPrompt();
            Pause(5);
            Console.WriteLine();

            // Loop until the current time minus the start time reaches the duration
            while ((DateTime.Now - start).TotalSeconds < duration)
            {
                // Prompt the user to enter an item and increment the count
                Console.WriteLine("Enter an item:");
                string item = Console.ReadLine();
                _count++;
            }

            // Display the number of items entered by the user
            Console.WriteLine($"You have entered {_count} items.");

            // Display the ending message
            EndMessage();
        }

        // This is a method that overrides the NewPrompt method from the base class
        public override void NewPrompt()
        {
            // Get a random prompt from the base class method and display it to the user
            Console.WriteLine(GetPrompt());
        }
    }
}
