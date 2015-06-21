namespace ArithmeticCoding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private const bool ShowMore = true;

        internal static void Main()
        {
            const string Message = "АРИТМЕТИКА";

            Console.WriteLine("Изходно съобщение: {0}", Message);
            Dictionary<char, int> freqs = GetStatistics(Message);
            Dictionary<char, Symbol> symbols = BuildModel(Message, freqs);

            if (ShowMore)
            {
                PrintModel(symbols);
                Console.Write("Натиснете <<ENTER>>");
                Console.ReadLine();
            }

            double code = ArithmeticEncode(Message, symbols);
            Console.WriteLine("Кодът на съобщението е: {0:F8}", code);
            Console.WriteLine("Декодиране:");
            string decoded = ArithmeticDecode(code, Message.Length, symbols);
        }

        private static Dictionary<char, int> GetStatistics(string msg) /* Намира броя на срещанията на всеки символ */
        {
            return msg.GroupBy(ch => ch).ToDictionary(g => g.Key, g => g.Count());
        }

        private static Dictionary<char, Symbol> BuildModel(string msg, Dictionary<char, int> freqs) /* Построява модела */
        {
            double lastHigh = 0.0;
            var symbols = new Dictionary<char, Symbol>();
            foreach (var ch in freqs.Keys.OrderBy(ch => ch))
            {
                symbols[ch] = new Symbol
                {
                    Low = lastHigh,
                    High = lastHigh + (freqs[ch] / (double)msg.Length),
                    Char = ch
                };

                lastHigh = symbols[ch].High;
            }

            return symbols;
        }

        private static void PrintModel(Dictionary<char, Symbol> symbols)
        {
            Console.WriteLine("             ГРАНИЦА");
            Console.WriteLine("СИМВОЛ    ДОЛНА   ГОРНА");
            foreach (var ch in symbols.Keys.OrderBy(ch => symbols[ch].Low))
            {
                Console.WriteLine("   {0:4}     {1:F4}  {2:F4}", ch, symbols[ch].Low, symbols[ch].High);
            }
        }

        private static double ArithmeticEncode(string msg, Dictionary<char, Symbol> symbols) /* Извършва аритметично кодиране */
        {
            double low = 0.0, high = 1.0;
            foreach (char ch in msg)
            {
                double range = high - low;
                high = low + (range * symbols[ch].High);
                low = low + (range * symbols[ch].Low);
                if (ShowMore)
                {
                    Console.WriteLine("{0}    {1:F9}  {2:F9}", ch, low, high);
                }
            }

            return low;
        }

        private static Symbol GetSymbol(double enc, Dictionary<char, Symbol> symbols)
        {
            return symbols.Values.First(sym => sym.Low <= enc && sym.High > enc);
        }

        private static string ArithmeticDecode(double enc, int length, Dictionary<char, Symbol> symbols) /* Извършва декодиране */
        {
            double range;
            var sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                var symbol = GetSymbol(enc, symbols);
                if (ShowMore)
                {
                    Console.WriteLine("{0}    {1:F9}", symbol.Char, enc);
                }

                sb.Append(symbol.Char);
                range = symbol.High - symbol.Low;
                enc -= symbol.Low;
                enc /= range;
            }

            return sb.ToString();
        }
    }
}