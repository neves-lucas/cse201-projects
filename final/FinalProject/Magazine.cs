using System;

namespace LibraryManagementSystem
{
    public class Magazine : Item
    {
        private int _issueNumber;
        private string _publicationDate;

        public int GetIssueNumber()
        {
            return _issueNumber;
        }
        public void SetIssueNumber(int issueNumber)
        {
            _issueNumber = issueNumber;
        }
        public string GetPublicationDate()
        {
            return _publicationDate;
        }
        public void SetPublicationDate(string publicationDate)
        {
            _publicationDate = publicationDate;
        }

        public override string GetDescription()
        {
            return $"Magazine: {GetTitle()}\nIssue Number: {GetIssueNumber()}\nPublication Date: {GetPublicationDate()}\nStatus: {(GetStatus() ? "Available" : "Borrowed")}";
        }

        public override void Borrow()
        {
            SetStatus(false);
            Console.WriteLine($"You have borrowed {GetTitle()} (Issue {GetIssueNumber()}).");
        }

        public override void Return()
        {
            SetStatus(true);
            Console.WriteLine($"You have returned {GetTitle()} (Issue {GetIssueNumber()}).");
        }
    }
}
