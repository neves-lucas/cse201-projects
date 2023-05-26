using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ScriptureMemorizer
{
 // The main program class
 class Program
 {
 // The main method
 static void Main(string[] args)
 {
 // Create a scripture manager object to handle the hiding of scriptures
 ScriptureManager scriptureManager = new ScriptureManager();

 // Create some scripture objects manually
 Scripture scripture1 = new Scripture(new ScriptureReference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
 
 // Add them to the list of scriptures
 scriptureManager.AddScripture(scripture1);

 // A boolean flag to indicate if the program should continue or not
 bool keepGoing = true;

 // A loop to run the program until the user quits or all words are hidden
 do
 {
 // Clear the console screen
 Console.Clear();

 // Display all scriptures
 scriptureManager.DisplayScriptures();

 // Check if all words in all scriptures are hidden
 if (scriptureManager.AllWordsHidden())
 {
 // End the program
 keepGoing = false;
 Console.WriteLine("[Program ended]");
 }
 else
 {
 // Prompt the user to press enter or type quit
 Console.Write("Press enter to hide three words or type 'quit' to end: ");
 string input = Console.ReadLine();

 // Check if the user typed quit
 if (input.ToLower() == "quit")
 {
 // End the program
 keepGoing = false;
 Console.WriteLine("\nGoodbye!");
 }
 else
 {
 // Hide three random words in each scripture that are not already hidden
 scriptureManager.HideRandomWords();
 }
 }
 } while (keepGoing); // Check the condition at the end of the loop 
 }
 }

 // A class to handle the hiding of scriptures
 class ScriptureManager
 {
 // A list of scripture objects
 private List<Scripture> scriptures;

 // A random number generator to select words to hide
 private Random random;

 // A constructor to create a new scripture manager object with an empty list of scriptures and a new random object
 public ScriptureManager()
 {
 scriptures = new List<Scripture>();
 random = new Random();
 }

 // A method to add a scripture object to the list of scriptures
 public void AddScripture(Scripture scripture)
 {
 scriptures.Add(scripture);
 }

 // A method to display all scriptures on the console screen
 public void DisplayScriptures()
 {
 foreach (Scripture scripture in scriptures)
 {
 Console.WriteLine(scripture + "\n");
 }
 }

 // A method to check if all words in all scriptures are hidden
 public bool AllWordsHidden()
 {
 foreach (Scripture scripture in scriptures)
 {
 if (scripture.AllWordsHidden() == false)
 {
 return false;
 }
 }

 return true;
 }

 // A method to hide three random words in each scripture that are not already hidden 
 public void HideRandomWords()
 { 
 foreach (Scripture scripture in scriptures)
 {
 scripture.HideRandomWords(random);
 } 
 } 
 } 
}