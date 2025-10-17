using System;
using System.Linq;

namespace PasswordLibrary
{
    public class PasswordChecker
    {
        public enum Strength
        {
            INELIGIBLE,
            WEAK,
            MEDIUM,
            STRONG
        }

        public static Strength CheckStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
                return Strength.INELIGIBLE;

            int criteriaMet = 0;

            if (password.Any(char.IsUpper)) criteriaMet++;
            if (password.Any(char.IsLower)) criteriaMet++;
            if (password.Any(char.IsDigit)) criteriaMet++;
            if (password.Any(ch => !char.IsLetterOrDigit(ch))) criteriaMet++;

            return criteriaMet switch
            {
                0 => Strength.INELIGIBLE,
                1 => Strength.WEAK,
                2 or 3 => Strength.MEDIUM,
                4 => Strength.STRONG,
                _ => Strength.INELIGIBLE
            };
        }
    }
}

