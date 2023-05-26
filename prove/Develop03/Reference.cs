namespace ScriptureMemorizer
{
    // A class to represent a scripture reference, such as "John 3:16" or "Proverbs 3:5-6"
    class ScriptureReference
    {
        // The book name, such as "John" or "Proverbs"
        public string _book { get; private set; }

        // The chapter number, such as 3
        public int _chapter { get; private set; }

        // The starting verse number, such as 16 or 5
        public int _startVerse { get; private set; }

        // The ending verse number, such as 6 or -1 if there is no range
        public int _endVerse { get; private set; }

        // A constructor for a single verse reference, such as "John 3:16"
        public ScriptureReference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = verse;
            _endVerse = -1; // Indicates no range
        }

        // A constructor for a verse range reference, such as "Proverbs 3:5-6"
        public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        // A method to return the string representation of the reference
        public override string ToString()
        {
            if (_endVerse == -1) // Single verse reference
            {
                return $"{_book} {_chapter}:{_startVerse}";
            }
            else // Verse range reference
            {
                return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
            }
        }
    }
}
