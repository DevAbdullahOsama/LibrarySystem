using LibrarySystem.Extensions;
using LibrarySystem.Helper;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Services
{
    public class LibraryService
    {
        private readonly DisplayService _displayService;
        private readonly LibraryBranch _libraryBranch;

        public LibraryService(DisplayService displayService, LibraryBranch libraryBranch)
        {
            _displayService = displayService;
            _libraryBranch = libraryBranch;
        }
        public void HandleBookBorrowing()
        {
            string memberId = ThemeHelper.Prompt("Enter Member ID: ").NormalizeId();
            Member member = _libraryBranch.FindMember(memberId);
            _displayService.ShowAvailableBooks(_libraryBranch);
            string bookCopyId = ThemeHelper.Prompt("Enter Book Copy ID: ").NormalizeId();
            BookCopy bookCopy = _libraryBranch.FindBookCopy(bookCopyId);
            bookCopy.Borrow(member);
            _displayService.ShowBorrowSuccess(bookCopy, member);
        }
        public void HandleBookReturning()
        {
            string bookCopyId = ThemeHelper.Prompt("Enter Book Copy ID: ").NormalizeId();
            BookCopy bookCopy = _libraryBranch.FindBookCopy(bookCopyId);
            decimal lateFee = bookCopy.Return();
            _displayService.ShowReturnSuccess(bookCopy, lateFee);
        }
        public void HandleHistoryViewing()
        {
            string memberId = ThemeHelper.Prompt("Enter Member ID: ").NormalizeId();
            Member member = _libraryBranch.FindMember(memberId);
            _displayService.ShowMemberHistory(member);
        }
        public void HandleMemberRegister()
        {
            string name = ThemeHelper.Prompt("Enter Full Name: ");
            string phone = ThemeHelper.Prompt("Enter Phone Number: ");
            if (!phone.IsValidPhoneNumber()) throw new InvalidOperationException("The Phone Number Is Not A Valid Number");
            string email = ThemeHelper.Prompt("Enter Email: ");
            if (!phone.IsValidEmail()) throw new InvalidOperationException("The Email Is Not Valid");
            Member member = _libraryBranch.RegisterMember(name, null, email, phone, DateOnly.FromDateTime(DateTime.Now));
            _displayService.ShowRegistrationSuccess(member);
        }
    }
}
