using System;

namespace LibraryManagementSystem
{
    public abstract class Item
    {
        private int _id;
        private string _title;
        private bool _status;
        private string _type;

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
        public string GetType()
        {
            return _type;
        }
        public void SetType(string type)
        {
            _type = type;
        }

        public abstract string GetDescription();
        public abstract void Borrow();
        public abstract void Return();
    }
}
