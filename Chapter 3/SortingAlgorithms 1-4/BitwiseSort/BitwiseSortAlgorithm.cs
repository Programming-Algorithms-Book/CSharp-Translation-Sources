using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitwiseSort
{
    class BitwiseSortAlgorithm
    {
        public class Element
        {
            public int Key { get; set; }
        }

        public class NodeElement
        {
            public Element Data { get; set; }
            public NodeElement Next { get; set; }

            public NodeElement()
            {
                this.Data = new Element();
            }

            public override string ToString()
            {
                return Data.Key.ToString();
            }
        }


        const int MaxValue = 100;
        static Random rand = new Random();

        static NodeElement Initialize()
        {
            NodeElement head = null;
            for (int i = 0; i < MaxValue; i++)
            {
                NodeElement element = new NodeElement();
                element.Data.Key = rand.Next(1, MaxValue * 2);
                element.Next = head;
                head = element;
            }

            return head;
        }

        static NodeElement BitwiseSort(NodeElement head)
        {
            uint maxBit;

            /* 0. Определяне на максималната битова маска */
            maxBit = (uint)int.MaxValue + 1;

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

        static void PrintList(NodeElement head)
        {
            var firstElement = head;
            for (; head.Next != null; head = head.Next)
                Console.Write(head.Data.Key + " ");

            head = firstElement;
        }

        static void Check(NodeElement head)
        {
            for (; head.Next != null; head = head.Next)
                if (head.Data.Key > head.Next.Data.Key)
                    throw new Exception("Масива не е сортиран правилно.");
        }

        static void Main(string[] args)
        {
            NodeElement head;
            head = Initialize();
            Console.WriteLine("Масива преди сортиране.");
            PrintList(head);
            Console.WriteLine("Масива след сортиране.");
            head = BitwiseSort(head);
            Check(head);
            PrintList(head);
        }
    }
}
