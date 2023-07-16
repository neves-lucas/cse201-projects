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

        public void ManageUser(User user)
        {
            Console.WriteLine("What do you want to do with this user?");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            
            int action = int.Parse(Console.ReadLine());

            switch (action)
            {
                case 1:
                    Database.AddUser(user);
                    Console.WriteLine($"The user {user.GetName()} has been created.");
                    break;

                case 2:
                    Database.UpdateUser(user);
                    Console.WriteLine($"The user {user.GetName()} has been updated.");
                    break;

                case 3:
                    Database.RemoveUser(user);
                    Console.WriteLine($"The user {user.GetName()} has been deleted.");
                    break;

                default:
                    Console.WriteLine("Invalid action. Please enter a valid number.");
                    break;
            }
        }
    }
}
