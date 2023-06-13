using System;
using System.Threading;

namespace MindfulnessProgram
{
    // This is the base class for all activities
    public abstract class Activity
    {
        // This is a private member variable to store the duration of the activity in seconds
        private int _duration;

        // Member variables for name and description.

        private string _name;
        private string _description;


        // This is a constructor that takes the name and description as parameters and sets them to the member variables
        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        // This is a method to set the duration of the activity
        public void SetDuration()
        {
            Console.WriteLine();
            Console.WriteLine("How long do you want to do this activity? (in seconds)");
            _duration = int.Parse(Console.ReadLine());
        }

        // This is a method to get the duration of the activity
        public int GetDuration()
        {
            return _duration;
        }

        // This is an abstract method that each subclass must implement to perform the activity
        public abstract void Perform();

        // This is a method to display the starting message for the activity
        public void StartMessage()
        {
            Console.WriteLine($"Welcome to the {_name} activity.");
            Console.WriteLine();
            Console.WriteLine("This activity will help you " + _description + ".");
            SetDuration();
            Console.WriteLine("Please prepare to begin.");
            Pause(5);
        }

        // This is a method to display the ending message for the activity
        public void EndMessage()
        {
            Console.WriteLine("You did a great job!");
            Console.WriteLine($"You have completed the {_name} activity for {GetDuration()} seconds.");
            Pause(4);
        }

        // This is a method to pause the program for a given number of seconds and show an animation
        public void Pause(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write("+");
                Thread.Sleep(1000);
                Console.Write("\b \b"); // Erase the + character
                Console.Write("-");
            }
            Console.WriteLine();
        }
    }
}
