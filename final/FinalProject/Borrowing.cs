using System;

namespace LibraryManagementSystem
{
    // A class that represents a borrowing transaction in the library
    public class Borrowing
    {
        // Fields
        private int id; // The ID of the borrowing transaction
        private int itemId; // The ID of the item that is borrowed
        private int userId; // The ID of the user who borrows the item
        private DateTime dueDate; // The due date of the borrowing transaction

        // Properties
        public int Id // Gets or sets the ID of the borrowing transaction
        {
            get { return id; }
            set { id = value; }
        }

        public int ItemId // Gets or sets the ID of the item that is borrowed
        {
            get { return itemId; }
            set { itemId = value; }
        }

        public int UserId // Gets or sets the ID of the user who borrows the item
        {
            get { return userId; }
            set { userId = value; }
        }

        public DateTime DueDate // Gets or sets the due date of the borrowing transaction
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        // Methods
        public new string ToString() // Returns a string with information about 
                                 // the borrowing transaction's ID, item ID, user ID, due date, etc.
        {
            return $"Borrowing: {Id}\nItem ID: {ItemId}\nUser ID: {UserId}\nDue Date: {DueDate.ToShortDateString()}";
        }
    }
}
