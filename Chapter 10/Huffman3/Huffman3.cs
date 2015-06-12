namespace Huffman3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        internal static void Main()
        {
            const string Message = "afbabcdefacbabcdecde";
            var tree = Huffman(Message);
            Console.WriteLine("Дърво на Хъфман за {0}:", Message);
            PrintTree(tree);
            WriteCodes(tree, new StringBuilder());
        }

        private static Tree Huffman(string msg)
        {
            /* Построяване на таблица на честотите на срещане */
            Dictionary<char, int> freqs = msg.GroupBy(ch => ch)
                .ToDictionary(g => g.Key, g => g.Count());

            var forest = new HeapForest();
            /* За всеки символ с ненулева честота на срещане се създава тривиално дърво */
            foreach (var ch in freqs.Keys.OrderBy(ch => ch))
            {
                forest.Add(new Tree { Char = ch, Weight = freqs[ch] });
            }

            while (forest.Count > 1)
            {
                Tree minTree1 = forest.GetMin(); /* Намиране на двата най-редки върха */
                Tree minTree2 = forest.GetMin();

                /* Създаване на нов възел - обединение на двата най-редки */
                var tree = new Tree
                {
                    Left = minTree1,
                    Right = minTree2,
                    Weight = minTree1.Weight + minTree2.Weight
                };
                forest.Add(tree);
            }

            return forest.GetMin();
        }

        private static void PrintTree(Tree tree, int h = 0) /* Извежда дървото на екрана */
        {
            if (tree != null)
            {
                PrintTree(tree.Left, h + 1);
                Console.Write(new string(' ', 3 * h));
                Console.Write(" -- ");
                if (tree.Left == null)
                {
                    Console.Write(" {0}", tree.Char);
                }

                Console.WriteLine();
                PrintTree(tree.Right, h + 1);
            }
        }

        private static void WriteCodes(Tree tree, StringBuilder code) /* Извежда кодовете */
        {
            if (tree != null)
            {
                code.Append('0');
                WriteCodes(tree.Left, code);
                code.Remove(code.Length - 1, 1);
                if (tree.Left == null)
                {   /* Всеки връх на Хъфм. дърво има 0 или 2 наследника */
                    Console.WriteLine("{0} = {1}", tree.Char, code);
                }

                code.Append('1');
                WriteCodes(tree.Right, code);
                code.Remove(code.Length - 1, 1);
            }
        }
    }
}