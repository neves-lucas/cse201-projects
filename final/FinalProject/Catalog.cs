using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    public class Catalog
    {
        // Field
        private List<Item> _items;
        private List<User> _users;

        public List<Item> GetItems()
        {
            return _items;
        }

        public void SetItems(List<Item> items)
        {
            _items = items;
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public void SetUsers(List<User> users)
        {
            _users = users;
        }

        public void DisplayItems()
        {
            Console.WriteLine("Items in the catalog:");
            Console.WriteLine();
            foreach (Item item in GetItems())
            {
                Console.WriteLine(item.GetDescription());
                Console.WriteLine();
            }
        }
        public User SearchUser(string query)
        {
            int id;
            if (int.TryParse(query, out id))
            {
                foreach (User user in GetUsers())
                {
                    if (user.GetId() == id)
                    {
                        return user;
                    }
                }
            }
            else
            {
                foreach (User user in GetUsers())
                {
                    if (user.GetName().Equals(query, StringComparison.OrdinalIgnoreCase))
                    {
                        return user;
                    }
                }
            }
            return null;
        }

        public Item SearchItem(string query)
    {
        int id;
        if (int.TryParse(query, out id))
        {
            foreach (Item item in GetItems())
            {
                if (item.GetId() == id)
                {
                    return item;
                }
            }
        }
        else
        {
            foreach (Item item in GetItems())
            {
                if (item.GetTitle().Equals(query, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }
        }
        return null;
    }
        
        public List<Item> SearchByAuthorOrDirector(string name)
        {
            List<Item> results = new List<Item>();
            foreach (Item item in GetItems())
            {
                if (item is Book)
                {
                    Book book = (Book)item;
                    if (book.GetAuthor().Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        results.Add(book);
                    }
                }
                else if (item is DVD)
                {
                    DVD dvd = (DVD)item;
                    if (dvd.GetDirector().Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        results.Add(dvd);
                    }
                }
            }
            return results;
        }

        public bool BorrowItem(Item item, User user)
        {
            try
            {
                if (item != null && user != null)
                {
                    if (item.GetStatus() == true)
                    {
                        item.Borrow();
                        DateTime dueDate = DateTime.Now.AddDays(14);
                        Borrowing borrowing = new Borrowing();
                        borrowing.SetItemId(item.GetId());
                        borrowing.SetUserId(user.GetId());
                        borrowing.SetDueDate(dueDate);
                        Console.WriteLine($"The due date for {item.GetTitle} is {dueDate.ToShortDateString}.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"{item.GetTitle} is not available.");
                        return false;
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
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
                return false;
            }
        }

        public void ReturnItem(Item item, User user)
        {
            try
            {
                if (item != null && user != null)
                {
                    Borrowing borrowing = null;
                    if (borrowing != null)
                    {
                        item.Return();
                        Console.WriteLine($"You have returned {item.GetTitle}.");
                    }
                    else
                    {
                        Console.WriteLine($"{item.GetTitle} is not borrowed by you.");
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
