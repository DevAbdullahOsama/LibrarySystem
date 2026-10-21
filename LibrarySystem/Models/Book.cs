using LibrarySystem.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Models
{
    public class Book : IDisplayable
    {
        public Book(string isbn, string title, string authorName, string category, int publicationYear)
        {
            ISBN = isbn;
            Title = title;
            AuthorName = authorName;
            Category = category;
            PublicationYear = publicationYear;
        }
        public Book(string isbn, string title) : this(isbn, title, "Unknown Author", "Uncategorized", DateTime.Now.Year)
        {
            ISBN = isbn;
            Title = title;
        }

        public string ISBN { get; private set; } = null!;
        public string Title { get; private set; } = null!;
        public string AuthorName { get; private set; } = null!;
        public string Category { get; private set; } = null!;
        public int PublicationYear { get; private set; }

        public string Display()
        {
            return $"ISBN: {ISBN}\nTitle: {Title}\nAuthor: {AuthorName}\nCategory: {Category}\nPublication Year: {PublicationYear}";
        }
    }
}
