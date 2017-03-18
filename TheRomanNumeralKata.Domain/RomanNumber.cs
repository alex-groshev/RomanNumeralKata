using System;
using System.Collections.Generic;
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
        private readonly Dictionary<char, int> _romanSymbols = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        public RomanNumber(int number)
        {
            _number = number;
            _value = Convert(_number);
        }

        public RomanNumber(string value)
        {
            _number = Convert(value);
            _value = value;
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
            if (number <= 0)
                throw new InvalidOperationException("Only positive values allowed");

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

        private int Convert(string romanNumber)
        {
            if (string.IsNullOrEmpty(romanNumber))
                throw new InvalidOperationException("Empty string is not valid Roman number");

            var result = 0;
            var prevNum = 0;

            for (var i = romanNumber.Length - 1; i >= 0; i--)
            {
                if (_romanSymbols.ContainsKey(romanNumber[i]))
                {
                    if (prevNum > _romanSymbols[romanNumber[i]])
                    {
                        result -= _romanSymbols[romanNumber[i]];
                    }
                    else
                    {
                        result += _romanSymbols[romanNumber[i]];
                    }
                    prevNum = _romanSymbols[romanNumber[i]];
                }
                else
                {
                    throw new InvalidOperationException($"{romanNumber[i]} is not valid symbol");
                }
            }

            return result;
        }
    }
}