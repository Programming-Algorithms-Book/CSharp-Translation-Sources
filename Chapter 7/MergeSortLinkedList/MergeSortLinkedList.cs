namespace MergeSortLinkedList
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
            l = MergeSort(l, N);
            Console.WriteLine("След сортирането:");
            PrintList(l);
        }

        private static Node Generate(int n)
        {
            var rand = new Random();
            Node p = null;
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
            for (; p != null; p = p.Next)
            {
                Console.Write("{0,4}", p.Value);
            }
        }

        private static Node MergeSort(Node c, int n)
        {
            /* Ако списъкът съдържа само един елемент: не се прави нищо */
            if (n < 2)
            {
                return c;
            }

            Node a = c;
            int n2 = n / 2;
            /* Разделяне на списъка на две части */
            for (int i = 2; i <= n2; i++)
            {
                c = c.Next;
            }

            Node b = c.Next;
            c.Next = null;

            /* Сортиране поотделно на двете части, последвано от сливане */
            return Merge(MergeSort(a, n2), MergeSort(b, n - n2));
        }

        private static Node Merge(Node a, Node b)
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
}