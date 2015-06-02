using System;

class Program
{
    static string[] roman1_9 = {"", "A", "AA", "AAA", "AB", "B", "BA", "BAA", "BAAA", "AC"};
    static string[] romanDigits = {"IVX", "XLC", "CDM", "M" };

    static void Main() 
    {
        Console.WriteLine("Числото MCMLXXXIX в десетична бройна система е {0}", FromRoman("MCMLXXXIX"));
        Console.WriteLine("Числото 1989 в римски цифри е {0}", ToRoman(1989));
    }

    static string GetRomanDigit(char x, int power)
    { 
        string result = "";
        foreach (char ab in roman1_9[x])
            result += romanDigits[power][ab - 'A'];
		
        return result;
    }

    static int FromRoman(string roman)
    { 
        int old = 1000; 
        int result = 0;
        foreach (char ch in roman) 
        {
            int value = 0;
            switch (ch) 
            {
                case 'I': value = 1; break;
                case 'V': value = 5; break;
                case 'X': value = 10; break;
                case 'L': value = 50; break;
                case 'C': value = 100; break;
                case 'D': value = 500; break;
                case 'M': value = 1000; break;
            }
            
            result += value;
            
            if (value > old)
                result -= 2*old;
                
            old = value;
        }
        return result;
    }

    static string ToRoman(int x)
    { 
        string result = "";
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