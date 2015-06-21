namespace HashTable
{
    using System;

    public class HashTable
    {
        private const int N = 211;
        private const int NotExist = -1;
        private static readonly LinkedList[] InnerHashTable = new LinkedList[N];

        internal static void Main()
        {
            Put(1234, 100); // в слот 179
            Put(1774, 120); // в слот 86
            Put(86, 180); // в слот 86 -> колизия

            Console.WriteLine("Отпечатва данните на елемента с ключ 86: {0}", Get(86));
            Console.WriteLine("Отпечатва данните на елемента с ключ 1234: {0}", Get(1234));
            Console.WriteLine("Отпечатва данните на елемента с ключ 1774: {0}", Get(1774));
            Console.WriteLine("Отпечатва данните на елемента с ключ 1773: {0}", Get(1773));
        }

        private static void Put(long key, int data)
        {
            long place = HashFunction(key);
            InsertBegin(ref InnerHashTable[place], key, data);
        }

        private static int Get(long key)
        {
            long place = HashFunction(key);
            LinkedList list = Search(InnerHashTable[place], key);

            if (list == null)
            {
                return NotExist;
            }
            else
            {
                return list.Data;
            }
        }

        // Включва елемент в началото на свързан списък
        private static void InsertBegin(ref LinkedList list, long key, int data)
        {
            if (list == null)
            {
                list = new LinkedList
                {
                    Key = key,
                    Data = data
                };
            }
            else
            {
                LinkedList newList = new LinkedList
                {
                    Key = list.Key,
                    Data = list.Data,
                    Next = list.Next
                };

                list.Next = newList;
                list.Key = key;
                list.Data = data;
            }
        }

        // Изтриване на елемент от списъка
        private static void DeleteNode(LinkedList list, long key)
        {
            LinkedList current = list;

            // Трябва да се изтрие първия елемент
            if (list.Key.Equals(key))
            {
                current = list.Next;
                list.Key = current.Key;
                list.Data = current.Data;
                list.Next = current.Next;
                return;
            }

            while (current.Next != null && !current.Next.Key.Equals(key))
            {
                current = current.Next;
            }

            if (current.Next == null)
            {
                throw new InvalidOperationException("Грешка: Елементът за изтриване не е намерен!");
            }
            else
            {
                current.Next = current.Next.Next;
            }
        }

        // Търси по ключ елемент в свързан списък
        private static LinkedList Search(LinkedList list, long key)
        {
            while (list != null)
            {
                if (list.Key.Equals(key))
                {
                    return list;
                }
                else
                {
                    list = list.Next;
                }
            }

            return null;
        }

        private static long HashFunction(long key)
        {
            return key % N;
        }
    }
}