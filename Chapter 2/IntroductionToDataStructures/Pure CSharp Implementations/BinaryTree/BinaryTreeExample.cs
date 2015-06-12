namespace BinaryTree
{
    using System;

    public class BinaryTreeExample
    {
        internal static void Main()
        {
            var random = new Random();
            BinaryTree<int, string> tree = new BinaryTree<int, string>();

            // Включва 10 върха с произволни ключове
            for (int i = 0; i < 10; i++)
            {
                int key = (random.Next() % 20) + 1;
                Console.WriteLine("Вмъква се елемент с ключ {0}", key);
                tree.Add(key, "someinfo");
            }

            Console.WriteLine("Дърво: ");
            tree.Print();
            Console.WriteLine();

            // Претърсва за елемента с ключ 5
            TreeNode<int, string> result = tree.Search(5);
            if (result != null)
            {
                Console.WriteLine("Намерен е: {0}", result.Value);
            }

            // Изтрива произволни 10 върха от дървото
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    int key = (random.Next() % 20) + 1;
                    Console.WriteLine("Изтрива се елемента с ключ {0}", key);
                    tree.Remove(key);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            Console.WriteLine("Дърво: ");
            tree.Print();
            Console.WriteLine();
        }
    }
}