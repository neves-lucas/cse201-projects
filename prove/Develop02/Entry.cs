using System;

namespace Journal
{
    // The Entry class represents a single journal entry.
    public class Entry
    {
        // The Text property holds the text of the journal entry.
        public string Text { get; set; }

        // The Date property holds the date and time the entry was created.
        public DateTime Date { get; set; }

        // The constructor initializes the Text and Date properties.
        public Entry(string text)
        {
            Text = text;
            Date = DateTime.Now;
        }

        // The ToString method returns a string representation of the entry.
        public override string ToString()
        {
            return $"{Date}: {Text}";
        }
    }
}
