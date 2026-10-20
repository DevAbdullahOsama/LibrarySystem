using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Models
{
    public class Member : LibraryUser
    {
        private static int Counter = 0;
        private List<BorrowTransaction> _transactions = new();
        public string MembershipId { get; private set; } = null!;
        public DateOnly? DateOfBirth { get; private set; }
        public string? Email { get; private set; }
        public DateOnly MembershipDate { get; private set; }
        public IReadOnlyList<BorrowTransaction> Transactions 
        {
            get { return _transactions; }
        }

        public Member( string name, DateOnly? dateOfBirth, string? email, string phone, DateOnly membershipDate)
            : base(name, phone)
        {
            MembershipId = $"MEM-{Counter++:D3}"; // 001 , 002, 003
            DateOfBirth = dateOfBirth;
            Email = email;
            MembershipDate = membershipDate;
        }
        public Member(string name, string phone) : this(name, null, null, phone, DateOnly.FromDateTime(DateTime.Today))
        {
            
        }
        public void AddTransaction(BorrowTransaction transaction)
        {
            _transactions.Add(transaction);
        }
        public string GetHistoryDisplay()
        {
            if(Transactions.Count == 0)
            {
                return "No transactions found.";
            }
            // Use StringBuilder for efficient string concatenation because we are building a string in a loop.
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Transactions.Count; i++)
            {
                result.AppendLine($"Transaction {i + 1}:");
                result.AppendLine(Transactions[i].Display());
            }
            return result.ToString();
        }

        public override string Display()
        {
            return $"ID: {MembershipId}\nName: {Name}\nPhone: {Phone}\nDate of Birth: {(DateOfBirth.HasValue ? DateOfBirth.Value.ToString("d") : "N/A")}\nEmail: {(string.IsNullOrEmpty(Email) ? "N/A" : Email)}\nJoin Date: {MembershipDate:dd/MM/yyyy}\n Borrowed Items: {Transactions.Count}";
        }
    }
}
