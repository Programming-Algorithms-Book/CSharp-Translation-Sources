namespace MergesortLinkedListDoubleStep
{
    using System;

    public class Program
    {
        private const int N = 100;

        internal static void Main()
        {
            Node l = Generate(N);
            Console.WriteLine("Преди сортирането:");
            PrintList(l);
            Console.WriteLine();
            l = MergeSort(l); /* Предполага се, че списъкът съдържа поне 1 елемент */
            Console.WriteLine("След сортирането:");
            PrintList(l);
        }

        /* Генерира примерно множество */
        private static Node Generate(int n)
        {
            var rand = new Random();
            Node p = Node.Z;
            for (int i = 0; i < n; i++)
            {
                var q = new Node { Value = rand.Next() % ((2 * n) + 1), Next = p };
                p = q;
            }

            return p;
        }

        /* Извежда списъка на екрана */
        private static void PrintList(Node p)
        {
            for (; p != Node.Z; p = p.Next)
            {
                Console.Write("{0,4}", p.Value);
            }
        }

        private static Node Merge(Node a, Node b)
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
            }
            while (tail != Node.Z);
            tail = Node.Z.Next;
            Node.Z.Next = Node.Z;
            return tail;
        }

        private static Node MergeSort(Node c)
        {
            /* Ако списъкът съдържа само един елемент: не се прави нищо */
            if (c.Next == Node.Z)
            {
                return c;
            }

            Node a = c;
            Node b = c.Next.Next.Next;
            /* Списъкът се разделя на две части */
            while (b != Node.Z)
            {
                b = b.Next.Next;
                c = c.Next;
            }

            b = c.Next;
            c.Next = Node.Z;

            /* Сортиране поотделно на двете части, последвано от сливане */
            return Merge(MergeSort(a), MergeSort(b));
        }
    }
}