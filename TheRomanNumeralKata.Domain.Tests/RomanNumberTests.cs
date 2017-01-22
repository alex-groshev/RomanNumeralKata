using NUnit.Framework;

namespace TheRomanNumeralKata.Domain.Tests
{
    [TestFixture]
    public class RomanNumberTests
    {
        [TestCase(0, "N")]
        [TestCase(1, "I")]
        [TestCase(10, "X")]
        [TestCase(1100, "MC")]
        [TestCase(1990, "MCMXC")]
        [TestCase(2008, "MMVIII")]
        public void Should_convert_arabic_to_roman_numbers_correctly(int number, string result)
        {
            var rn = new RomanNumber(number);
            Assert.AreEqual(result, rn.ToString());
        }
    }
}