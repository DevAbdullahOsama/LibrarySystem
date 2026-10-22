using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Extensions
{
    public static class StringExtensions
    {
        public static string NormalizeId(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input cannot be null or whitespace.", nameof(input));
            }
            return input.Trim().ToUpperInvariant();
        }
    }
}
