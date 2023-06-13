using System;

namespace MindfulnessProgram
{
    // This is a subclass of Activity that represents the breathing activity
    public class BreathingActivity : Activity
    {
        // This is a constructor that calls the base constructor with the description
        public BreathingActivity() : base("Breathing", "This activity will help you relax by controlling your breath")
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
                // Display a message to breathe in and pause for 4 seconds
                Console.WriteLine("Breathe in...");
                Pause(4);
                Console.WriteLine();

                // Display a message to breathe out and pause for 4 seconds
                Console.WriteLine("Breathe out...");
                Pause(4);
                Console.WriteLine();

                // Increment the elapsed time by 8 seconds
                elapsed += 8;
            }

            // Display the ending message
            EndMessage();
        }
    }
}
