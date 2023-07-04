// SimpleGoal.cs
using System;

namespace GoalTracker
{
    // This is a derived class for simple goals that can be marked complete and the user gains some value
    public class SimpleGoal : Goal
    {
        // This is the constructor that takes the name and value of the goal as parameters and passes them to the base class constructor
        public SimpleGoal(string name, string description, int value) : base(name, description, value)
        {
            
        }

        // This is an override method that updates the user's score and marks the goal as completed when recording an event
        public override int RecordEvent(int score)
        {
            if (!GetCompleted()) // If the goal is not already completed
            {
                score += GetValue(); // Add the value of the goal to the score
                SetCompleted(true); // Mark the goal as completed
                Console.WriteLine("You have completed " + GetName() + " and earned " + GetValue() + " points!");
            }
            else // If the goal is already completed
            {
                Console.WriteLine("You have already completed " + GetName() + ".");
            }
            return score; // Return the updated score
        }

        // This is an override method that returns a string representation of the goal with a check mark if it is completed
        public new string ToString()
         {
             if (GetCompleted()) // If the goal is completed 
             {
                 return "[X] " + base.ToString(); // Add a check mark before the base string representation 
             }
             else // If the goal is not completed 
             {
                 return "[ ] " + base.ToString(); // Add an empty box before the base string representation 
             }
            
        }
    }
}
