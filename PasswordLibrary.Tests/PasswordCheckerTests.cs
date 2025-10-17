using Xunit;
using PasswordLibrary;

namespace PasswordLibrary.Tests
{
    public class PasswordCheckerTests
    {
        [Fact]
        public void Password_ShorterThan8Chars_DoesNotMeetLengthCriterion()
        {
            string result = PasswordChecker.CheckStrength("Ab1!");
            Assert.NotEqual("VERY STRONG", result);
        }

        [Fact]
        public void Password_AtLeast8Chars_MeetsLengthCriterion()
        {
            string result = PasswordChecker.CheckStrength("Ab1!xyz@");
            Assert.Equal("VERY STRONG", result);
        }

        [Fact]
        public void Password_OnlyLong_ButNoOtherCriteria_IsWeak()
        {
            string result = PasswordChecker.CheckStrength("abcdefgh");
            Assert.Equal("WEAK", result);
        }
    }
}
