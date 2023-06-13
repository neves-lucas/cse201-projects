using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    // This is an abstract subclass of Activity that represents an activity that involves prompts
    public abstract class PromptActivity : Activity
    {
        // This is a private member variable to store a list of prompts for the activity
        private List<string> _promptList;

        // This is a constructor that takes the description and the list of prompts as parameters and sets them to the member variables
        public PromptActivity(string name, string description, List<string> promptList) : base(name, description)
        {
            _promptList = promptList;
        }

        // This is a method to get a random prompt from the list
        public string GetPrompt()
        {
            // Create a random object
            Random random = new Random();

            // Get a random index from 0 to the size of the list minus one
            int index = random.Next(0, _promptList.Count);

            // Return the prompt at that index
            return _promptList[index];
        }

        // This is an abstract method that each subclass must implement to display a new prompt
        public abstract void NewPrompt();
    }
}
