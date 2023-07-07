using System;

namespace LibraryManagementSystem
{
    // A class that represents a fiction book in the library
    public class FictionBook : Book
    {
        // Fields
        private string genre; // The genre of the fiction book

        // Properties
        public string Genre // Gets or sets the genre of the fiction book
        {
            get { return genre; }
            set { genre = value; }
        }

        // Methods
        public override string GetDescription() // Returns a string with information about the fiction book's title, author, ISBN, genre, etc.
        {
            return $"Fiction Book: {Title}\nAuthor: {Author}\nISBN: {Isbn}\nGenre: {Genre}\nStatus: {(Status ? "Available" : "Borrowed")}";
        }

        public override void Borrow() // Calls the base class method and prints a message to recommend other books of the same genre.
        {
            base.Borrow();
            Console.WriteLine($"If you like {Genre}, you may also enjoy these books:");
            // TODO: Add some logic to display other books of the same genre from the catalog.
        }

        public override void Return() // Calls the base class method and prints a message to ask for feedback on the book.
        {
            base.Return();
            Console.WriteLine($"How did you like {Title} by {Author}?");
            // TODO: Add some logic to collect and store the feedback from the user.
        }
    }
}
