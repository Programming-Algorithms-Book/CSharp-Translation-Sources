namespace BinaryTree
{
    using System;

    public struct BinaryTree<TKey, TValue>
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

            this.root = this.Insert(key, value, null, this.root);
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
            TreeNode<TKey, TValue> nodeToDelete = this.Search(key);

            if (nodeToDelete == null)
            {
                throw new InvalidOperationException("Върхът, който трябва да се изключи, липсва!");
            }
            else
            {
                this.Remove(nodeToDelete);
            }
        }

        public void Print()
        {
            this.Print(this.root);
        }

        private void Print(TreeNode<TKey, TValue> node)
        {
            if (node == null)
            {
                return;
            }

            Console.Write("{0} ", node.Key);
            this.Print(node.LeftChild);
            this.Print(node.RightChild);
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

        private TreeNode<TKey, TValue> Insert(
            TKey key, 
            TValue value,
            TreeNode<TKey, TValue> parentNode, 
            TreeNode<TKey, TValue> currentNode)
        {
            // Текущия елемент е лист или празно дърво
            if (currentNode == null)
            {
                currentNode = new TreeNode<TKey, TValue>(key, value);
                currentNode.Parent = parentNode;
            }
            else
            {
                if (key.CompareTo(currentNode.Key) < 0)
                {
                    currentNode.LeftChild = this.Insert(key, value, currentNode, currentNode.LeftChild);
                }
                else if (key.CompareTo(currentNode.Key) > 0)
                {
                    currentNode.RightChild = this.Insert(key, value, currentNode, currentNode.RightChild);
                }
                else
                {
                    currentNode.Value = value;
                }
            }

            return currentNode;
        }

        private void Remove(TreeNode<TKey, TValue> nodeToDelete)
        {
            // Елементът за изключване е намерен и има два наследника
            if (nodeToDelete.LeftChild != null && nodeToDelete.RightChild != null)
            {
                // Намира се върхът за размяна. По дефиниция минималния елемент
                // от дясното поддърво заменя елементът, който трябва да бъде изтрит
                TreeNode<TKey, TValue> replacementNode = nodeToDelete.RightChild;
                replacementNode = this.FindMinimalElement(replacementNode);
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

            // Елементът за изтриване има едно дете
            if (tempNode != null)
            {
                tempNode.Parent = nodeToDelete.Parent;

                // Елементът е корена на дървото
                if (nodeToDelete.Parent == null)
                {
                    this.root = tempNode;
                }
                else
                {
                    // Размяна на елемента за изтриване със неговите поддървета
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
            else 
            {
                // Елементът има нула или едно поддървета
                // Елементът е коренa
                if (nodeToDelete.Parent == null)
                {
                    this.root = null;
                }
                else 
                {
                    // Елементът е листо
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
    }
}