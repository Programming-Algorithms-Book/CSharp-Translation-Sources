using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    const int CHAR_CNT = 256;
    const int DICT_SIZE = 4096;
    const int NOT_FOUND = -1;
    
    static void Main()
    {
        const string msg = "abracadabragabramabracadabragabraLALALALALALALALALALALALALALALA";
    
        Console.WriteLine("Входно съобщение за кодиране:");
        Console.WriteLine(msg);
        Console.WriteLine("Дължина: {0}", msg.Length);
        
        List<int> encoded = LzwEncode(msg);
        PrintEncodedMsg(encoded);
        Console.WriteLine("Дължина: {0}", encoded.Count);
        
        string decoded = LzwDecode(encoded);
        Console.WriteLine("Декодирано съобщение:");
        Console.WriteLine(decoded);
    }
    
    static List<string> InitTable() /* Инициализира таблицата */
    {
        var dict = new List<string>(DICT_SIZE);
        for (int i = 0; i < CHAR_CNT; i++)
            dict.Add(((char)i).ToString());
        return dict;
    }
    
    static int FindIndex(List<string> dict, string s) /* Търси индекс в таблицата */
    {
        for (int i = 0; i < dict.Count; i++)
            if (dict[i] == s)
                return i;
        return NOT_FOUND;
    }
    
    static List<int> LzwEncode(string msg) /* Извършва кодиране по LZW */
    {
        List<string> dict = InitTable();
        var encoded = new List<int>();
        var sb = new StringBuilder();
        sb.Append(msg[0]);
        int lastIndex = FindIndex(dict, sb.ToString());
        foreach (char ch in msg.Skip(1))
        {
            sb.Append(ch);
            string newStr = sb.ToString();
            int dictIndex = FindIndex(dict, newStr);
            if (dictIndex == -1)
            {
                encoded.Add(lastIndex);
                dict.Add(newStr);
                sb.Clear(); 
                sb.Append(ch); 
                lastIndex = FindIndex(dict, sb.ToString());
            }
            else
                lastIndex = dictIndex;
        }
        encoded.Add(FindIndex(dict, sb.ToString()));
        return encoded;
    }
    
    static string LzwDecode(List<int> encoded) /* Извършва декодиране по LZW */
    {
        List<string> dict = InitTable(); 
        int ind = 0;
        int oldCode = encoded[ind++];
    
        var sb = new StringBuilder();
        sb.Append(dict[oldCode]);
        while (ind < encoded.Count)
        {
            int code = encoded[ind++];
            string str;
            if (code >= dict.Count)
            {
                str = dict[oldCode];
                str += str[0];
            }
            else
                str = dict[code];
            sb.Append(str);
            string str2 = dict[oldCode];
            str2 += str[0];
            dict.Add(str2);
            oldCode = code;
        }
        return sb.ToString();
    }
    
    static void PrintEncodedMsg(List<int> encoded)
    {
        Console.WriteLine("Кодирано съобщение:");
        foreach (int code in encoded)
            Console.Write("{0} ", code);
        Console.WriteLine();
    }
}
