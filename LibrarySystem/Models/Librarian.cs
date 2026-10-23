using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Models
{
    public class Librarian : LibraryUser
    {
        public Librarian(string libraryId, string name, decimal salary, string phone, DateOnly hireDate) 
            : base(name, phone)
        {
            LibrarianId = libraryId;
            Salary = salary;
            HireDate = hireDate;
        }

        public string LibrarianId { get; set; } = null!;
        public decimal Salary { get; set; }
        public DateOnly HireDate { get; set; }

        public override string Display()
        {
            return $"Librarian ID: {LibrarianId},\nName: {Name},\nSalary: {Salary},\nPhone: {Phone},Hire Date: {HireDate}";
        }
    }
}
