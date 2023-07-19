using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    public class Database
    {
        private string _catalogFile = "catalog.csv";
        private string _usersFile = "users.csv";

        public string GetCatalogFile()
        {
            return _catalogFile;
        }
        public void SetCatalogFile(string catalogFile)
        {
            _catalogFile = catalogFile;
        }
        public string GetUsersFile()
        {
            return _usersFile;
        }
        public void SetUsersFile(string usersFile)
        {
            _usersFile = usersFile;
        }


        public void AddItem(Item item)  
        {
            using (StreamWriter sw = File.AppendText(GetCatalogFile())) 
            {
                if(item is Book) {
                Book book = (Book)item;
                sw.WriteLine($"{book.GetId()},{book.GetType()},{book.GetTitle()},{book.GetStatus()},{book.GetAuthor()},{book.GetIsbn()}");
                }
                else if(item is FictionBook) {
                FictionBook fictionBook = (FictionBook)item; 
                sw.WriteLine($"{fictionBook.GetId()},{fictionBook.GetType()},{fictionBook.GetTitle()},{fictionBook.GetStatus()},{fictionBook.GetAuthor()},{fictionBook.GetIsbn()},{fictionBook.GetGenre()}");
                }
                else if(item is DVD) {
                DVD dvd = (DVD)item;
                sw.WriteLine($"{dvd.GetId()},{dvd.GetType()},{dvd.GetTitle()},{dvd.GetStatus()},{dvd.GetDirector()},{dvd.GetActors()}");
                }
                else if(item is Magazine) {
                Magazine magazine = (Magazine)item;
                sw.WriteLine($"{magazine.GetId()},{magazine.GetType()},{magazine.GetTitle()},{magazine.GetStatus()},{magazine.GetIssueNumber()},{magazine.GetPublicationDate()}");
                }
            }
        }

        public void RemoveItem(Item item)
        {
            List<string> lines = File.ReadAllLines(GetCatalogFile()).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                string id = lines[i].Split(',')[0];

                if (id == item.GetId().ToString())
                {
                    lines.RemoveAt(i);
                    break;
                }
            }

            File.WriteAllLines(GetCatalogFile(), lines);
        }
		
		public void UpdateItem(Item item)
		{
			List<string> lines = File.ReadAllLines(GetCatalogFile()).ToList();

			for (int i = 0; i < lines.Count; i++)
			{
				string id = lines[i].Split(',')[0];

				if (id == item.GetId().ToString())
				{
					// Replace the status field with the current status of the item
					lines[i] = lines[i].Remove(lines[i].Length - 1) + item.GetStatus().ToString();
					break;
				}
			}

			File.WriteAllLines(GetCatalogFile(), lines);
		}


        public void AddUser(User user)
        {
            using (StreamWriter sw = File.AppendText(GetUsersFile()))
            {
                sw.WriteLine($"{user.GetId()},{user.GetName()},{user.GetAddress()}");
            }
        }

        public void RemoveUser(User user)
        {
            List<string> lines = File.ReadAllLines(GetUsersFile()).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                string id = lines[i].Split(',')[0];

                if (id == user.GetId().ToString())
                {
                    lines.RemoveAt(i);
                    break;
                }
            }

            File.WriteAllLines(GetUsersFile(), lines);
        }
        public User SearchUser(string query)
        {
        List<string> lines = File.ReadAllLines(GetUsersFile()).ToList();

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            string id = parts[0];
            string name = parts[1];

            if (id == query || name == query)
            {
            User user = new User();
            user.SetId(int.Parse(id));
            user.SetName(name);
            user.SetAddress(parts[2]);

            return user; 
            }
        }

        return null;
        }

        public void UpdateUser(User user)
        {
            List<string> lines = File.ReadAllLines(GetUsersFile()).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                string id = lines[i].Split(',')[0];

                if (id == user.GetId().ToString())
                {
                    lines[i] = $"{user.GetId()},{user.GetName()},{user.GetAddress()}";
                    break;
                }
            }

            File.WriteAllLines(GetUsersFile(), lines);
        }
    }
}
