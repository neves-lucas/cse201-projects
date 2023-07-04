// Goal.cs
using System;

namespace GoalTracker
{
    // This is the abstract base class for all kinds of goals
    public abstract class Goal
    {
        // These are the private member variables that are common to all goals
        private string _name; // The name of the goal
        private string _description; // The description of the goal.
        private int _value; // The value of the goal in points
        private bool _completed; // Whether the goal has been completed or not

        // These are the public getters and setters for the member variables
        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }
        public string GetDescription()
        {
            return _description;
        }

        public void SetDescription(string description)
        {
            _description = description;
        }

        public int GetValue()
        {
            return _value;
        }

        public void SetValue(int value)
        {
            _value = value;
        }

        public bool GetCompleted()
        {
            return _completed;
        }

        public void SetCompleted(bool completed)
        {
            _completed = completed;
        }

        // This is the constructor that takes the name and value of the goal as parameters
        public Goal(string name, string description, int value)
        {
            SetName(name);
            SetDescription(description);
            SetValue(value);
            SetCompleted(false); // By default, the goal is not completed
        }

        // It takes the user's score as a parameter and returns the updated score after recording an event
        public abstract int RecordEvent(int score);

        // This is a method that returns a string representation of the goal
        public new string ToString()
        {
            return GetName() + " (" + GetValue() + " points)";
        }
    }
}
