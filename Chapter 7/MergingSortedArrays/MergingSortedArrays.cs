using System;
using System.Collections.Generic;
using System.Text;

namespace MergingSortedArrays
{
    struct Element
    {
        public int Key { get; set; }

        public Element(int key) : this()
        {
            this.Key = key;
        }
    }

    class CList
    {
        public int Point { get; set; }

        public Element[] Data { get; set; }

        public CList Next { get; set; }

        public int Length { get; set; }
    }

    class MergingSortedArrays
    {
        static Random rand = new Random();
        private const int NumberOfArrays = 6;
        private const int ArraysLength = 12;

        static CList InitializeArray(int modul)
        {
            CList head = null;
            for (int i = 0; i < NumberOfArrays; i++)
            {
                var currentList = new CList();
                currentList.Length = NumberOfArrays;
                currentList.Point = 0;
                currentList.Data = new Element[ArraysLength];
                currentList.Data[0].Key = rand.Next() % modul;
                for (int j = 1; j < ArraysLength; j++)
                    currentList.Data[j].Key = currentList.Data[j - 1].Key + rand.Next() % modul;
                currentList.Next = head;
                head = currentList;
            }

            return head;
        }

        static void PrintArrays(CList list)
        {
            while (list != null)
            {
                foreach (var element in list.Data)
                    Console.Write("{0} ", element.Key);
                Console.WriteLine();
                list = list.Next;
            }
        }

        private static void MergeArrays(CList head)
        {
            var currentList = new CList();
            currentList.Next = head;
            head = currentList;
            for (int i = 0; i < NumberOfArrays * ArraysLength; i++)
            {
                currentList = head;
                var minElementList = head;
                while (currentList.Next != null)
                {
                    var k1 = currentList.Next.Data[currentList.Next.Point];
                    var k2 = minElementList.Next.Data[minElementList.Next.Point];
                    if (k1.Key < k2.Key)
                        minElementList = currentList;
                    currentList = currentList.Next;
                }
                Console.WriteLine(minElementList.Next.Data[minElementList.Next.Point].Key);
                if (minElementList.Next.Data.Length - 1 == minElementList.Next.Point)
                {
                    var q = minElementList.Next;
                    minElementList.Next = minElementList.Next.Next;
                }
                else
                {
                    minElementList.Next.Point++;
                }
            }
        }

        static void Main()
        {
            var head = InitializeArray(500);
            Console.WriteLine("Масивите преди сортирането:");
            PrintArrays(head);
            MergeArrays(head);
        }
    }
}
