using System;
using System.IO;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public class Librarian : User
    {
        private string _password;
        private string _role;

        public string GetPassword()
        {
            return _password;
        }
        public void SetPassword(string password)
        {
            _password = password;
        }
        public string GetRole()
        {
            return _role;
        }
        public void SetRole(string role)
        {
            _role = role;
        }

        public new string ToString()
        {
            return $"Librarian: {GetId()}\nName: {GetName()}\nAddress: {GetAddress()}\nPassword: {GetPassword()}\nRole: {GetRole()}";
        }

        Database Database = new Database();

        public void AddItem(Item item)
        {
            Database.AddItem(item);
            Console.WriteLine($"The item {item.GetTitle()} has been added to the catalog.");
        }

        public void RemoveItem(Item item)
        {
            Database.RemoveItem(item);
            Console.WriteLine($"The item {item.GetTitle()} has been removed from the catalog.");
        }

        public void AddUser(User user)
        {
            Database.AddUser(user);
            Console.WriteLine($"The user {user.GetName()} has been created.");
        }

        public void RemoveUser(User user)
        {
            Database.RemoveUser(user);
            Console.WriteLine($"The user {user.GetName()} has been deleted.");
        }
    }
}
