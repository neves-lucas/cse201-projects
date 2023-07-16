using System;

namespace LibraryManagementSystem
{
    public class Book : Item
    {
        private string _author;
        private string _isbn;
        public string GetAuthor()
        {
            return _author;
        }

        public void SetAuthor(string author)
        {
            _author = author;
        }
 
        public string GetIsbn()
        {
            return _isbn;
        }

        public void SetIsbn(string isbn)
        {
            _isbn = isbn;
        }

        public override string GetDescription()
        {
            return $"Book: {GetTitle()}\nAuthor: {GetAuthor()}\nISBN: {GetIsbn()}\nStatus: {(GetStatus() ? "Available" : "Borrowed")}";
        }

        public override void Borrow()
        {
            SetStatus(false);
            Console.WriteLine($"You have borrowed {GetTitle()} by {GetAuthor()}.");
        }

        public override void Return()
        {
            SetStatus(true);
            Console.WriteLine($"You have returned {GetTitle()} by {GetAuthor()}.");
        }
    }
}
