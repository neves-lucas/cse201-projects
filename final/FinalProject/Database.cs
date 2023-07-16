using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    public static class Database
    {
        private static string catalogFile = "catalog.csv";
        private static string usersFile = "users.csv";

        public static void AddItem(Item item)
        {
            using (StreamWriter sw = File.AppendText(catalogFile))
            {
                sw.WriteLine($"{item.GetId()},{item.GetTitle()},{item.GetAuthor()},{item.GetPublisher()},{item.GetYear()},{item.GetType()}");
            }
        }

        public static void RemoveItem(Item item)
        {
            List<string> lines = File.ReadAllLines(catalogFile).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                string id = lines[i].Split(',')[0];

                if (id == item.GetId().ToString())
                {
                    lines.RemoveAt(i);
                    break;
                }
            }

            File.WriteAllLines(catalogFile, lines);
        }
		
		public static void UpdateItem(Item item)
		{
			List<string> lines = File.ReadAllLines(catalogFile).ToList();

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

			File.WriteAllLines(catalogFile, lines);
		}


        public static void AddUser(User user)
        {
            using (StreamWriter sw = File.AppendText(usersFile))
            {
                sw.WriteLine($"{user.GetId()},{user.GetName()},{user.GetAddress()}");
            }
        }

        public static void RemoveUser(User user)
        {
            List<string> lines = File.ReadAllLines(usersFile).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                string id = lines[i].Split(',')[0];

                if (id == user.GetId().ToString())
                {
                    lines.RemoveAt(i);
                    break;
                }
            }

            File.WriteAllLines(usersFile, lines);
        }

        public static void UpdateUser(User user)
        {
            List<string> lines = File.ReadAllLines(usersFile).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                string id = lines[i].Split(',')[0];

                if (id == user.GetId().ToString())
                {
                    lines[i] = $"{user.GetId()},{user.GetName()},{user.GetAddress()}";
                    break;
                }
            }

            File.WriteAllLines(usersFile, lines);
        }
    }
}
