using System;

class Program
{
    private static Random random = new Random();

    static void Main()
    {
        BinaryTree<string, int> tree = null;

        // Включва 10 върха с произволни ключове
        for (int i = 0; i < 10; i++)
        {
            try
            {
                int key = (random.Next() % 20) + 1;
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
                int key = (random.Next() % 20) + 1;
                Console.WriteLine("Изтрива се елемента с ключ {0}", key);
                BinaryTree<string, int>.DeleteKey(key, ref  tree);
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

class BinaryTree<T, K> where K : IComparable<K>
{
    public K Key { get; set; }
    public T Data { get; set; }
    public BinaryTree<T, K> Left { get; set; }
    public BinaryTree<T, K> Right { get; set; }

    // Търсене в двоично дърво
    public static BinaryTree<T, K> Search(K key, BinaryTree<T, K> tree)
    {
        if (tree == null)
        {
            return null;
        }
        else if (key.CompareTo(tree.Key) < 0)
        {
            return Search(key, tree.Left);
        }
        else if (key.CompareTo(tree.Key) > 0)
        {
            return Search(key, tree.Right);
        }
        else
        {
            return tree;
        }
    }

    // Включване в двоично дърво
    public static void InsertKey(K key, T data, ref BinaryTree<T, K> tree)
    {
        if (tree == null)
        {
            tree = new BinaryTree<T, K>();
            tree.Key = key;
            tree.Data = data;
        }
        else if (key.CompareTo(tree.Key) < 0)
        {
            BinaryTree<T, K> left = tree.Left;
            InsertKey(key, data, ref left);
            tree.Left = left;
        }
        else if (key.CompareTo(tree.Key) > 0)
        {
            BinaryTree<T, K> right = tree.Right;
            InsertKey(key, data, ref right);
            tree.Right = right;
        }
        else
        {
            throw new InvalidOperationException("Елементът е вече в дървото!");
        }
    }

    // Изключване от двоично дърво
    public static void DeleteKey(K key, ref BinaryTree<T, K> tree)
    {
        if (tree == null)
        {
            throw new InvalidOperationException("Върхът, който трябва да се изключи, липсва!");
        }
        else
        {
            if (key.CompareTo(tree.Key) < 0)
            {
                BinaryTree<T, K> left = tree.Left;
                DeleteKey(key, ref left);
                tree.Left = left;
            }
            else if (key.CompareTo(tree.Key) > 0)
            {
                BinaryTree<T, K> right = tree.Right;
                DeleteKey(key, ref right);
                tree.Right = right;
            }
            // Елементът за изключване е намерен
            // Върхът има два наследника
            else if (tree.Left != null && tree.Right != null)
            {
                // Намира се върхът за размяна
                BinaryTree<T, K> replace = FindMin(tree.Right);
                tree.Key = replace.Key;
                tree.Data = replace.Data;

                // Върхът се изключва
                BinaryTree<T, K> right = tree.Right;
                DeleteKey(tree.Key, ref right);
                tree.Right = right;
            }
            else // Елементът има нула или едно поддървета
            {
                if (tree.Left != null)
                {
                    tree = tree.Left;
                }
                else
                {
                    tree = tree.Right;
                }
            }
        }
    }

    // Намиране на минималния елемент в дърво
    public static BinaryTree<T, K> FindMin(BinaryTree<T, K> tree)
    {
        while (tree.Left != null)
        {
            tree = tree.Left;
        }

        return tree;
    }

    public static void PrintTree(BinaryTree<T, K> tree)
    {
        if (tree == null)
        {
            return;
        }

        Console.Write("{0} ", tree.Key);
        PrintTree(tree.Left);
        PrintTree(tree.Right);
    }
}
