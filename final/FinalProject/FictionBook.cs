using System;

namespace LibraryManagementSystem
{
    public class FictionBook : Book
    {
        private string _genre;

        // Methods
        public string GetGenre()
        {
            return _genre;
        }
        public void SetGenre(string genre)
        {
            _genre = genre;
        }
        public override string GetDescription()
        {
            return $"Fiction Book: {GetTitle()}\nAuthor: {GetAuthor()}\nISBN: {GetIsbn()}\nGenre: {GetGenre()}\nStatus: {(GetStatus() ? "Available" : "Borrowed")}";
        }

        public override void Borrow()
        {
            base.Borrow();
            Console.WriteLine($"If you like {GetGenre()}, you may also enjoy these books:");
        }

        public override void Return()
        {
            base.Return();
            Console.WriteLine($"How did you like {GetTitle()} by {GetAuthor()}?");
        }
    }
}
