
// EternalGoal.cs

using System;

namespace GoalTracker
{
    // This is a derived class for eternal goals that are never complete, but each time the user records them, they gain some value
    public class EternalGoal : Goal
    {
         // This is the constructor that takes the name and value of the goal as parameters and passes them to the base class constructor
         public EternalGoal(string name, string description, int value) : base(name, description, value)
         {

         }

         // This is an override method that updates the user's score when recording an event
         public override int RecordEvent(int score)
         {
             score += GetValue(); // Add the value of the goal to the score
             Console.WriteLine("You have recorded " + GetName() + " and earned " + GetValue() + " points!");
             return score; // Return the updated score
         }

         // This is an override method that returns a string representation of the goal with an infinity symbol 
         public override string ToString()
         {
             return "[∞] " + base.ToString(); // Add an infinity symbol before the base string representation 
         }
    }
}
