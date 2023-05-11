using System;

namespace Journal
{
    // The Program class contains the Main method that runs when the program starts.
    class Program
    {
        static void Main(string[] args)
        {
            // Display a welcome message and create a new Journal object.
            Console.WriteLine("Welcome to your journal!");
            Journal journal = new Journal("journal.txt");

            // Define an array of prompts to use when writing a new journal entry.
            string[] prompts = new string[]
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };

            // Create a Random object to use when selecting a random prompt.
            Random random = new Random();

            // Set quit to false to start the menu loop.
            bool quit = false;
            
            while (!quit)
            {
                // Display the menu options.
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Save");
                Console.WriteLine("4. Load");
                Console.WriteLine("5. Quit");

                // Prompt for and read in the user's choice.
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                // Perform an action based on the user's choice.
                switch (choice)
                {
                    case "1":
                        // Write a new journal entry.

                        // Select a random prompt and display it to the user.
                        int promptIndex = random.Next(prompts.Length);
                        string prompt = prompts[promptIndex];
                        Console.WriteLine(prompt);

                        // Read in the user's response and create a new Entry object with their response as its text.
                        string text = Console.ReadLine();
                        Entry entry = new Entry(text);

                        // Add the new entry to the journal and save it to file.
                        journal.AddEntry(entry);
                        break;
                    case "2":
                        // Display all journal entries.

                        journal.DisplayEntries();
                        break;
                    case "3":
                        // Save all journal entries to file.

                        journal.SaveEntries();
                        break;
                    case "4":
                        // Load all journal entries from file.

                        journal.LoadEntries();
                        break;
                    case "5":
                        // Quit the program.

                        quit = true;
                        break;
                    default:
                        // Invalid choice.

                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
