using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace LibraryManagementSystem 
{
    public class Program
    {
        private static string UserMenu()
        {
            Console.Clear();
            Console.WriteLine("Are you a USER or a LIBRARIAN? ");
            Console.WriteLine("Your answer: ");
            
            string userRole = Console.ReadLine();
            
            return userRole;
        }
        
        private static int DisplayLibrarianMenu() 
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Welcome, Librarian.");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("");
            Console.WriteLine("1. Add new item");
            Console.WriteLine("2. Remove an item");
            Console.WriteLine("3. Add new user");
            Console.WriteLine("4. Remove an user");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write("Your choice: ");
            Console.WriteLine();
            
            int choice = int.Parse(Console.ReadLine());
            
            return choice;
        }
        
        private static int DisplayUserMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Welcome, User.");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("");
            Console.WriteLine("1. Search for an item by title");
            Console.WriteLine("2. Search for an item by author/director");
            Console.WriteLine("3. Display all items");
            Console.WriteLine("4. Borrow an item");
            Console.WriteLine("5. Return an item");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
            Console.Write("Your choice: ");
            Console.WriteLine();
            
            int choice = int.Parse(Console.ReadLine());
            
            return choice;
        }

        private static void SearchByTitle()  
        {
            Console.Write("Enter the title to search for: ");
            string searchTitle = Console.ReadLine();

            List<Item> results = new List<Item>();

            Database db = new Database();

            string[] lines = File.ReadAllLines(db.GetCatalogFile());

            List<string> linesList = lines.ToList();

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                
                if(parts.Length < 2) {
                    Console.WriteLine("Invalid data row: " + line);
                    continue;
                }

                string title = parts[2];

                if(title.Equals(searchTitle, StringComparison.OrdinalIgnoreCase))
                {
                    if(parts.Length < 10)
                    {
                        Console.WriteLine("Item found: " + line);
                        continue;
                    }

                    try {
                        Item item = CreateItemFromCSV(parts);
                        results.Add(item);
                    }
                    catch (Exception ex) {
                        Console.WriteLine("Error creating item: " + ex.Message);
                    }
                }
            }

        }

        private static void SearchByAuthorDirector()
        {
            Console.Write("Enter the author/director to search for: ");
            string searchString = Console.ReadLine();

            Database db = new Database();

            string[] lines = File.ReadAllLines(db.GetCatalogFile());
            List<string> linesList = lines.ToList();

            List<Item> results = new List<Item>();

            foreach (string line in linesList)
            {
                string[] parts = line.Split(',');

                if(parts.Length < 4) {
                    Console.WriteLine("Invalid data row: " + line);
                    continue;
                }

                string author = parts[4];

                if(author.Equals(searchString, StringComparison.OrdinalIgnoreCase))
                {
                    if(parts.Length < 10) {
                        Console.WriteLine("Item found: " + line);
                        continue;
                    }

                    try {
                        Item item = CreateItemFromCSV(parts);
                        results.Add(item);
                    }
                    catch (Exception ex) {
                        Console.WriteLine("Error showing item: " + ex.Message);
                    }
                }

            }
            
        }

        private static void DisplayAllItems()
        {
            Database db = new Database();

            string[] lines = File.ReadAllLines(db.GetCatalogFile());
            List<string> linesList = lines.ToList();

            Console.WriteLine("All items:");

            foreach (string line in linesList)
            {
                string[] parts = line.Split(',');
                
                Item item = CreateItemFromCSV(parts);

                Console.WriteLine(item.GetDescription());
            }
        }

        private static void BorrowItem()
        {
            Console.Write("Enter ID of item to borrow: ");
            int itemId = int.Parse(Console.ReadLine());

            Item item = GetItemById(itemId);

            if (item == null)
            {
                Console.WriteLine("Error! Invalid item ID.");
                return;
            }

            if (!item.GetStatus())
            {
                Console.WriteLine("Error! Item is already borrowed.");
                return;
            }

            item.Borrow();

            Console.WriteLine("You have borrowed: " + item.GetTitle());

            Database db = new Database();
            db.UpdateItem(item);
        }

        private static void ReturnItem() 
        {
            Console.Write("Enter ID of item to return: ");
            int itemId = int.Parse(Console.ReadLine());

            Item item = GetItemById(itemId);

            if (item == null) 
            {
                Console.WriteLine("Error! Invalid item ID.");
                return;
            }

            if (item.GetStatus())
            {
                Console.WriteLine("Error! Item is not borrowed.");
                return; 
            }

            item.Return();
            
            Console.WriteLine("You have returned: " + item.GetTitle());

            Database db = new Database();
            db.UpdateItem(item);
        }

        private static Item CreateItemFromCSV(string[] data)
        {
            int id = int.Parse(data[0]);
            string type = data[1];
            string title = data[2];
            string status = data[3];
            string author = data[4];
            string isbn = data[5];
            string genre = data[6];
            string director = data[7];
            string actors = data[8];
            int issueNumber = int.Parse(data[9]);
            string publicationDate = data[10];

            Item item = null;

            if (type == "Book") {
                Book book = new Book();
                book.SetId(id);
                book.SetType("Book");
                book.SetTitle(title);
                book.SetStatus(true);
                book.SetAuthor(author);
                book.SetIsbn(isbn);
                item = book;
            }

            else if (type == "FictionBook") {
                FictionBook fictionBook = new FictionBook();
                fictionBook.SetId(id);
                fictionBook.SetType("FictionBook");
                fictionBook.SetTitle(title);
                fictionBook.SetStatus(true);
                fictionBook.SetAuthor(author);
                fictionBook.SetIsbn(isbn);
                fictionBook.SetGenre(genre);
                item = fictionBook;
            }

            else if (type == "DVD") {
                DVD dvd = new DVD();
                dvd.SetId(id);
                dvd.SetType("DVD");
                dvd.SetTitle(title);
                dvd.SetStatus(true);
                dvd.SetDirector(director);
                dvd.SetActors(actors);
                item = dvd;
            }

            else if (type == "Magazine") {
                Magazine magazine = new Magazine();
                magazine.SetId(id);
                magazine.SetType("Magazine");
                magazine.SetTitle(title);
                magazine.SetStatus(true);
                magazine.SetIssueNumber(issueNumber);
                magazine.SetPublicationDate(publicationDate);
                item = magazine;
            }
            return item;
        }

        private static User CreateUserFromCSV(string[] data)
        {
            int id = int.Parse(data[0]);
            string name = data[1];
            string address = data[2];

            User user = new User();
            user.SetId(id);
            user.SetName(name);
            user.SetAddress(address);

            return user;
        }

        private static User GetUserById(int id)
        {
            Database db = new Database();

            string[] lines = File.ReadAllLines(db.GetUsersFile());
            List<string> linesList = lines.ToList();

            foreach (string line in linesList) 
            {
                string[] parts = line.Split(',');
                
                if (parts[0] == id.ToString())
                {
                User user = CreateUserFromCSV(parts);
                return user; 
                }
            }

            return null; 
        }

        private static Item GetItemById(int id)
        {
            Database db = new Database();

            string[] lines = File.ReadAllLines(db.GetCatalogFile());
            List<string> linesList = lines.ToList();

            foreach (string line in linesList)
            {
                string[] parts = line.Split(',');
                
                if (parts[0] == id.ToString())  
                {
                Item item = CreateItemFromCSV(parts);
                return item;
                }
            }

            return null;
        }

        static void Main(string[] args)
        {   
            bool exit = false;
            
            while (!exit)
            {
                string userRole = UserMenu();
                
                if (userRole == "Librarian")
                {
                    int choice = DisplayLibrarianMenu();
                    Librarian librarian = new Librarian();
                    switch(choice)
                    {
                        case 1:
                            // Add new item
                            Console.WriteLine("Enter the data of the item: ");
                            Console.WriteLine("(All together, only separated by a comma ',')");
                            Console.WriteLine("Order: ID > Type(Book, Magazine, FictionBook or DVD) > Title > Status(True or false)");
                            Console.WriteLine("Author > ISBN > Genre > Director(same as author) > Actors > Issue Number > Date");
                            Console.WriteLine();
                            string itemData = Console.ReadLine();
                            Item newItem = CreateItemFromCSV(itemData.Split(','));
                            librarian.AddItem(newItem);
                            break;

                        case 2:
                            // Remove item 
                            Console.Write("Enter ID of item to remove: ");
                            int removeItemId = int.Parse(Console.ReadLine());
                            Item itemToRemove = GetItemById(removeItemId);
                            librarian.RemoveItem(itemToRemove);
                            break;

                        case 3:
                            // Add new user
                            Console.Write("Enter new user data: ");
                            string userData = Console.ReadLine();
                            User newUser = CreateUserFromCSV(userData.Split(','));
                            librarian.AddUser(newUser);
                            break;

                        case 4:  
                            // Remove user
                            Console.Write("Enter ID of user to remove: ");
                            int removeUserId = int.Parse(Console.ReadLine());
                            User userToRemove = GetUserById(removeUserId);
                            librarian.RemoveUser(userToRemove);
      break;
                    }
                }
                else if (userRole == "User")
                {
                    int choice = DisplayUserMenu();
                    
                    switch(choice)
                    {
                        case 1:
                            SearchByTitle();
                            break;
                        case 2:
                            SearchByAuthorDirector();
                            break;
                        case 3:
                            DisplayAllItems();
                            break;
                        case 4:
                            BorrowItem();
                            break;
                        case 5:
                            ReturnItem();
                            break;
                    }
                }
                else 
                {
                    Console.WriteLine("Invalid user role. Please enter either User or Librarian. ");
                    break;
                }
                
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