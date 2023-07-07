using System;

namespace LibraryManagementSystem
{
    // A class that represents the main program
    public class Program
    {
        // A static field that stores an instance of the catalog
        private static Catalog catalog;

        // A static method that creates and returns an instance of the catalog
        private static Catalog CreateCatalog()
        {
            Catalog catalog = new Catalog(); // Create a new catalog
            catalog.Items = new List<Item>(); // Create a new list of items

            // Create some sample items and add them to the catalog
            Book book1 = new Book();
            book1.Id = 1;
            book1.Title = "The Catcher in the Rye";
            book1.Author = "J.D. Salinger";
            book1.Isbn = "9780316769488";
            book1.Status = true;
            catalog.Items.Add(book1);

            Book book2 = new Book();
            book2.Id = 2;
            book2.Title = "The Hitchhiker's Guide to the Galaxy";
            book2.Author = "Douglas Adams";
            book2.Isbn = "9780345391803";
            book2.Status = true;
            catalog.Items.Add(book2);

            FictionBook fictionBook1 = new FictionBook();
            fictionBook1.Id = 3;
            fictionBook1.Title = "The Lord of the Rings";
            fictionBook1.Author = "J.R.R. Tolkien";
            fictionBook1.Isbn = "9780618640157";
            fictionBook1.Genre = "Fantasy";
            fictionBook1.Status = true;
            catalog.Items.Add(fictionBook1);

            FictionBook fictionBook2 = new FictionBook();
            fictionBook2.Id = 4;
            fictionBook2.Title = "Harry Potter and the Philosopher's Stone";
            fictionBook2.Author = "J.K. Rowling";
            fictionBook2.Isbn = "9780747532699";
            fictionBook2.Genre = "Fantasy";
            fictionBook2.Status = true;
            catalog.Items.Add(fictionBook2);

            DVD dvd1 = new DVD();
            dvd1.Id = 5;
            dvd1.Title = "The Matrix";
            dvd1.Director = "The Wachowskis";
            dvd1.Actors = new string[] { "Keanu Reeves", "Laurence Fishburne", "Carrie-Anne Moss" };
            dvd1.Status = true;
            catalog.Items.Add(dvd1);

            DVD dvd2 = new DVD();
            dvd2.Id = 6;
            dvd2.Title = "The Lion King";
            dvd2.Director = "Roger Allers and Rob Minkoff";
            dvd2.Actors = new string[] { "Matthew Broderick", "James Earl Jones", "Jeremy Irons" };
            dvd2.Status = true;
            catalog.Items.Add(dvd2);

            Magazine magazine1 = new Magazine();
            magazine1.Id = 7;
            magazine1.Title = "National Geographic";
            magazine1.Issue = 1;
            magazine1.Year = 2023;
            magazine1.Status = true;
            catalog.Items.Add(magazine1);

            Magazine magazine2 = new Magazine();
            magazine2.Id = 8;
            magazine2.Title = "Time";
            magazine2.Issue = 2;
            magazine2.Year = 2023;
            magazine2.Status = true;
            catalog.Items.Add(magazine2);

            return catalog; // Return the catalog
        }

        // A static method that displays the main menu and returns the user's choice
        private static int DisplayMenu()
        {
            Console.WriteLine("Welcome to the Library Management System!");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Search for an item by title");
            Console.WriteLine("2. Search for an item by author/director");
            Console.WriteLine("3. Display all items");
            Console.WriteLine("4. Borrow an item");
            Console.WriteLine("5. Return an item");
            Console.WriteLine("6. Exit");
            Console.Write("Your choice: ");
            
            // Read the user's input and convert it to an integer
            int choice = Convert.ToInt32(Console.ReadLine());
            
            // Return the user's choice
            return choice;
        }

        // A static method that searches for an item by title and displays the result
        private static void SearchByTitle()
        {
            Console.Write("Enter the title of the item: ");
            
            // Read the user's input
            string title = Console.ReadLine();
            
            // Call the catalog's SearchByTitle method and store the result in a list
            List<Item> items = catalog.SearchByTitle(title);
            
            // Check if the list is empty or not
            if (items.Count == 0)
            {
                // If the list is empty, display a message that no items were found
                Console.WriteLine("No items were found with that title.");
            }
            else
            {
                // If the list is not empty, display a message that some items were found
                Console.WriteLine($"Found {items.Count} item(s) with that title:");
                
                // Loop through the list and display each item's details
                foreach (Item item in items)
                {
                    item.DisplayDetails();
                    Console.WriteLine();
                }
            }
        }

