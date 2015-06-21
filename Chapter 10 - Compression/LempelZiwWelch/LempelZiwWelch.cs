namespace LempelZiwWelch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private const int CharacterCount = 256;
        private const int DictionarySize = 4096;
        private const int NotFoun = -1;

        internal static void Main()
        {
            const string Message = "abracadabragabramabracadabragabraLALALALALALALALALALALALALALALA";

            Console.WriteLine("Входно съобщение за кодиране:");
            Console.WriteLine(Message);
            Console.WriteLine("Дължина: {0}", Message.Length);

            List<int> encoded = LzwEncode(Message);
            PrintEncodedMsg(encoded);
            Console.WriteLine("Дължина: {0}", encoded.Count);

            string decoded = LzwDecode(encoded);
            Console.WriteLine("Декодирано съобщение:");
            Console.WriteLine(decoded);
        }

        private static List<string> InitTable() /* Инициализира таблицата */
        {
            var dict = new List<string>(DictionarySize);
            for (int i = 0; i < CharacterCount; i++)
            {
                dict.Add(((char)i).ToString());
            }

            return dict;
        }

        private static int FindIndex(List<string> dict, string s) /* Търси индекс в таблицата */
        {
            for (int i = 0; i < dict.Count; i++)
            {
                if (dict[i] == s)
                {
                    return i;
                }
            }

            return NotFoun;
        }

        private static List<int> LzwEncode(string msg) /* Извършва кодиране по LZW */
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
                {
                    lastIndex = dictIndex;
                }
            }

            encoded.Add(FindIndex(dict, sb.ToString()));
            return encoded;
        }

        private static string LzwDecode(List<int> encoded) /* Извършва декодиране по LZW */
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
                {
                    str = dict[code];
                }

                sb.Append(str);
                string str2 = dict[oldCode];
                str2 += str[0];
                dict.Add(str2);
                oldCode = code;
            }

            return sb.ToString();
        }

        private static void PrintEncodedMsg(List<int> encoded)
        {
            Console.WriteLine("Кодирано съобщение:");
            foreach (int code in encoded)
            {
                Console.Write("{0} ", code);
            }

            Console.WriteLine();
        }
    }
}
