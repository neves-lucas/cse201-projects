using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    // This is a subclass of PromptActivity that represents the reflection activity
    public class ReflectionActivity : PromptActivity
    {
        // This is a constructor that calls the base constructor with the description and the list of prompts
        public ReflectionActivity() : base("Reflection", "reflect on times in your life when you have shown strength and resilience", new List<string>
        {
            "--- Think of a time when you stood up for someone else. ---",
            "--- Think of a time when you did something really difficult. ---",
            "--- Think of a time when you helped someone in need. ---",
            "--- Think of a time when you did something truly selfless. ---"
        })
        {
        }

        // This is a method that overrides the Perform method from the base class
        public override void Perform()
        {
            // Display the starting message
            StartMessage();

            // Get the duration of the activity
            int duration = GetDuration();

            // Initialize a variable to store the elapsed time
            int elapsed = 0;

            // Loop until the elapsed time reaches the duration
            while (elapsed < duration)
            {
                // Display a new prompt and pause for 10 seconds
                Console.WriteLine();
                Console.WriteLine("Consider the following prompt: ");
                NewPrompt();
                Console.WriteLine("When you have something in mind, press enter to continue. ");
                Console.ReadLine();
                Console.WriteLine();

                // Increment the elapsed time by 10 seconds
                elapsed += 10;
            }

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
