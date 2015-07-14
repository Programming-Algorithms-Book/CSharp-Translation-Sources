namespace BitwiseSort
{
    using System;

    public class BitwiseSortAlgorithm
    {
        private const int MaxValue = 100;
        private static readonly Random Rand = new Random();

        internal static void Main(string[] args)
        {
            NodeElement head = Initialize();
            Console.WriteLine("Масива преди сортиране.");
            PrintList(head);
            Console.WriteLine("Масива след сортиране.");
            head = BitwiseSort(head);
            Check(head);
            PrintList(head);
        }

        private static NodeElement Initialize()
        {
            NodeElement head = null;
            for (int i = 0; i < MaxValue; i++)
            {
                NodeElement element = new NodeElement();
                element.Data.Key = Rand.Next(1, MaxValue * 2);
                element.Next = head;
                head = element;
            }

            return head;
        }

        private static NodeElement BitwiseSort(NodeElement head)
        {
            /* 0. Определяне на максималната битова маска */
            long maxBit = (long)int.MaxValue + 1;

            /* 1. Фиктивен елемент в началото на списъците */
            NodeElement zeroList = new NodeElement();
            NodeElement oneList = new NodeElement();
            NodeElement oneEndList;
            NodeElement zeroEndList;

            /* 2. Сортиране */
            for (uint bitPower = 1; bitPower < maxBit; bitPower <<= 1)
            {
                /* 2.1. Разпределяне по списъци */
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

        private static void PrintList(NodeElement head)
        {
            var firstElement = head;
            for (; head.Next != null; head = head.Next)
            {
                Console.Write(head.Data.Key + " ");
            }

            head = firstElement;
        }

        private static void Check(NodeElement head)
        {
            for (; head.Next != null; head = head.Next)
            {
                if (head.Data.Key > head.Next.Data.Key)
                {
                    throw new Exception("Масива не е сортиран правилно.");
                }
            }
        }
    }
}