        // A static method that searches for an item by author/director and displays the result
        private static void SearchByAuthorDirector()
        {
            Console.Write("Enter the name of the author or director: ");
            
            // Read the user's input
            string name = Console.ReadLine();
            
            // Call the catalog's SearchByAuthorDirector method and store the result in a list
            List<Item> items = catalog.SearchByAuthorDirector(name);
            
            // Check if the list is empty or not
            if (items.Count == 0)
            {
                // If the list is empty, display a message that no items were found
                Console.WriteLine("No items were found with that author or director.");
            }
            else
            {
                // If the list is not empty, display a message that some items were found
                Console.WriteLine($"Found {items.Count} item(s) with that author or director:");
                
                // Loop through the list and display each item's details
                foreach (Item item in items)
                {
                    item.DisplayDetails();
                    Console.WriteLine();
                }
            }
        }

        // A static method that displays all items in the catalog
        private static void DisplayAllItems()
        {
            // Call the catalog's DisplayAllItems method
            catalog.DisplayAllItems();
        }

        // A static method that borrows an item from the catalog
        private static void BorrowItem()
        {
            Console.Write("Enter your name: ");
            
            // Read the user's name
            string userName = Console.ReadLine();
            
            Console.Write("Enter your email: ");
            
            // Read the user's email
            string userEmail = Console.ReadLine();
            
            Console.Write("Enter the id of the item you want to borrow: ");
            
            // Read the user's input and convert it to an integer
            int itemId = Convert.ToInt32(Console.ReadLine());
            
            // Call the catalog's BorrowItem method and store the result in a boolean variable
            bool success = catalog.BorrowItem(itemId, userName, userEmail);
            
            // Check if the operation was successful or not
            if (success)
            {
                // If successful, display a message that the item was borrowed
                Console.WriteLine("You have successfully borrowed the item.");
            }
            else
            {
                // If not successful, display a message that the item was not available or not found
                Console.WriteLine("The item is either not available or not found.");
            }
        }

        // A static method that returns an item to the catalog
        private static void ReturnItem()
        {
            Console.Write("Enter the id of the item you want to return: ");
            
            // Read the user's input and convert it to an integer
            int itemId = Convert.ToInt32(Console.ReadLine());
            
            // Call the catalog's ReturnItem method and store the result in a boolean variable
            bool success = catalog.ReturnItem(itemId);
            
            // Check if the operation was successful or not
            if (success)
            {
                // If successful, display a message that the item was returned
                Console.WriteLine("You have successfully returned the item.");
            }
            else
            {
                // If not successful, display a message that the item was not found
                Console.WriteLine("The item was not found.");
            }
        }

        // The main method of the program
        public static void Main(string[] args)
        {
            // Create an instance of the catalog and assign it to the static field
            catalog = CreateCatalog();
            
            // Declare a boolean variable to store the exit condition
            bool exit = false;
            
            // Loop until the user chooses to exit
            while (!exit)
            {
                // Display the main menu and get the user's choice
                int choice = DisplayMenu();
                
                // Use a switch statement to execute different actions based on the user's choice
                switch (choice)
                {
                    case 1: // Search by title
                        SearchByTitle();
                        break;
                    case 2: // Search by author/director
                        SearchByAuthorDirector();
                        break;
                    case 3: // Display all items
                        DisplayAllItems();
                        break;
                    case 4: // Borrow an item
                        BorrowItem();
                        break;
                    case 5: // Return an item
                        ReturnItem();
                        break;
                    case 6: // Exit
                        exit = true; // Set the exit condition to true
                        Console.WriteLine("Thank you for using the Library Management System!"); // Display a farewell message
                        break;
                    default: // Invalid choice
                        Console.WriteLine("Invalid choice. Please try again."); // Display an error message
                        break;
                }
                
                // If the user has not chosen to exit, display a blank line and wait for a key press before continuing the loop
                if (!exit)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}