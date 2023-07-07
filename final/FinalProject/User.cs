using System;

namespace LibraryManagementSystem
{
    // A class that represents a user of the library
    public class User
    {
        // Fields
        private int id; // The ID of the user
        private string name; // The name of the user
        private string address; // The address of the user

        // Properties
        public int Id // Gets or sets the ID of the user
        {
            get { return id; }
            set { id = value; }
        }

        public string Name // Gets or sets the name of the user
        {
            get { return name; }
            set { name = value; }
        }

        public string Address // Gets or sets the address of the user
        {
            get { return address; }
            set { address = value; }
        }

        // Methods
        public new string ToString() // Returns a string with information about 
                                         // the user's ID, name, address, etc.
        {
            return $"User: {Id}\nName: {Name}\nAddress: {Address}";
        }
    }
}
