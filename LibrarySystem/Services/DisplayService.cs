using LibrarySystem.Helper;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Services
{
    public class DisplayService
    {
        public void ShowBranchInformation(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("Library Branch Information");
            Console.WriteLine(branch.Display());
        }
        public void ShowAllUsers(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("All Registered Users");
            IReadOnlyList<LibraryUser> users = branch.Users;
            for (int i = 0; i < users.Count; i++)
            {
                string header = users[i] is Librarian ? "Librarian Profile" : "Member Profile";
                ThemeHelper.PrintSectionTitle(header);
                Console.WriteLine(users[i].Display());
            }
        }
        public void ShowAvailableBooks(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("Available Book Copies");
            List<BookCopy> availableBooks = branch.GetAvailableCopies();
            if(availableBooks.Count == 0)
            {
                ThemeHelper.PrintWarning("No available book copies at the moment.");
            }
            else
            {
                for (int i = 0; i < availableBooks.Count; i++)
                {
                    ThemeHelper.PrintSectionTitle($"Book {i + 1}");
                    Console.WriteLine(availableBooks[i].Display());
                }
            }
        }
        public void ShowAllBooks(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("All Book Copies");
            if (branch.Copies.Count == 0)
            {
                ThemeHelper.PrintWarning("No book copies in the library.");
                return;
            }
            else
            {
                for (int i = 0; i < branch.Copies.Count; i++)
                {
                    ThemeHelper.PrintSectionTitle($"Book {i + 1}");
                    Console.WriteLine(branch.Copies[i].Display());
                }
            }
        }
        public void ShowMemberHistory(Member member)
        {
            ThemeHelper.PrintSectionTitle($"Member Borrowing History for {member.Name}");
            Console.WriteLine(member.GetHistoryDisplay());
        }
        public void ShowBorrowSuccess(BookCopy bookCopy, Member member)
        {
            ThemeHelper.PrintSuccess($"Book '{bookCopy.Book.Title}' with ID [{bookCopy.CopyId}] has been successfully borrowed by {member.Name}\nDue Date: {bookCopy.ActiveTransaction!.DueDate:dd-MM-yyyy}.");
        }
        public void ShowReturnSuccess(BookCopy bookCopy, decimal fine)
        {
            ThemeHelper.PrintSuccess($"Book '{bookCopy.Book.Title}' with ID [{bookCopy.CopyId}] has been successfully returned.");
            if(fine > 0)
            {
                ThemeHelper.PrintWarning($"A fine of {fine:F2} EGP has been applied for late return.");
            }
            else
            {
                ThemeHelper.PrintSuccess("No fine has been applied for this return.");
            }
        }
        public void ShowRegistrationSuccess(Member member)
        {
            ThemeHelper.PrintSuccess($"User '{member.Name}' with ID [{member.MembershipId}] has been successfully registered.");
        }
        public void ShowAddBookSuccess(BookCopy bookCopy)
        {
            ThemeHelper.PrintSuccess($"Book '{bookCopy.Book.Title}' with ID [{bookCopy.CopyId}] has been successfully added to the library.");
        }
    }
}
