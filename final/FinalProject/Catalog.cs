using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    // A class that represents a catalog of items in the library
    public class Catalog
    {
        // Field
        private List<Item> items; // A list of items in the catalog

        // Property
        public List<Item> Items // Gets or sets the list of items in the catalog
        {
            get { return items; }
            set { items = value; }
        }

        // Methods
        public void DisplayItems() // Displays all the items in the catalog with their descriptions and statuses
        {
            Console.WriteLine("Items in the catalog:");
            foreach (Item item in items)
            {
                Console.WriteLine(item.GetDescription());
                Console.WriteLine();
            }
        }

        public Item SearchItem(string title) // Searches for an item in the catalog by its title and returns it if found, otherwise returns null
        {
            foreach (Item item in items)
            {
                if (item.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }
            return null;
        }

        public void BorrowItem(Item item, User user) // Borrows an item from the catalog by changing its status to false and creating a new borrowing record with a due date. Also checks if the user has any fines and asks them to pay them before borrowing. If the item is not available, prints a message to inform the user. If the item is not found, prints a message to inform the user. If the user is not found, prints a message to inform the user. If there is any other error, prints a message to inform the user.
        {
            try
            {
                if (item != null && user != null)
                {
                    if (item.Status == true)
                    {
                        // TODO: Add some logic to check if the user has any fines and ask them to pay them before borrowing.
                        item.Borrow();
                        DateTime dueDate = DateTime.Now.AddDays(14); // The due date is 14 days from now
                        Borrowing borrowing = new Borrowing(); // Create a new borrowing record
                        borrowing.ItemId = item.Id;
                        borrowing.UserId = user.Id;
                        borrowing.DueDate = dueDate;
                        // TODO: Add some logic to store the borrowing record in a database or a file.
                        Console.WriteLine($"The due date for {item.Title} is {dueDate.ToShortDateString()}.");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Title} is not available.");
                    }
                }
                else
                {
                    if (item == null)
                    {
                        Console.WriteLine("The item is not found.");
                    }
                    if (user == null)
                    {
                        Console.WriteLine("The user is not found.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }

        public void ReturnItem(Item item, User user) // Returns an item to the catalog by changing its status to true and deleting the borrowing record. Also checks if the user has any fines and asks them to pay them before returning. If the item is not borrowed by the user, prints a message to inform the user. If the item is not found, prints a message to inform the user. If the user is not found, prints a message to inform the user. If there is any other error, prints a message to inform the user.
        {
            try
            {
                if (item != null && user != null)
                {
                    // TODO: Add some logic to find the borrowing record that matches the item and the user in a database or a file.
                    Borrowing borrowing = null; // This is just a placeholder, you should replace it with the actual borrowing record.
                    if (borrowing != null)
                    {
                        item.Return();
                        // TODO: Add some logic to delete the borrowing record from the database or the file.
                        // TODO: Add some logic to check if the user has any fines and ask them to pay them before returning.
                        Console.WriteLine($"You have returned {item.Title}.");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Title} is not borrowed by you.");
                    }
                }
                else
                {
                    if (item == null)
                    {
                        Console.WriteLine("The item is not found.");
                    }
                    if (user == null)
                    {
                        Console.WriteLine("The user is not found.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }
    }
} 
