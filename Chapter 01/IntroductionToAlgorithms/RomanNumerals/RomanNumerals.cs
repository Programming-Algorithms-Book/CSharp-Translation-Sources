namespace RomanNumerals
{
    using System;

    public class Program
    {
        private static readonly string[] Roman1To9 = { string.Empty, "A", "AA", "AAA", "AB", "B", "BA", "BAA", "BAAA", "AC" };
        private static readonly string[] RomanDigits = { "IVX", "XLC", "CDM", "M" };

        internal static void Main()
        {
            Console.WriteLine("Числото MCMLXXXIX в десетична бройна система е {0}", FromRoman("MCMLXXXIX"));
            Console.WriteLine("Числото 1989 в римски цифри е {0}", ToRoman(1989));
        }

        private static string GetRomanDigit(char x, int power)
        {
            string result = string.Empty;
            foreach (char ab in Roman1To9[x])
            {
                result += RomanDigits[power][ab - 'A'];
            }

            return result;
        }

        private static int FromRoman(string roman)
        {
            int old = 1000;
            int result = 0;
            foreach (char ch in roman)
            {
                int value = 0;
                switch (ch)
                {
                    case 'I': value = 1; 
                        break;
                    case 'V': value = 5; 
                        break;
                    case 'X': value = 10; 
                        break;
                    case 'L': value = 50; 
                        break;
                    case 'C': value = 100; 
                        break;
                    case 'D': value = 500; 
                        break;
                    case 'M': value = 1000; 
                        break;
                }

                result += value;

                if (value > old)
                {
                    result -= 2 * old;
                }

                old = value;
            }

            return result;
        }

        private static string ToRoman(int x)
        {
            string result = string.Empty;
            int power = 0;
            while (x > 0)
            {
                string digit = GetRomanDigit((char)(x % 10), power);
                result = digit + result;
                power += 1;
                x /= 10;
            }

            return result;
        }
    }
}