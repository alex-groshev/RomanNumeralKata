using System;
using TheRomanNumeralKata.Domain;

namespace TheRomanNumeralKata
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Enter number to convert.");
                return;
            }

            int number;
            if (!int.TryParse(args[0], out number))
            {
                Console.WriteLine("Please, enter valid number.");
                return;
            }

            Console.WriteLine($"Result={new RomanNumber(number)}");
        }
    }
}