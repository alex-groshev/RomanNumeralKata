using NUnit.Framework;

namespace TheRomanNumeralKata.Domain.Tests
{
    [TestFixture]
    public class RomanNumberTests
    {
        [TestCase(1, "I")]
        [TestCase(10, "X")]
        [TestCase(1100, "MC")]
        [TestCase(1990, "MCMXC")]
        [TestCase(2008, "MMVIII")]
        [TestCase(1954, "MCMLIV")]
        [TestCase(2014, "MMXIV")]
        public void Should_convert_arabic_to_roman_numbers_correctly(int number, string result)
        {
            var rn = new RomanNumber(number);
            Assert.AreEqual(result, rn.ToString());
        }

        [TestCase("I", 1)]
        [TestCase("X", 10)]
        [TestCase("MC", 1100)]
        [TestCase("MCMXC", 1990)]
        [TestCase("MMVIII", 2008)]
        [TestCase("MCMLIV", 1954)]
        [TestCase("MMXIV", 2014)]
        public void Should_convert_roman_numbers_to_arabic_correctly(string number, int result)
        {
            var rn = new RomanNumber(number);
            Assert.AreEqual(result, (int)rn);
        }
    }
}