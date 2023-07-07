using System;

namespace LibraryManagementSystem
{
    // A class that represents a magazine in the library
    public class Magazine : Item
    {
        // Fields
        private int issueNumber; // The issue number of the magazine
        private DateTime publicationDate; // The publication date of the magazine

        // Properties
        public int IssueNumber // Gets or sets the issue number of the magazine
        {
            get { return issueNumber; }
            set { issueNumber = value; }
        }

        public DateTime PublicationDate // Gets or sets the publication date of the magazine
        {
            get { return publicationDate; }
            set { publicationDate = value; }
        }

        // Methods
        public override string GetDescription() // Returns a string with information about
                                                // the magazine's title, issue number, publication date, etc.
        {
            return $"Magazine: {Title}\nIssue Number: {IssueNumber}\nPublication Date: {PublicationDate.ToShortDateString()}\nStatus: {(Status ? "Available" : "Borrowed")}";
        }

        public override void Borrow() // Changes the status of the magazine to false and prints a message to confirm the borrowing.
        {
            Status = false;
            Console.WriteLine($"You have borrowed {Title} (Issue {IssueNumber}).");
        }

        public override void Return() // Changes the status of the magazine to true and prints a message to confirm the return.
        {
            Status = true;
            Console.WriteLine($"You have returned {Title} (Issue {IssueNumber}).");
        }
    }
}
