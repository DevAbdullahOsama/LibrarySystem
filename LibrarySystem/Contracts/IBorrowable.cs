using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Contracts
{
    public interface IBorrowable
    {
        void Borrow(Member member, int loanDays = 14);
        decimal Return();
        bool IsAvailable();
    }
}
