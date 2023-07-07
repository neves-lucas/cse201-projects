using System;

namespace LibraryManagementSystem
{
    // A class that represents a DVD in the library
    public class DVD : Item
    {
        // Fields
        private string director; // The name of the director of the DVD
        private string[] actors; // An array of names of the actors in the DVD

        // Properties
        public string Director // Gets or sets the name of the director of the DVD
        {
            get { return director; }
            set { director = value; }
        }

        public string[] Actors // Gets or sets the array of names of the actors in the DVD
        {
            get { return actors; }
            set { actors = value; }
        }

        // Methods
        public override string GetDescription() // Returns a string with information about
                                                // the DVD's title, director, actors, etc.
        {
            return $"DVD: {Title}\nDirector: {Director}\nActors: {string.Join(", ", Actors)}\nStatus: {(Status ? "Available" : "Borrowed")}";
        }

        public override void Borrow() // Changes the status of the DVD to false and prints a message to confirm the borrowing.
        {
            Status = false;
            Console.WriteLine($"You have borrowed {Title} by {Director}.");
        }

        public override void Return() // Changes the status of the DVD to true and prints a message to confirm the return.
        {
            Status = true;
            Console.WriteLine($"You have returned {Title} by {Director}.");
        }
    }
}
