using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        const string message = "LLLLLLALABALANICAAAABABABBABABABABAAABABALLLLAABB";
    
        Console.WriteLine("Входно съобщение:");
        Console.WriteLine(message);
    
        int[] code = LpcEncode(message);
        Console.WriteLine("Кодирано съобщение:");
        Console.WriteLine(string.Concat(code.Select(c => c.ToString().PadLeft(4, ' '))));
    
        string decoded = LpcDecode(code);
        Console.WriteLine("Декодирано съобщение:");
        Console.WriteLine(decoded);
    }
    
    static int[] LpcEncode(string msg) /* Извършва LPC кодиране на съобщението */
    {
        if (msg == "") return new int[0]; /* Празно входно съобщение */
        int[] code = new int[msg.Length];
        double exp = code[0] = msg[0];
        for (int i = 1; i < msg.Length; i++)
        {
            Console.WriteLine(Math.Ceiling(exp - msg[i]));
            code[i] = (int)Math.Ceiling(exp - msg[i]);
            exp = (exp*i + msg[i]) / (i + 1);
        }
        return code;
    }
    
    static string LpcDecode(int[] code) /*Извършва LPC декодиране*/
    {
        if (code.Length == 0) return "";
        double exp = code[0];
        var msg = new StringBuilder();
        msg.Append((char)code[0]);
        for (int i = 1; i < code.Length; i++)
        {
            msg.Append((char)Math.Ceiling(exp - code[i]));
            exp = (exp*i + msg[i]) / (i+1);
        }
        return msg.ToString();
    }
}