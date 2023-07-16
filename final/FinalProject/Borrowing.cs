using System;

namespace LibraryManagementSystem
{
    public class Borrowing
    {
        private int _id;
        private int _itemId;
        private int _userId;
        private DateTime _dueDate;

        public int GetId()
        {
            return _id;
        }

        public void SetId(int id)
        {
            _id = id;
        }

        public int GetItemId()
        {
            return _itemId;
        }

        public void SetItemId(int itemId)
        {
            _itemId = itemId;
        }

        public int GetUserId()
        {
            return _userId;
        }

        public void SetUserId(int userId)
        {
            _userId = userId;
        }

        public DateTime GetDueDate()
        {
            return _dueDate;
        }
        public void SetDueDate(DateTime dueDate)
        {
            _dueDate = dueDate;
        }

        public new string ToString()
        {
            return $"Borrowing: {GetId()}\nItem ID: {GetItemId()}\nUser ID: {GetUserId()}\nDue Date: {GetDueDate().ToShortDateString()}";
        }
    }
}
