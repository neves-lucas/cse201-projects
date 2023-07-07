using System;

namespace LibraryManagementSystem
{
    // A class that represents a librarian of the library
    public class Librarian : User
    {
        // Fields
        private string password; // The password of the librarian
        private string role; // The role of the librarian (such as manager, assistant, etc.)

        // Properties
        public string Password // Gets or sets the password of the librarian
        {
            get { return password; }
            set { password = value; }
        }

        public string Role // Gets or sets the role of the librarian
        {
            get { return role; }
            set { role = value; }
        }

        // Methods
        public new string ToString() // Returns a string with information about 
                                          // the librarian's ID, name, address, password, role, etc.
        {
            return $"Librarian: {Id}\nName: {Name}\nAddress: {Address}\nPassword: {Password}\nRole: {Role}";
        }

        public void AddItem(Item item) // Adds an item to the catalog
        {
            // TODO: Add some logic to add an item to the catalog and print a message to confirm the addition.
        }

        public void RemoveItem(Item item) // Removes an item from the catalog
        {
            // TODO: Add some logic to remove an item from the catalog and print a message to confirm the removal.
        }

        public void ManageUser(User user) // Performs some actions on a user, such as creating, updating, deleting, etc.
        {
            // TODO: Add some logic to perform some actions on a user and print a message to confirm the action.
        }
    }
}
