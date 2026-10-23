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
        public static bool IsValidPhoneNumber(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsDigit(value[i]))
                    return true;
            }
            return false;
        }
        public static bool IsValidEmail(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            bool hasDot = false;
            bool hasAt = false;
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '.') hasDot = true;
                if (value[i] == '@') hasAt = true;
            }
            return hasDot && hasAt;
        }
    }
}
