namespace BinaryTree
{
    using System;

    public class Program
    {
        private static readonly Random Random = new Random();

        internal static void Main()
        {
            BinaryTree<string, int> tree = null;

            // Включва 10 върха с произволни ключове
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    int key = (Random.Next() % 20) + 1;
                    Console.WriteLine("Вмъква се елемент с ключ {0}", key);
                    BinaryTree<string, int>.InsertKey(key, "someinfo", ref tree);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            Console.WriteLine("Дърво: ");
            BinaryTree<string, int>.PrintTree(tree);
            Console.WriteLine();

            // Претърсва за елемента с ключ 5
            BinaryTree<string, int> result = BinaryTree<string, int>.Search(5, tree);
            if (result != null)
            {
                Console.WriteLine("Намерен е: {0}", result.Data);
            }

            // Изтрива произволни 10 върха от дървото
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    int key = (Random.Next() % 20) + 1;
                    Console.WriteLine("Изтрива се елемента с ключ {0}", key);
                    BinaryTree<string, int>.DeleteKey(key, ref tree);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            Console.WriteLine("Дърво: ");
            BinaryTree<string, int>.PrintTree(tree);
            Console.WriteLine();
        }
    }
}