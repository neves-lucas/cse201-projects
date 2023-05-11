using System;
using System.Collections.Generic;
using System.IO;

namespace Journal
{
    // The Journal class manages a list of journal entries.
    public class Journal
    {
        // The entries field holds the list of entries.
        private List<Entry> entries;

        // The fileName field holds the name of the file used to save and load entries.
        private string fileName;

        // The constructor initializes the entries and fileName fields and loads any existing entries from the file.
        public Journal(string fileName)
        {
            this.fileName = fileName;
            entries = new List<Entry>();
            LoadEntries();
        }

        // The AddEntry method adds a new entry to the list and saves the entries to the file.
        public void AddEntry(Entry entry)
        {
            entries.Add(entry);
            SaveEntries();
        }

        // The DisplayEntries method displays all entries in the list.
        public void DisplayEntries()
        {
            foreach (Entry entry in entries)
            {
                Console.WriteLine(entry);
            }
        }

        // The LoadEntries method clears the list of entries and loads any existing entries from the file into the list.
        public void LoadEntries()
        {
            entries.Clear();
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(new[] { ": " }, StringSplitOptions.None);
                    DateTime date = DateTime.Parse(parts[0]);
                    string text = parts[1];
                    entries.Add(new Entry(text) { Date = date });
                }
            }
        }

        // The SaveEntries method saves all entries in the list to the file.
        public void SaveEntries()
        {
            List<string> lines = new List<string>();
            foreach (Entry entry in entries)
            {
                lines.Add(entry.ToString());
            }
            File.WriteAllLines(fileName, lines);
        }
    }
}
