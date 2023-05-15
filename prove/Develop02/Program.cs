using System;

namespace Journal
{
    // The Program class contains the Main method that runs when the program starts.
    class Program
    {
        // The Main method is the entry point for the program.
        static void Main(string[] args)
        {
            // Display a welcome message and create a new Journal object.
            Console.WriteLine("Welcome to your journal!");
            Journal journal = new Journal();

            // Set quit to false to start the menu loop.
            bool quit = false;

            // Loop until the user chooses to quit.
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
                        string prompt = Entry.GetRandomPrompt();
                        Console.WriteLine(prompt);

                        // Read in the user's response and create a new Entry object with their response as its text and the selected prompt as its prompt.
                        string text = Console.ReadLine();
                        Entry entry = new Entry(text, prompt);

                        // Add the new entry to the journal.
                        journal.AddEntry(entry);
                        break;
                    case "2":
                        // Display all journal entries.

                        journal.DisplayEntries();
                        break;
                    case "3":
                        // Save all journal entries to file.

                        // Prompt for and read in the file name to save to.
                        Console.Write("Enter the file name to save to: ");
                        string saveFileName = Console.ReadLine();

                        // Save all entries in the journal to the specified file.
                        journal.SaveEntries(saveFileName);
                        break;
                    case "4":
                        // Load all journal entries from file.

                        // Prompt for and read in the file name to load from.
                        Console.Write("Enter the file name to load from: ");
                        string loadFileName = Console.ReadLine();

                        // Load all entries in the journal from the specified file.
                        journal.LoadEntries(loadFileName);
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
