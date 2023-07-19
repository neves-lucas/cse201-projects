using System;

namespace LibraryManagementSystem
{
    public class DVD : Item
    {
        private string _director;
        private string _actors;

        // Methods
        public string GetDirector()
        {
            return _director;
        }
        public void SetDirector(string director)
        {
            _director = director;
        }
        public string GetActors()
        {
            return _actors;
        }
        public void SetActors(string actors)
        {
            _actors = actors;
        }

        public override string GetDescription()

        {
            return $"DVD: {GetTitle()}\nDirector: {GetDirector()}\nActors: {GetActors()}\nStatus: {(GetStatus() ? "Available" : "Borrowed")}";
        }

        public override void Borrow()
        {
            SetStatus(false);
            Console.WriteLine($"You have borrowed {GetTitle()} by {GetDirector()}.");
        }

        public override void Return()
        {
            SetStatus(true);
            Console.WriteLine($"You have returned {GetTitle()} by {GetDirector()}.");
        }
    }
}
