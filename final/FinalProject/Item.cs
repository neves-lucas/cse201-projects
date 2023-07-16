using System;

namespace LibraryManagementSystem
{
    public abstract class Item
    {
        private int _id;
        private string _title;
        private bool _status;
        private string _author;
        private string _publisher;
        private int _year;

        public int GetId()
        {
            return _id;
        }
        public void SetId(int id)
        {
            _id = id;
        }
        public string GetTitle()
        {
            return _title;
        }
        public void SetTitle(string title)
        {
            _title = title;
        }
        public bool GetStatus()
        {
            return _status;
        }
        public void SetStatus(bool status)
        {
            _status = status;
        }

        public string GetAuthor()
        {
            return _author;
        }
        public void SetAuthor(string author)
        {
            _author = author;
        }

        public string GetPublisher()
        {
            return _publisher;
        }
        public void SetPublisher(string publisher)
        {
            _publisher = publisher;
        }

        public int GetYear()
        {
            return _year;
        }
        public void SetYear(int year)
        {
            _year = year;
        }

        public abstract string GetDescription();
        public abstract void Borrow();
        public abstract void Return();
    }
}
