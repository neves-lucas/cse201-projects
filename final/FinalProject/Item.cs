using System;

namespace LibraryManagementSystem
{
    // An abstract base class that represents an item in the library
    public abstract class Item
    {
        // Fields
        private int id; // The ID of the item
        private string title; // The title of the item
        private bool status; // The status of the item (true for available, false for borrowed)

        // Properties
        public int Id // Gets or sets the ID of the item
        {
            get { return id; }
            set { id = value; }
        }

        public string Title // Gets or sets the title of the item
        {
            get { return title; }
            set { title = value; }
        }

        public bool Status // Gets or sets the status of the item
        {
            get { return status; }
            set { status = value; }
        }

        // Methods
        public abstract string GetDescription(); // Returns a string with information about the item. Must be implemented by subclasses.
        public abstract void Borrow(); // Changes the status of the item to false. Must be implemented by subclasses.
        public abstract void Return(); // Changes the status of the item to true. Must be implemented by subclasses.
    }
}
