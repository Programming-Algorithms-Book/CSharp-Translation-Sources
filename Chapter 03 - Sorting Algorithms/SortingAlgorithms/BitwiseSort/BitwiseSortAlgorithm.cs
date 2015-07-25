namespace BitwiseSort
{
    using System;
    using System.Text;

    public class BitwiseSortAlgorithm
    {
        private const int MaxValue = 100;
        private static readonly Random Rand = new Random();

        public static NodeElement Initialize(int maxValue)
        {
            NodeElement head = null;
            for (int i = 0; i < maxValue; i++)
            {
                NodeElement element = new NodeElement
                {
                    Data =
                    {
                        Key = Rand.Next(1, maxValue * 2)
                    },
                    Next = head
                };

                head = element;
            }

            return head;
        }

        public static NodeElement BitwiseSort(NodeElement head)
        {
            if (head == null)
            {
                throw new ArgumentNullException(
                    nameof(head),
                    "NodeElement must not be null!");
            }

            /* 0. Определяне на максималната битова маска */
            long maxBit = (long)int.MaxValue + 1;

            /* 1. Фиктивен елемент в началото на списъците */
            NodeElement zeroList = new NodeElement();
            NodeElement oneList = new NodeElement();

            /* 2. Сортиране */
            for (uint bitPower = 1; bitPower < maxBit; bitPower <<= 1)
            {
                /* 2.1. Разпределяне по списъци */
                NodeElement oneEndList;
                NodeElement zeroEndList;
                for (zeroEndList = zeroList, oneEndList = oneList; head != null; head = head.Next)
                {
                    if ((head.Data.Key & bitPower) == bitPower)
                    {
                        oneEndList.Next = head;
                        oneEndList = oneEndList.Next;
                    }
                    else
                    {
                        zeroEndList.Next = head;
                        zeroEndList = zeroEndList.Next;
                    }
                }

                /* 2.2. Обединение на списъците */
                oneEndList.Next = null;
                zeroEndList.Next = oneList.Next;
                head = zeroList.Next;
            }

            return head;
        }

        internal static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            NodeElement head = Initialize(MaxValue);
            Console.WriteLine("Масива преди сортиране.");
            PrintList(head);
            Console.WriteLine("Масива след сортиране.");
            head = BitwiseSort(head);
            PrintList(head);
        }

        private static void PrintList(NodeElement head)
        {
            var firstElement = head;
            for (; head.Next != null; head = head.Next)
            {
                Console.Write(head.Data.Key + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            head = firstElement;
        }
    }
}
