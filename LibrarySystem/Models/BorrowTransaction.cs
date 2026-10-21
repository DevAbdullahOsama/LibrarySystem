using LibrarySystem.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Models
{
    public class BorrowTransaction : IDisplayable
    {
        public BorrowTransaction(Member member, BookCopy bookCopy, int loanPeriodDays)
        {
            TransactionId = ++Counter;
            Member = member;
            BookCopy = bookCopy;
            BorrowDate = DateOnly.FromDateTime(DateTime.Today);
            DueDate= DateOnly.FromDateTime(DateTime.Today).AddDays(loanPeriodDays);
        }

        private static int Counter { get; set; }
        protected const decimal FinePerDay = 10m;
        public int TransactionId { get; set; }
        public Member Member { get; set; }
        public BookCopy BookCopy { get; set; }
        public DateOnly BorrowDate { get; set; }
        public DateOnly DueDate { get; set; }
        public DateOnly? ReturnDate { get; set; }

        public bool IsReturned => ReturnDate.HasValue;
        public decimal CalculateFine()
        {
            DateOnly effective = ReturnDate ?? DateOnly.FromDateTime(DateTime.Today);
            int overdueDays = (effective.DayNumber - DueDate.DayNumber);
            return overdueDays > 0 ? overdueDays * FinePerDay : 0;
        }
        public decimal CalculateFine(DateOnly returnDate)
        {
            int overdueDays = (returnDate.DayNumber - DueDate.DayNumber);
            return overdueDays > 0 ? overdueDays * FinePerDay : 0;
        }
        public void MarkAsReturned(DateOnly returnDate)
        {
            ReturnDate = returnDate;
        }
        public string Display()
        {
            string status = ReturnDate.HasValue ? $"Returned on {ReturnDate.Value:dd/MM/yyyy}" : "Active";
            decimal fine = CalculateFine();
            string isReturned = ReturnDate.HasValue ? ReturnDate.Value.ToString("dd/MM/yyyy") : "Not returned yet";
            string fineDisplay = fine > 0 ? $"Fine: {fine:F2}" : "No fine";
            return $"Transaction ID: {TransactionId}\nBook: {BookCopy.Book.Title}\nBook Copy ID: {BookCopy.CopyId}\nBorrow Date: {BorrowDate:dd/MM/yyyy}\nDue Date: {DueDate:dd/MM/yyyy}\nReturn Date: {isReturned}\nStatus: {status}\n{fineDisplay}";
        }
    }
}
