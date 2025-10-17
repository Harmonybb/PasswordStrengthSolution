using System;
using System.Linq;

namespace PasswordLibrary
{
    public class PasswordChecker
    {
        public static string CheckStrength(string password)
        {
            int criteriaMet = 0;

            if (password.Any(char.IsUpper))
                criteriaMet++;
            if (password.Any(char.IsLower))
                criteriaMet++;
            if (password.Any(char.IsDigit))
                criteriaMet++;
            if (password.Any(ch => !char.IsLetterOrDigit(ch)))
                criteriaMet++;

            // ✅ New criterion: password length must be at least 8 characters
            if (password.Length >= 8)
                criteriaMet++;

            // Adjusted strength scale (now 5 total criteria)
            return criteriaMet switch
            {
                0 => "INELIGIBLE",
                1 => "WEAK",
                2 or 3 => "MEDIUM",
                4 => "STRONG",
                5 => "VERY STRONG",
                _ => "INELIGIBLE"
            };
        }
    }
}
