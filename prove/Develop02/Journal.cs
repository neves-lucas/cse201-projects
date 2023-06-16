using System;
using System.Collections.Generic;
using System.IO;

namespace Journal
{
    // The Journal class manages a list of journal entries.
    public class Journal
    {
        // The _entries field holds a list of Entry objects representing this journal's entries.
        private List<Entry> _entries;

        // The constructor initializes an empty list of entries.
        public Journal()
        {
            _entries = new List<Entry>();
        }

        // The AddEntry method adds a new entry to this journal's list of entries.
        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        // The DisplayEntries method displays all of this journal's entries to the console.
        public void DisplayEntries()
        {
            foreach (Entry entry in _entries)
            {
                Console.WriteLine(entry);
            }
        }

        // The LoadEntries method clears this journal's list of entries and loads any existing entries from the specified file into this list.
        public void LoadEntries(string fileName)
        {
            _entries.Clear();
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(new[] { ": ", " - " }, StringSplitOptions.None);
                    DateTime date = DateTime.Parse(parts[0]);
                    string prompt = parts[1];
                    string text = parts[2];
                    _entries.Add(new Entry(text, prompt) { Date = date });
                }
            }
        }

        // The SaveEntries method saves all of this journal's entries to the specified file. Each entry is saved on its own line using its ToString representation. If any existing file with this name is overwritten. 
        public void SaveEntries(string fileName)
        {
            List<string> lines = new List<string>();
            foreach (Entry entry in _entries)
            {
                lines.Add(entry.ToString());
            }
            File.WriteAllLines(fileName, lines);
        }
    }
}
