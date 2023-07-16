using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem {
    public class Program {
        private static Catalog catalog;

        private static Catalog CreateCatalog() {
            Catalog catalog = new Catalog();
            catalog.SetItems(new List < Item > ());

            List < string > lines = File.ReadAllLines("catalog.csv").ToList();

            foreach(string line in lines) {
                string[] values = line.Split(',');
                int id = int.Parse(values[0]);
                string title = values[1];
                string author = values[2];
                string publisher = values[3];
                int year = int.Parse(values[4]);
                string type = values[5];

                switch (type) {
                case "Book":
                    Book book = new Book();
                    book.SetId(id);
                    book.SetTitle(title);
                    book.SetAuthor(author);
                    book.SetPublisher(publisher);
                    book.SetYear(year);
                    book.SetStatus(true);
                    catalog.GetItems().Add(book);
                    break;

                case "FictionBook":
                    FictionBook fictionBook = new FictionBook();
                    fictionBook.SetId(id);
                    fictionBook.SetTitle(title);
                    fictionBook.SetAuthor(author);
                    fictionBook.SetPublisher(publisher);
                    fictionBook.SetYear(year);
                    fictionBook.SetGenre(values[6]);
                    fictionBook.SetStatus(true);
                    catalog.GetItems().Add(fictionBook);
                    break;

                case "DVD":
                    DVD dvd = new DVD();
                    dvd.SetId(id);
                    dvd.SetTitle(title);
                    dvd.SetDirector(author); // The author field is used for director in this case
                    dvd.SetActors(values[6].Split(';')); // The actors are separated by semicolons in the CSV file
                    dvd.SetStatus(true);
                    catalog.GetItems().Add(dvd);
                    break;

                case "Magazine":
                    Magazine magazine = new Magazine();
                    magazine.SetId(id);
                    magazine.SetTitle(title);
                    magazine.SetIssueNumber(int.Parse(values[6]));
                    magazine.SetPublicationDate(DateTime.Parse(values[7]));
                    magazine.SetStatus(true);
                    catalog.GetItems().Add(magazine);
                    break;

                default:
                    Console.WriteLine("Invalid item type.");
                    break;
                }
            }

            return catalog;
        }

        private static string UserMenu() {
            Console.Clear();
            Console.WriteLine("Are you a USER or a LIBRARIAN? ");
            Console.WriteLine("Your answer: ");

            string userRole = Console.ReadLine();

            return userRole;
        }
        private static int DisplayLibrarianMenu() {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Welcome, Librarian.");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Add new item");
            Console.WriteLine("2. Remove an item");
            Console.WriteLine("3. Add new user");
            Console.WriteLine("4. Remove an user");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write("Your choice: ");
            Console.WriteLine();

            int choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        private static int DisplayUserMenu() {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Welcome, User.");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Search for an item by title");
            Console.WriteLine("2. Search for an item by author/director");
            Console.WriteLine("3. Display all items");
            Console.WriteLine("4. Borrow an item");
            Console.WriteLine("5. Return an item");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
            Console.Write("Your choice: ");
            Console.WriteLine();

            int choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        private static void SearchByTitle() {
            Console.Write("Enter the title of the item: ");

            string title = Console.ReadLine();

            List < Item > items = catalog.GetItems().FindAll(item => item.GetTitle().Equals(title, StringComparison.OrdinalIgnoreCase));

            if (items.Count == 0) {
                Console.WriteLine("No items were found with that title.");
            } else {
                Console.WriteLine($"Found {items.Count} item(s) with that title:");

                foreach(Item item in items) {
                    Console.WriteLine(item.GetDescription());
                    Console.WriteLine();
                }
            }
        }

        private static void SearchByAuthorDirector() {
            Console.Write("Enter the name of the author or director: ");

            string name = Console.ReadLine();

            var items = from item in catalog.GetItems()
            where item.GetAuthor().Equals(name, StringComparison.OrdinalIgnoreCase) ||
                (item is DVD && (item as DVD).GetDirector().Equals(name, StringComparison.OrdinalIgnoreCase))
            select item;

            if (items.Count() == 0) {
                Console.WriteLine("No items were found with that author or director.");
            } else {
                Console.WriteLine($"Found {items.Count()} item(s) with that author or director:");

                foreach(Item item in items) {
                    Console.WriteLine(item.GetDescription());
                    Console.WriteLine();
                }
            }
        }

        private static void DisplayAllItems() {
            catalog.DisplayItems();
        }

        private static void BorrowItem() {
            Console.Write("Enter your user name: ");

            string userName = Console.ReadLine();

            User user = Database.SearchUser(userName);

            if (user == null) {

                Random random = new Random();
                int id = random.Next(1000, 9999);

                Console.Write("Enter your address: ");
                string address = Console.ReadLine();

                user = new User();
                user.SetId(id);
                user.SetName(userName);
                user.SetAddress(address);

                Database.AddUser(user);

                Console.WriteLine($"The user {user.GetName()} has been created.");
            }

            Console.Write("Enter the id of the item you want to borrow: ");

            string itemId = Console.ReadLine();

            Item item = catalog.SearchItem(itemId);

            bool success = catalog.BorrowItem(item, user);

            if (success) {
                Database.UpdateItem(item); // Update the status of the item in the CSV file
                Console.WriteLine("You have successfully borrowed the item.");
            } else {
                Console.WriteLine("The item is either not available or not found.");
            }

            static void Main(string[] args) {
                catalog = CreateCatalog();

                bool exit = false;

                while (!exit) {
                    string userRole = UserMenu();

                    if (userRole == "Librarian") {

                        int choice = DisplayLibrarianMenu();

                        switch (choice) {
                            case 1:
                                // The code for adding a new item is added
                                Console.WriteLine("What type of item do you want to add?");
                                Console.WriteLine("1. Book");
                                Console.WriteLine("2. Fiction book");
                                Console.WriteLine("3. Magazine");
                                Console.WriteLine("4. DVD");

                                int type = int.Parse(Console.ReadLine());

                                switch (type) {
                                    case 1:
                                        Random randomIdBook = new Random();
                                        int bookId = randomIdBook.Next(1000, 9999);

                                        Console.Write("Enter the title of the book: ");
                                        string title = Console.ReadLine();
                                        Console.Write("Enter the author of the book: ");
                                        string author = Console.ReadLine();
                                        Console.Write("Enter the publisher of the book: ");
                                        string publisher = Console.ReadLine();
                                        Console.Write("Enter the year of publication of the book: ");
                                        int year = int.Parse(Console.ReadLine());

                                        Book book = new Book();
                                        book.SetId(bookId);
                                        book.SetTitle(title);
                                        book.SetAuthor(author);
                                        book.SetPublisher(publisher);
                                        book.SetYear(year);
                                        book.SetStatus(true);
                                        Database.AddItem(book);

                                        break;
                                    case 2:
                                        Random randomIdFic = new Random();
                                        int ficId = randomIdFic.Next(1000, 9999);

                                        Console.Write("Enter the title of the fiction book: ");
                                        string ficTitle = Console.ReadLine();
                                        Console.Write("Enter the author of the fiction book: ");
                                        string ficAuthor = Console.ReadLine();
                                        Console.Write("Enter the publisher of the fiction book: ");
                                        string ficPublisher = Console.ReadLine();
                                        Console.Write("Enter the year of publication of the fiction book: ");
                                        int ficYear = int.Parse(Console.ReadLine());
                                        Console.Write("Enter the genre of the fiction book: ");
                                        string genre = Console.ReadLine();

                                        FictionBook fictionBook = new FictionBook();
                                        fictionBook.SetId(ficId);
                                        fictionBook.SetTitle(ficTitle);
                                        fictionBook.SetAuthor(ficAuthor);
                                        fictionBook.SetPublisher(ficPublisher);
                                        fictionBook.SetYear(ficYear);
                                        fictionBook.SetGenre(genre);
                                        fictionBook.SetStatus(true);
                                        Database.AddItem(fictionBook);

                                        break;

                                    case 3:
                                        Random randomIdMag = new Random();
                                        int magId = randomIdMag.Next(1000, 9999);

                                        Console.Write("Enter the title of the magazine: ");
                                        string magTitle = Console.ReadLine();
                                        Console.Write("Enter the issue number of the magazine: ");
                                        int issueNumber = int.Parse(Console.ReadLine());
                                        Console.Write("Enter the publication date of the magazine (yyyy/mm/dd): ");
                                        DateTime publicationDate = DateTime.Parse(Console.ReadLine());

                                        Magazine magazine = new Magazine();
                                        magazine.SetId(magId);
                                        magazine.SetTitle(magTitle);
                                        magazine.SetIssueNumber(issueNumber);
                                        magazine.SetPublicationDate(publicationDate);
                                        magazine.SetStatus(true);
                                        Database.AddItem(magazine);

                                        break;
                                    
                                    case 4:
                                        Random randomIdDvd = new Random();
                                        int dvdId = randomIdDvd.Next(1000, 9999);

                                        Console.Write("Enter the title of the DVD: ");
                                        string dvdTitle = Console.ReadLine();
                                        Console.Write("Enter the director of the DVD: ");
                                        string director = Console.ReadLine();

                                        Console.Write("Enter the number of actors in the DVD: ");
                                        int numberOfActors = int.Parse(Console.ReadLine());
                                        string[] actors = new string[numberOfActors];

                                        for (int i = 0; i < numberOfActors; i++) {
                                            Console.Write($"Enter the name of actor {i + 1}: ");

                                            actors[i] = Console.ReadLine();
                                        }

                                        DVD dvd = new DVD();
                                        dvd.SetId(dvdId);
                                        dvd.SetTitle(dvdTitle);
                                        dvd.SetDirector(director);
                                        dvd.SetActors(actors);
                                        dvd.SetStatus(true);
                                        Database.AddItem(dvd);

                                        break;

                                        default:

                                        Console.WriteLine("Invalid type. Please enter a valid number.");

                                        break;

                                        default:

                                        Console.WriteLine("Invalid type. Please enter a valid number.");
                                        
                                        break;
                                    
                                }

                                break;
                            case 2:
                            // Remove an item
                            break;

                            case 3:
                            // Add new user

                            Random random = new Random();
                            int id = random.Next(1000, 9999);

                            Console.Write("Enter the name of the user: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter the address of the user: ");
                            string address = Console.ReadLine();

                            User user = new User();
                            user.SetId(id);
                            user.SetName(name);
                            user.SetAddress(address);
                            Database.AddUser(user);

                            Console.WriteLine($"The user {user.GetName()} has been created.");

                            break;

                            case 4:
                            // Remove a user
                            break;

                            case 5:

                            exit = true;
                            Console.WriteLine("Thank you for using the Library Management System!");
                            break;

                            default:

                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                            }
                            } else if (userRole == "User") {

                            } else {

                            }

                            if (!exit) {
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
}


                    } else if (userRole == "User") {

                        int choice = DisplayUserMenu();

                        switch (choice) {
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
                        case 6:
                            exit = true;
                            Console.WriteLine("Thank you for using the Library Management System!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                        }
                    } else {

                        Console.WriteLine("Invalid user role. Please enter either User or Librarian.");
                    }

                    if (!exit) {
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}