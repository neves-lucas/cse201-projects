using System;

namespace Journal
{
    // The Entry class represents a single journal entry.
    public class Entry
    {
        // The Text property holds the text of the journal entry.
        public string Text { get; set; }

        // The Date property holds the date and time the entry was created.
        public DateTime Date { get; set; }

        // The Prompt property holds the prompt that was used when creating this entry.
        public string Prompt { get; set; }

        // The Prompts property holds an array of prompts that can be used when creating a new entry.
        public static string[] Prompts { get; } = new string[]
        {
            "What are you most proud of yourself for and why?",
            "Who was the most interesting person I interacted with today?",
            "What are you grateful for today and why?",
            "What was the best part of my day?",
            "How do you feel about your current goals and progress?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "Write a letter to your future self or your past self.",
            "What are some of your favorite memories or experiences?",
            "If I had one thing I could do over today, what would it be?",
            "What is one thing you can do tomorrow to make it a better day than today?"
        };

        // The GetRandomPrompt method returns a randomly selected prompt from the Prompts array.
        public static string GetRandomPrompt()
        {
            Random random = new Random();
            int promptIndex = random.Next(Prompts.Length);
            return Prompts[promptIndex];
        }

        // The constructor initializes the Text, Date, and Prompt properties.
        public Entry(string text, string prompt)
        {
            Text = text;
            Date = DateTime.Now;
            Prompt = prompt;
        }

        // The ToString method returns a string representation of this entry that includes its date, prompt, and text.
        public override string ToString()
        {
            return $"{Date}: {Prompt} - {Text}";
        }
    }
}
