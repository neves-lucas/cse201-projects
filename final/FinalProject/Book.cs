using System;

namespace LibraryManagementSystem
{
    // A class that represents a book in the library
    public class Book : Item
    {
        // Fields
        private string author; // The name of the author of the book
        private string isbn; // The ISBN of the book

        // Properties
        public string Author // Gets or sets the name of the author of the book
        {
            get { return author; }
            set { author = value; }
        }

        public string Isbn // Gets or sets the ISBN of the book
        {
            get { return isbn; }
            set { isbn = value; }
        }

        // Methods
        public override string GetDescription() // Returns a string with information about the book's title, author, ISBN, etc.
        {
            return $"Book: {Title}\nAuthor: {Author}\nISBN: {Isbn}\nStatus: {(Status ? "Available" : "Borrowed")}";
        }

        public override void Borrow() // Changes the status of the book to false and prints a message to confirm the borrowing.
        {
            Status = false;
            Console.WriteLine($"You have borrowed {Title} by {Author}.");
        }

        public override void Return() // Changes the status of the book to true and prints a message to confirm the return.
        {
            Status = true;
            Console.WriteLine($"You have returned {Title} by {Author}.");
        }
    }
}
