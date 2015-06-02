using System;

class Program
{
    /* Елемент от свързан списък */
    class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }

    const int n = 100;

    static void Main()
    {
        Node l = Generate(n);
        Console.WriteLine("Преди сортирането:");
        PrintList(l);
        Console.WriteLine();
        l = MergeSort(l, n);
        Console.WriteLine("След сортирането:");
        PrintList(l);
    }

    static Node Generate(int n)
    {
        var rand = new Random();
        Node p = null;
        for (int i = 0; i < n; i++)
        {
            var q = new Node { Value = rand.Next() % (2 * n + 1), Next = p };
            p = q;
        }
        return p;
    }

    /* Извежда списъка на екрана */
    static void PrintList(Node p)
    {
        for (; p != null; p = p.Next)
            Console.Write("{0,4}", p.Value);
    }

    static Node MergeSort(Node c, int n)
    {
        /* Ако списъкът съдържа само един елемент: не се прави нищо */
        if (n < 2)
            return c;
        Node a = c;
        int n2 = n / 2;
        /* Разделяне на списъка на две части */
        for (int i = 2; i <= n2; i++)
            c = c.Next;

        Node b = c.Next;
        c.Next = null;

        /* Сортиране поотделно на двете части, последвано от сливане */
        return Merge(MergeSort(a, n2), MergeSort(b, n - n2));
    }

    static Node Merge(Node a, Node b)
    {
        /* Предполага се, че и двата списъка съдържат поне по един елемент */
        Node tail = new Node();
        Node head = tail;
        while (true)
        {
            if (a.Value < b.Value)
            {
                tail.Next = a;
                a = a.Next;
                tail = tail.Next;
                if (a == null)
                {
                    tail.Next = b;
                    break;
                }
            }
            else
            {
                tail.Next = b;
                b = b.Next;
                tail = tail.Next;
                if (b == null)
                {
                    tail.Next = a;
                    break;
                }
            }
        }
        return head.Next;
    }
}