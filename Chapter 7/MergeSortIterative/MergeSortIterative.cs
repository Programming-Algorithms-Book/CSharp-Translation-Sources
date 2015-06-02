using System;

class Program
{
    /* Елемент от свързан списък */
    class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public static Node Z { get; private set; }

        static Node()
        {
            Z = new Node { Value = int.MaxValue };
            Z.Next = Z;
        }
    }

    const int n = 100;

    static void Main()
    {
        Node l = Generate(n);
        Console.WriteLine("Преди сортирането:");
        PrintList(l);
        Console.WriteLine();
        l = MergeSort(l); /* Предполага се, че списъкът съдържа поне 1 елемент */
        Console.WriteLine("След сортирането:");
        PrintList(l);
    }

    /* Генерира примерно множество */
    static Node Generate(int n)
    {
        var rand = new Random();
        Node p = Node.Z;
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
        for (; p != Node.Z; p = p.Next)
            Console.Write("{0,4}", p.Value);
    }

    static Node Merge(Node a, Node b)
    {
        /* Предполага се, че и двата списъка съдържат поне по един елемент */
        Node tail = Node.Z;
        do
        {
            if (a.Value < b.Value)
            {
                tail.Next = a;
                tail = a;
                a = a.Next;
            }
            else
            {
                tail.Next = b;
                tail = b;
                b = b.Next;
            }
        } while (tail != Node.Z);
        tail = Node.Z.Next;
        Node.Z.Next = Node.Z;
        return tail;
    }

    static Node MergeSort(Node c)
    {
        Node head = new Node { Next = c };
        head.Next = c;
        Node a = Node.Z;
        for (int n = 1; a != head.Next; n <<= 1)
        {
            Node todo = head.Next;
            c = head;
            while (todo != Node.Z)
            {
                Node t = todo;
                /* Отделяне на a[] */
                a = t;
                for (int i = 1; i < n; i++)
                    t = t.Next;
                /* Отделяне на b[] */
                Node b = t.Next;
                t.Next = Node.Z;
                t = b;
                for (int i = 1; i < n; i++)
                    t = t.Next;
                /* Сливане на a[] и b[] */
                todo = t.Next;
                t.Next = Node.Z;
                c.Next = Merge(a, b);
                /* Пропускане на слетия масив */
                for (int i = 1; i <= n * 2; i++)
                    c = c.Next;
            }
        }
        return head.Next;
    }
}