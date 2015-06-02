using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    class Tree
    {
        public char Char { get; set; }  /* Символ (буква) */
        public int Weight { get; set; } /* Общо тегло на дървото */
        public Tree Left { get; set; }  /* Ляв и десен наследници */
        public Tree Right { get; set; }
    }
    
    static void Main()
    {
        const string msg = "afbabcdefacbabcdecde";
        var tree = Huffman(msg);
        Console.WriteLine("Дърво на Хъфман за {0}:", msg);
        PrintTree(tree);
        WriteCodes(tree, new StringBuilder());
    }
     
    static Tree Huffman(string msg)
    {
        /* Построяване на таблица на честотите на срещане */
        Dictionary<char, int> freqs = msg.GroupBy(ch => ch)
            .ToDictionary(g => g.Key, g => g.Count());
        
        var forest = new List<Tree>();
        /* За всеки символ с ненулева честота на срещане се създава тривиално дърво */
        foreach(var ch in freqs.Keys.OrderBy(ch => ch))
        {                                                /* <-- */
            forest.Add(new Tree { Char = ch, Weight = freqs[ch] });
        }
    
        while (forest.Count > 1)
        {
            int i, j;
            FindMins(forest, out i, out j);    /* Намиране на двата най-редки върха */
    
            /* Създаване на нов възел - обединение на двата най-редки */                     
            var tree = new Tree { Weight = forest[i].Weight + forest[j].Weight };    /* <-- */
            
            if (i < j)                  /* <-- */
            {                           /* <-- */
                tree.Left = forest[i];  /* <-- */
                tree.Right = forest[j]; /* <-- */
            }                           /* <-- */
            else                        /* <-- */
            {                           /* <-- */
                tree.Left = forest[j];  /* <-- */
                tree.Right = forest[i]; /* <-- */
            }                           /* <-- */
            
            forest[i] = tree;
    
            /* j-тото дърво не е нужно повече. Заместване с последното. */
            forest[j] = forest[forest.Count - 1];
            forest.RemoveAt(forest.Count - 1);
        }
        return forest[0];
    }
    
    static void FindMins(List<Tree> forest, /* Намира двата най-редки елемента */
        out int min1, out int min2) 
    {
        if (forest[0].Weight <= forest[1].Weight)
        {
            min1 = 0;
            min2 = 1;
        }
        else {
            min1 = 1;
            min2 = 0;
        }
        for (int i = 2; i < forest.Count; i++)
            if (forest[i].Weight <= forest[min1].Weight)      /* <-- */
            {                                                 
                min2 = min1;
                min1 = i;
            }
            else if (forest[i].Weight <= forest[min2].Weight) /* <-- */
                min2 = i;
    }
    
    static void PrintTree(Tree tree, int h = 0) /* Извежда дървото на екрана */
    {
        if (tree != null)
        {
            PrintTree(tree.Left, h+1);
            Console.Write(new string(' ', 3*h));
            Console.Write(" -- ");
            if (tree.Left == null)
                Console.Write(" {0}", tree.Char);
            Console.WriteLine();
            PrintTree(tree.Right, h+1); 
        }
    }
    
    static void WriteCodes(Tree tree, StringBuilder code) /* Извежда кодовете */
    {
        if (tree != null)
        {
            code.Append('0'); 
            WriteCodes(tree.Left, code);
            code.Remove(code.Length-1, 1);
            if (tree.Left == null)
            {   /* Всеки връх на Хъфм. дърво има 0 или 2 наследника */
                Console.WriteLine("{0} = {1}", tree.Char, code);
            }
            code.Append('1');
            WriteCodes(tree.Right, code);
            code.Remove(code.Length-1, 1);
        }
    }
}