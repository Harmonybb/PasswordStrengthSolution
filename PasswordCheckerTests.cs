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
        [TestCase("Abc123$", ExpectedResult = PasswordChecker.Strength.MEDIUM)] // 7 chars, fails length
        [TestCase("Abc123$1", ExpectedResult = PasswordChecker.Strength.STRONG)] // 8 chars, passes length
        [TestCase("Ab1$", ExpectedResult = PasswordChecker.Strength.WEAK)]       // too short
        [TestCase("abc12345", ExpectedResult = PasswordChecker.Strength.MEDIUM)] // 8 chars, lowercase+digit
        [TestCase("ABCDEF12", ExpectedResult = PasswordChecker.Strength.MEDIUM)] // 8 chars, uppercase+digit
        [TestCase("!!!", ExpectedResult = PasswordChecker.Strength.WEAK)]
        public PasswordChecker.Strength TestPasswordStrength(string password)
        {
            return PasswordChecker.CheckStrength(password);
        }
    }
}


