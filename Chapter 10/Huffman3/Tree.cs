namespace Huffman3
{
    public class Tree
    {
        public char Char { get; set; }  /* Символ (буква) */

        public int Weight { get; set; } /* Общо тегло на дървото */

        public Tree Left { get; set; }  /* Ляв и десен наследници */

        public Tree Right { get; set; }
    }
}