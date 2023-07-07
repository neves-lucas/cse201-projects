using System;

namespace LibraryManagementSystem
{
    // A class that represents a fine imposed on a user in the library
    public class Fine
    {
        // Fields
        private int id; // The ID of the fine
        private int userId; // The ID of the user who is fined
        private decimal amount; // The amount of the fine in currency units
        private string reason; // The reason of the fine (such as late return, damage, etc.)

        // Properties
        public int Id // Gets or sets the ID of the fine
        {
            get { return id; }
            set { id = value; }
        }

        public int UserId // Gets or sets the ID of the user who is fined
        {
            get { return userId; }
            set { userId = value; }
        }

        public decimal Amount // Gets or sets the amount of the fine in currency units
        {
            get { return amount; }
            set { amount = value; }
        }

        public string Reason // Gets or sets the reason of the fine (such as late return, damage, etc.)
        {
            get { return reason; }
            set { reason = value; }
        }

        // Methods
        public new string ToString() // Returns a string with information about 
                                 // the fine's ID, user ID, amount, reason, etc.
        {
            return $"Fine: {Id}\nUser ID: {UserId}\nAmount: {Amount}\nReason: {Reason}";
        }
    }
}
