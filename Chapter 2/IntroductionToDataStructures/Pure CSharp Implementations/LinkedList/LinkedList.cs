using System;

class LinkeListExample
{
    static Random random = new Random();

    static void Main()
    {
        LinkedList<int> list = new LinkedList<int>();
        LinkedListNode<int> first = list.AddFirst(42);

        for (int i = 1; i < 6; i++)
        {
            int value = random.Next() % 10;
            Console.WriteLine("Вмъкване преди: {0} - стойност {1}", first.Value, value);
            first = list.AddBefore(first, value);
        }

        LinkedListNode<int> current = first;

        for (int i = 6; i < 10; i++)
        {
            int value = random.Next() % 10;
            Console.WriteLine("Вмъкване след: {0} - стойност {1}", current.Value, value);
            current = list.AddAfter(current, value);
        }

        list.Print();

        // Изтриването на несъществуващ елемент ще доведе до грешка
        for (int i = 0; i < 5; i++)
        {
            try
            {
                int value = random.Next() % 10;
                Console.WriteLine("Изтриване на елемент със стойност {0}", value);
                list.DeleteNode(value);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }

            list.Print();
        }
    }
}

class LinkedList<T>
{
    public LinkedListNode<T> First { get; private set; }
    public LinkedListNode<T> Last { get; private set; }
    public int Count { get; private set; }

    // Създава елемент по стойност и го включва в началото на свързания списък
    public LinkedListNode<T> AddFirst(T value)
    {
        LinkedListNode<T> node = new LinkedListNode<T>(value);
        this.AddFirst(node);
        return node;
    }

    // Включва елемент в началото на свързания списък
    public void AddFirst(LinkedListNode<T> node)
    {
        if (node == null)
        {
            throw new ArgumentNullException("Грешка: Елементът не може да бъде null!");
        }

        if (this.First == null)
        {
            this.First = node;
            this.Last = node;
        }
        else
        {
            node.Next = this.First;
            this.First.Previous = node;
            this.First = node;
        }

        node.List = this;
        this.Count++;
    }

    // Създава елемент по стойност и го включва в края на свързания списък
    public LinkedListNode<T> AddLast(T value)
    {
        LinkedListNode<T> node = new LinkedListNode<T>(value);
        this.AddLast(node);
        return node;
    }

    // Включва елемент в края на свързания списък
    public void AddLast(LinkedListNode<T> node)
    {
        if (node == null)
        {
            throw new ArgumentNullException("Грешка: Елементът не може да бъде null!");
        }

        if (this.Last == null)
        {
            this.First = node;
            this.Last = node;
        }
        else
        {
            node.Previous = this.Last;
            this.Last.Next = node;
            this.Last = node;
        }

        node.List = this;
        this.Count++;
    }

    // Създава елемент по стойност и го включва след даден елемент
    public LinkedListNode<T> AddAfter(LinkedListNode<T> afterNode, T value)
    {
        LinkedListNode<T> node = new LinkedListNode<T>(value);
        AddAfter(afterNode, node);
        return node;
    }

    // Включва след елемент
    public void AddAfter(LinkedListNode<T> afterNode, LinkedListNode<T> node)
    {
        if (afterNode == null)
        {
            throw new ArgumentNullException("Грешка: Елементът не може да бъде null!");
        }

        if (afterNode.List != this)
        {
            throw new InvalidOperationException("Грешка: Елементът не е в списъка!");
        }

        if (afterNode.Next == null)
        {
            this.AddLast(node);
            return;
        }

        afterNode.Next.Previous = node;
        node.Next = afterNode.Next;
        node.Previous = afterNode;
        afterNode.Next = node;

        node.List = this;
        this.Count++;
    }

    // Създава елемент по стойност и го включва преди даден елемент
    public LinkedListNode<T> AddBefore(LinkedListNode<T> beforeNode, T value)
    {
        LinkedListNode<T> node = new LinkedListNode<T>(value);
        AddBefore(beforeNode, node);
        return node;
    }

    // Включва преди елемент
    public void AddBefore(LinkedListNode<T> beforeNode, LinkedListNode<T> node)
    {
        if (beforeNode == null)
        {
            throw new ArgumentNullException("Грешка: Елементът не може да бъде null!");
        }

        if (beforeNode.List != this)
        {
            throw new InvalidOperationException("Грешка: Елементът не е в списъка!");
        }

        if (beforeNode.Previous == null)
        {
            this.AddFirst(node);
            return;
        }

        beforeNode.Previous.Next = node;
        node.Previous = beforeNode.Previous;
        node.Next = beforeNode;
        beforeNode.Previous = node;

        node.List = this;
        this.Count++;
    }

    // Изтрива елемент на свързания списък
    public void DeleteNode(LinkedListNode<T> node)
    {
        if (node == null)
        {
            throw new ArgumentNullException("Грешка: Елементът не може да бъде null!");
        }

        if (node.List != this)
        {
            throw new InvalidOperationException("Грешка: Елементът не е в списъка!");
        }

        if (node.Previous != null && node.Next != null)
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            node.Previous = null;
            node.Next = null;
        }
        else if (node.Previous == null)
        {
            this.First = this.First.Next;
        }
        else if (node.Next == null)
        {
            this.Last = this.Last.Previous;
        }

        node.List = null;
        this.Count--;
    }

    // Изтрива първия срещнат елемент със стойност равна на подадената
    public void DeleteNode(T value)
    {
        LinkedListNode<T> node = Find(value);

        if (node == null)
        {
            throw new InvalidOperationException("Грешка: Не е намерен елемент за изтриване!");
        }

        if (node != null)
        {
            DeleteNode(node);
        }
    }

    // Връща първия срещнат елемент със стойност равна на подадената
    public LinkedListNode<T> Find(T value)
    {
        if (this.First == null) // Списъкът е празен
        {
            return null;
        }

        LinkedListNode<T> node = this.First;

        if (node.Value.Equals(value))
        {
            return node;
        }

        while (node.Next != null)
        {
            node = node.Next;
            if (node.Value.Equals(value))
            {
                return node;
            }
        }

        return null;
    }

    public void Clear()
    {
        this.First = null;
        this.Last = null;
        this.Count = 0;
    }

    // Отпечатва елементите на свързания списък
    public void Print()
    {
        LinkedListNode<T> current = this.First;

        while (current != null)
        {
            Console.Write("{0} ", current.Value);
            current = current.Next;
        }

        Console.WriteLine();
    }
}

class LinkedListNode<T>
{
    public T Value { get; set; }
    public LinkedListNode<T> Next { get; set; }
    public LinkedListNode<T> Previous { get; set; }
    public LinkedList<T> List { get; set; }

    public LinkedListNode(T value)
    {
        this.Value = value;
    }
}