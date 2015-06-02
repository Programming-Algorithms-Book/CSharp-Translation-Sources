using System;

class BinaryTreeExample
{
    static Random random = new Random();

    static void Main()
    {
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


struct BinaryTree<TKey, TValue>
    where TKey : IComparable<TKey>
{
    private TreeNode<TKey, TValue> root;

    // Вмъкване на елемент в двоично дърво
    public void Add(TKey key, TValue value)
    {
        if (key == null)
        {
            throw new ArgumentException("Грешка: Не може да се вмъква елемент с ключ null!");
        }
        if (value == null)
        {
            throw new ArgumentException("Грешка: Не може да се вмъква елемент със стойност null!");
        }

        this.root = Insert(key, value, null, this.root);
    }

    private TreeNode<TKey, TValue> Insert(TKey key, TValue value,
        TreeNode<TKey, TValue> parentNode, TreeNode<TKey, TValue> currentNode)
    {
        if (currentNode == null) // Текущия елемент е лист или празно дърво
        {
            currentNode = new TreeNode<TKey, TValue>(key, value);
            currentNode.Parent = parentNode;
        }
        else
        {
            if (key.CompareTo(currentNode.Key) < 0)
            {
                currentNode.LeftChild = Insert(key, value, currentNode, currentNode.LeftChild);
            }
            else if (key.CompareTo(currentNode.Key) > 0)
            {
                currentNode.RightChild = Insert(key, value, currentNode, currentNode.RightChild);
            }
            else
            {
                currentNode.Value = value;
            }
        }
        return currentNode;
    }

    // Търсене в двоично дърво
    public TreeNode<TKey, TValue> Search(TKey key)
    {
        TreeNode<TKey, TValue> currentNode = this.root;

        while (currentNode != null)
        {
            if (key.CompareTo(currentNode.Key) < 0)
            {
                currentNode = currentNode.LeftChild;
            }
            else if (key.CompareTo(currentNode.Key) > 0)
            {
                currentNode = currentNode.RightChild;
            }
            else
            {
                break;
            }
        }

        return currentNode;
    }

    // Изключване от двоичното дърво
    public void Remove(TKey key)
    {
        TreeNode<TKey, TValue> nodeToDelete = Search(key);

        if (nodeToDelete == null)
        {
            throw new InvalidOperationException("Върхът, който трябва да се изключи, липсва!");
        }
        else
        {
            Remove(nodeToDelete);
        }
    }

    private void Remove(TreeNode<TKey, TValue> nodeToDelete)
    {
        // Елементът за изключване е намерен и има два наследника
        if (nodeToDelete.LeftChild != null && nodeToDelete.RightChild != null)
        {
            // Намира се върхът за размяна. По дефиниция минималния елемент
            // от дясното поддърво заменя елементът, който трябва да бъде изтрит
            TreeNode<TKey, TValue> replacementNode = nodeToDelete.RightChild;
            replacementNode = FindMinimalElement(replacementNode);
            nodeToDelete.Key = replacementNode.Key;
            nodeToDelete.Value = replacementNode.Value;
            nodeToDelete = replacementNode;
        }


        // Елементът за изтриване има най-много едно дете
        TreeNode<TKey, TValue> tempNode;

        if (nodeToDelete.LeftChild != null)
        {
            tempNode = nodeToDelete.LeftChild;
        }
        else
        {
            tempNode = nodeToDelete.RightChild;
        }

        if (tempNode != null) // Елементът за изтриване има едно дете
        {
            tempNode.Parent = nodeToDelete.Parent;
            if (nodeToDelete.Parent == null) // Елементът е корена на дървото
            {
                this.root = tempNode;
            }
            else // Размяна на елемента за изтриване със неговите поддървета
            {
                if (nodeToDelete.Parent.LeftChild == nodeToDelete)
                {
                    nodeToDelete.Parent.LeftChild = tempNode;
                }
                else
                {
                    nodeToDelete.Parent.RightChild = tempNode;
                }
            }
        }
        else // Елементът има нула или едно поддървета
        {
            if (nodeToDelete.Parent == null) // Елементът е корена
            {
                this.root = null;
            }
            else // Елементът е листо
            {
                if (nodeToDelete.Parent.LeftChild == nodeToDelete)
                {
                    nodeToDelete.Parent.LeftChild = null;
                }
                else
                {
                    nodeToDelete.Parent.RightChild = null;
                }
            }
        }
    }

    public void Print()
    {
        Print(this.root);
    }

    private void Print(TreeNode<TKey, TValue> node)
    {
        if (node == null)
        {
            return;
        }

        Console.Write("{0} ", node.Key);
        Print(node.LeftChild);
        Print(node.RightChild);
    }

    // Намиране на минималния елемент в дърво
    private TreeNode<TKey, TValue> FindMinimalElement(TreeNode<TKey, TValue> node)
    {
        while (node.LeftChild != null)
        {
            node = node.LeftChild;
        }
        return node;
    }
}

class TreeNode<TKey, TValue>
{
    public TKey Key { get; set; }
    public TValue Value { get; set; }
    public TreeNode<TKey, TValue> Parent { get; set; }
    public TreeNode<TKey, TValue> LeftChild { get; set; }
    public TreeNode<TKey, TValue> RightChild { get; set; }

    public TreeNode(TKey key, TValue value)
    {
        this.Key = key;
        this.Value = value;
        this.Parent = null;
        this.LeftChild = null;
        this.RightChild = null;
    }
}