using LibrarySystem.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Models
{
    public abstract class LibraryUser : IDisplayable
    {
        protected LibraryUser(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public string Name { get; protected set; }
        public string Phone { get; protected set; }

        public abstract string Display();
    }
}
