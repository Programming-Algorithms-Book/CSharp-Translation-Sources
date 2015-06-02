using System;
using System.Text;

class Program
{
    const double EPS = 0.0001;
    
    static void Main() 
    {
        Console.WriteLine("!!! Демонстрация на преобразуването между бройни системи !!!");
        Console.WriteLine("Седмичният запис на 777.777 (10) е {0}", ToStringReal(777.777, 7, 10));
        Console.WriteLine("Десетичният запис на 11.D873 (16) е: {0:F10}", ToStringReal(ToValueReal("11.D873",16), 10, 10));
    }
    
    static char GetChar(int n) /* Връща символа, съответстващ на n */
    {    
        return (char)((n < 10) ? n + '0' : n + 'A' - 10); 
    }
    
    static int GetValue(char c) /* Връща стойността на символа c */
    {    
        return (c >= '0' && c <= '9') ? c - '0' : c - 'A' + 10; 
    }
    
    static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    
    /* Преобразува десетичното реално число n в бройна система с основа base */
    static string ToStringReal(double n, int toBase, int cnt)
    { 
        var sb = new StringBuilder();
    
        /* Намиране на знака */
        if (n < 0) 
        {
            sb.Append('-');
            n *= -1;
        }
       
        double fraction = n % 1;
        int integer = (int)n;
       
        sb.Append(ToStringIntegral(integer, toBase));
       
        /* Поставяне на десетична точка */
        sb.Append('.');
       
        sb.Append(ToStringFraction(fraction, toBase, cnt));
       
        return sb.ToString();
    }
    
    /* Преобразува цялото десетично число n (n >= 0) в бройна система с основа base */
    static string ToStringIntegral(int n, int toBase)
    {   
        var sb = new StringBuilder();
        while (n > 0) 
        {
            sb.Append(GetChar(n % toBase));
            n /= toBase;
        }
        return Reverse(sb.ToString());
    }
    
    /* Преобразува десетичното число 0 <= n < 1 в бройна система с основа base
        с не повече от cnt на брой цифри след десетичната запетая */
    static string ToStringFraction(double n, int toBase, int cnt)
    { 
	    var sb = new StringBuilder();
        while (cnt > 0) 
        {
			cnt -= 1;
            /* Дали не сме получили 0? */
            if (Math.Abs(n) < EPS) break;
            /* Получаване на следващата цифра */
            n *= toBase;
            sb.Append(GetChar((int)n));
            n -= Math.Floor(n);
        }
        return sb.ToString();
    }
    
    /* Намира стойността на реалното число numb, зададено
        в бройна система с основа base */
    static double ToValueReal(string numb, int fromBase)
    { 
		int minus;
        /* Проверка за минус */
        if ('-' == numb[0]) {
            minus = -1;
            numb = numb.Substring(1);
        }
        else
            minus = 1;
       
        int dotIndex = numb.IndexOf(".");
        if (dotIndex == -1)
            return ToValueIntegral(numb, fromBase); /* Няма дробна част */
       
        /* Пресмятане на цялата част */
        double result = ToValueIntegral(numb.Substring(0, dotIndex), fromBase);
    
        /* Прибавяне на дробната част */
        result += ToValueFraction(numb.Substring(dotIndex + 1), fromBase);
    
        return minus*result;
    }
    
    /* Намира стойността на числото numb, зададено в бройна система
            с основа base, numb >= 0 */
    static long ToValueIntegral(string numb, int fromBase)
    {   
        long result = 0;
        foreach (char ch in numb)
            result = result*fromBase + GetValue(ch);
        return result;
    }
    
    /* Намира стойността на числото numb (0 < numb < 1),
        зададено в бройна система с основа base */
    static double ToValueFraction(string numb, int fromBase)
    { 
        double result = 0.0;
        foreach (char ch in Reverse(numb))
            result = (result + GetValue(ch)) / fromBase;
        return result;
    }
}