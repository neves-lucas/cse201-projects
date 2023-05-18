# Journal Program

This program allows the user to write, save, and load journal entries.

## Classes

The program consists of three classes: `Entry`, `Journal`, and `Program`.

### Entry

The `Entry` class represents a single journal entry. It has two properties: `Text` for the entry text and `Date` for the date and time the entry was created. The `ToString` method returns a string representation of the entry.

### Journal

The `Journal` class manages a list of journal entries. It has methods to add entries, display all entries, save entries to a file, and load entries from a file.

### Program

The `Program` class contains the `Main` method that runs when the program starts. It displays a menu that allows the user to write a new journal entry, display all entries, save entries to a file, load entries from a file, or quit the program. When writing a new journal entry, the user is given a random prompt to respond to.

## Usage

To use the program, compile and run the `Program.cs` file. Follow the on-screen prompts to use the menu options.