using LibrarySystem.Contracts;
using LibrarySystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Models
{
    public class BookCopy : IDisplayable, IBorrowable
    {
        public string CopyId { get; private set; } = null!;
        public string Condition { get; private set; } = null!;
        public CopyStatus Status { get; private set; }
        public Book Book { get; private set; }
        public BorrowTransaction? ActiveTransaction { get; private set; }
        public BookCopy(string copyId, Book book, string condition = "Good")
        {
            CopyId = copyId;
            Book = book;
            Condition = condition;
            Status = CopyStatus.Available;
        }
        public void Borrow(Member member, int loanPeriodDays = 14)
        {
            if (!IsAvailable())
                throw new InvalidOperationException($"Book copy {CopyId} is not available for borrowing,\nStatus: {Status}");
            
            Status = CopyStatus.Borrowed;
            ActiveTransaction = new BorrowTransaction(member, this, loanPeriodDays);
            member.AddTransaction(ActiveTransaction);
        }
        public decimal Return()
        {
            if(ActiveTransaction == null)
                throw new InvalidOperationException($"No Active Transaction for Book copy {CopyId}");
            if(Status != CopyStatus.Borrowed)
                throw new InvalidOperationException($"Book copy {CopyId} is not currently borrowed.");
            
            ActiveTransaction.MarkAsReturned(DateOnly.FromDateTime(DateTime.Today));
            decimal fine = ActiveTransaction.CalculateFine();
            Status = CopyStatus.Available;
            ActiveTransaction = null;
            return fine;
        }
        public bool IsAvailable() => Status == CopyStatus.Available;
        public string Display()
        {
            string available = IsAvailable() ? "Yes" : $"{Status}";
            return $"Copy ID: {CopyId}\nBook Title: {Book.Title}\nCondition: {Condition}\nAvailable: {available}";
        }
    }
}
