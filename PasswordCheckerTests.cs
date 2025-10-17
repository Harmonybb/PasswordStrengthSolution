using NUnit.Framework;
using PasswordLibrary;

namespace PasswordLibrary.Tests
{
    [TestFixture]
    public class PasswordCheckerTests
    {
        [TestCase("", ExpectedResult = PasswordChecker.Strength.INELIGIBLE)]
        [TestCase("123456", ExpectedResult = PasswordChecker.Strength.WEAK)]
        [TestCase("abcdef", ExpectedResult = PasswordChecker.Strength.WEAK)]
        [TestCase("ABCDEF", ExpectedResult = PasswordChecker.Strength.WEAK)]
        [TestCase("abc123", ExpectedResult = PasswordChecker.Strength.MEDIUM)]
        [TestCase("abc$123", ExpectedResult = PasswordChecker.Strength.MEDIUM)]
        [TestCase("Abc123", ExpectedResult = PasswordChecker.Strength.MEDIUM)]
        [TestCase("Abc123$", ExpectedResult = PasswordChecker.Strength.STRONG)]
        [TestCase("!!!", ExpectedResult = PasswordChecker.Strength.WEAK)]
        public PasswordChecker.Strength TestPasswordStrength(string password)
        {
            return PasswordChecker.CheckStrength(password);
        }
    }
}

