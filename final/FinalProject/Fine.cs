using System;

namespace LibraryManagementSystem
{
    public class Fine
    {
        // Fields
        private int _id;
        private int _userId;
        private decimal _amount;
        private string _reason;

        public int GetId()
        {
            return _id;
        }
        public void SetId(int id)
        {
            _id = id;
        }
        public int GetUserId()
        {
            return _userId;
        }
        public void SetUserId(int userId)
        {
            _userId = userId;
        }
        public decimal GetAmount()
        {
            return _amount;
        }
        public void SetAmount(decimal amount)
        {
            _amount = amount;
        }
        public string GetReason()
        {
            return _reason;
        }
        public void SetReason(string reason)
        {
            _reason = reason;
        }
        public new string ToString()
        {
            return $"Fine: {GetId()}\nUser ID: {GetUserId()}\nAmount: {GetAmount()}\nReason: {GetReason()}";
        }
    }
}
