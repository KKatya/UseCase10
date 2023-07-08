namespace UseCase10.Tests
{
    /// <summary>
    /// Tests for <see cref="StringValidator.IsValidString(string, int)"/>
    /// </summary>
    public class StringValidatorTests
    {
        /// <summary>
        /// Tests for various inputs
        /// </summary>
        [Theory]
        [InlineData("V", 1, false)]  // Only one char type, within maxLength
        [InlineData("valid1@", 10, false)]  // Missing upper case
        [InlineData("VALID1@", 10, false)]  // Missing lower case
        [InlineData("ValidA@", 10, false)]  // Missing digit
        [InlineData("Valid12", 10, false)]  // Missing special char
        [InlineData(" Valid1@", 10, false)]  // Whitespace at the beginning
        [InlineData("Valid1@ ", 10, false)]  // Whitespace at the end
        [InlineData("Val id1@", 10, false)]  // Whitespace in the middle
        [InlineData("Valid  1@", 10, false)]  // Multiple consequent whitespace characters
        [InlineData("Valid\t1@", 10, false)]  // Tabulation
        [InlineData("Valid\n1@", 10, false)]  // Line ending
        [InlineData("Valid\r1@", 10, false)]  // Carriage return
        [InlineData("Valid1@Extra", 10, false)]  // Exceeds maxLength
        [InlineData("Valid1@", 10, true)]  // Lower case, upper case, digit, special char, within maxLength
        [InlineData("Valid1@", 7, true)]  // Lower case, upper case, digit, special char, equals maxLength
        public void TestIsValidString(string input, int maxLength, bool expected)
        {
            bool actual = StringValidator.IsValidString(input, maxLength);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Verify fails if an input is null
        /// </summary>
        [Fact]
        public void TestIsValidString_NullInput()
        {
            bool actual = StringValidator.IsValidString(input: null!, maxLength: 10);
            Assert.False(actual);
        }

        /// <summary>
        /// Verify fails if an input is an empty string
        /// </summary>
        [Fact]
        public void TestIsValidString_EmptyString()
        {
            bool actual = StringValidator.IsValidString(input: string.Empty, maxLength: 10);
            Assert.False(actual);
        }

        /// <summary>
        /// Verify fails if a max length is =0
        /// </summary>
        [Fact]
        public void TestIsValidString_ZeroMaxLength()
        {
            bool actual = StringValidator.IsValidString(input: "Valid1@", maxLength: 0);
            Assert.False(actual);
        }

        /// <summary>
        /// Verify fails if a max length is <0
        /// </summary>
        [Fact]
        public void TestIsValidString_NegativeMaxLength()
        {
            bool actual = StringValidator.IsValidString(input: "Valid1@", maxLength: -1);
            Assert.False(actual);
        }
    }
}
