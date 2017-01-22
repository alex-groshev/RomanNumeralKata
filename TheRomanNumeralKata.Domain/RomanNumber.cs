using System.Text;

namespace TheRomanNumeralKata.Domain
{
    public sealed class RomanNumber
    {
        private readonly int _number;
        private readonly string _value;
        private readonly string[] _hundreds = {"", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"};
        private readonly string[] _tens = {"", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"};
        private readonly string[] _ones = {"", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"};

        public RomanNumber(int number)
        {
            _number = number;
            _value = Convert(_number);
        }

        public static implicit operator int(RomanNumber rn)
        {
            return rn._number;
        }

        public override string ToString()
        {
            return _value;
        }

        private string Convert(int number)
        {
            if (_number == 0)
                return "N";

            var sb = new StringBuilder();

            while (number >= 1000)
            {
                sb.Append("M");
                number -= 1000;
            }

            sb.Append(_hundreds[number / 100]);
            number = number % 100;

            sb.Append(_tens[number / 10]);
            number = number % 10;

            sb.Append(_ones[number]);
            return sb.ToString();
        }
    }
}