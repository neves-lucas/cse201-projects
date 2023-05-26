# Scripture Memorizer

This is a C# console application that helps users memorize scriptures by hiding random words in the text and prompting the user to recall the missing words. The difficulty of the game is customizable, and the scriptures are loaded from a plain text file.

## Classes

The program consists of four classes:

- Program.cs: This is the main class that runs the program logic. It creates a scripture manager object to handle the loading and hiding of scriptures. It also interacts with the user through the console and allows them to choose a difficulty level and quit the program.

- ScriptureManager.cs: This is a class that handles the loading and hiding of scriptures. It contains a list of scripture objects and a random number generator. It provides methods to load scriptures from a file, display scriptures on the console, check if all words in all scriptures are hidden, and hide three random words in each scripture that are not already hidden.

- Scripture.cs: This is a class that represents a scripture, including the reference and the text. It contains a scripture reference object and a list of scripture word objects. It provides methods to generate a list of scripture words from a given text, return the string representation of the scripture, check if all words in the scripture are hidden, and hide three random words in the scripture that are not already hidden.

- ScriptureReference.cs: This is a class that represents a scripture reference, such as "John 3:16" or "Proverbs 3:5-6". It contains the book name, the chapter number, the starting verse number, and the ending verse number. It provides constructors for single verse references and verse range references, and a method to return the string representation of the reference.

- ScriptureWord.cs: This is a class that represents a word in the scripture text. It contains the word itself and a boolean flag to indicate if the word is hidden or not. It provides a constructor to create a new word with the given word and hidden status, and a method to return the string representation of the word.
