// ChecklistGoal.cs

using System;

namespace GoalTracker
{
    // This is a derived class for checklist goals that must be accomplished a certain number of times to be complete
    public class ChecklistGoal : Goal
    {
        // These are the private member variables that are specific to checklist goals
        private int _times; // The number of times the goal must be accomplished
        private int _count; // The current count of how many times the goal has been accomplished
        private int _bonus; // The bonus value of the goal when it is completed

        // These are the public getters and setters for the member variables
        public int GetTimes()
        {
            return _times;
        }

        public void SetTimes(int times)
        {
            _times = times;
        }

        public int GetCount()
        {
            return _count;
        }

        public void SetCount(int count)
        {
            _count = count;
        }

        public int GetBonus()
        {
            return _bonus;
        }

        public void SetBonus(int bonus)
        {
            _bonus = bonus;
        }

        // This is the constructor that takes the name, value, times and bonus of the goal as parameters and passes the name and value to the base class constructor
        public ChecklistGoal(string name, string description, int value, int times, int bonus) : base(name, description, value)
        {
            SetTimes(times);
            SetCount(0); // By default, the count is zero
            SetBonus(bonus);
        }

        // This is an override method that updates the user's score and the count when recording an event
        public override int RecordEvent(int score)
        {
            if (!GetCompleted()) // If the goal is not already completed
            {
                score += GetValue(); // Add the value of the goal to the score
                SetCount(GetCount() + 1); // Increment the count by one
                Console.WriteLine("You have recorded " + GetName() + " and earned " + GetValue() + " points!");
                if (GetCount() == GetTimes()) // If the count reaches the required times
                {
                    score += GetBonus(); // Add the bonus value to the score
                    SetCompleted(true); // Mark the goal as completed
                    Console.WriteLine("You have completed " + GetName() + " and earned a bonus of " + GetBonus() + " points!");
                }
            }
            else // If the goal is already completed
            {
                Console.WriteLine("You have already completed " + GetName() + ".");
            }
            return score; // Return the updated score
        }

         // This is an override method that returns a string representation of the goal with a check mark if it is completed and the current count and times 
         public override string ToString()
         {
             if (GetCompleted()) // If the goal is completed
             {
                 return "[X] " + base.ToString() + "-- Currently completed: " + GetCount() + "/" + GetTimes(); // Add a check mark and the count and times before the base string representation 
             }
             else // If the goal is not completed
             {
                 return "[ ] " + base.ToString() + "-- Currently completed: " + GetCount() + "/" + GetTimes(); // Add an empty box and the count and times before the base string representation 
             }
             
         }
    }
}
