using LibrarySystem.Contracts;
using LibrarySystem.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Models
{
    public class LibraryBranch : IDisplayable
    {
        public LibraryBranch(string branchId, string branchName, string address, string phone, string openingHours, Librarian manager)
        {
            BranchId = branchId;
            BranchName = branchName;
            Address = address;
            Phone = phone;
            OpeningHours = openingHours;
            Manager = manager;
        }

        private readonly List<BookCopy> _copies = new();
        private readonly List<Member> _members = new();
        public string BranchId { get; private set; } = null!;
        public string BranchName { get; private set; } = null!;
        public string Address { get; private set; } = null!;
        public string Phone { get; private set; } = null!;
        public string OpeningHours { get; private set; } = null!;
        public Librarian Manager { get; private set; }
        public IReadOnlyList<BookCopy> Copies => _copies;
        public IReadOnlyList<Member> Members => _members;
        public IReadOnlyList<LibraryUser> Users 
        {
            get
            {
                List<LibraryUser> users = new List<LibraryUser>();
                users.Add(Manager);
                users.AddRange(_members);
                return users;
            }
        }
        public Member RegisterMember(string name, string phone)
        {
            Member member = new Member(name, phone);
            _members.Add(member);
            return member;
        }
        public Member RegisterMember(string name, DateOnly? dateOfBirth, string? email, string phone, DateOnly membershipDate)
        {
            Member member = new Member(name, dateOfBirth, email, phone, membershipDate);
            _members.Add(member);
            return member;
        }
        public Member FindMember(string memberShipId)
        {
            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].MembershipId == memberShipId.NormalizeId())
                {
                    return _members[i];
                }
            }
            throw new ArgumentException("Member not found");
        }
        public BookCopy FindBookCopy(string copyId)
        {
            for (int i = 0; i < _copies.Count; i++)
            {
                if (_copies[i].CopyId == copyId.NormalizeId())
                {
                    return _copies[i];
                }
            }
            throw new ArgumentException("Book copy not found");
        }
        public void AddBookCopy(BookCopy copy)
        {
            _copies.Add(copy);
        }
        public List<BookCopy> GetAvailableCopies()
        {
            List<BookCopy> availableCopies = new List<BookCopy>();
            foreach (BookCopy copy in _copies)
            {
                if (copy.IsAvailable())
                {
                    availableCopies.Add(copy);
                }
            }
            return availableCopies;
        }
        public string Display()
        {
            return $"Branch ID: {BranchId},\n Name: {BranchName},\n Address: {Address},\n Phone: {Phone},\n Opening Hours: {OpeningHours},\n Manager: {Manager.Name},\nTotal Members: {_members.Count},\nTotal Book Copies: {_copies.Count}";
        }
    }
}
