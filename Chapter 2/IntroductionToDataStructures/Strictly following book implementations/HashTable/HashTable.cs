using System;

class HashTable
{
    private const int N = 211;
    private const int NotExist = -1;
    private static readonly LinkedList[] hashTable = new LinkedList[N];

    static void Put(long key, int data)
    {
        long place = HashFunction(key);
        InsertBegin(ref hashTable[place], key, data);
    }

    static int Get(long key)
    {
        long place = HashFunction(key);
        LinkedList list = Search(hashTable[place], key);

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
    static void InsertBegin(ref LinkedList list, long key, int data)
    {
        if (list == null)
        {
            list = new LinkedList();
            list.Key = key;
            list.Data = data;
        }
        else
        {
            LinkedList newList = new LinkedList();

            newList.Key = list.Key;
            newList.Data = list.Data;
            newList.Next = list.Next;

            list.Next = newList;
            list.Key = key;
            list.Data = data;
        }
    }

    // Изтриване на елемент от списъка
    static void DeleteNode(LinkedList list, long key)
    {
        LinkedList current = list;

        if (list.Key.Equals(key)) // Трябва да се изтрие първия елемент
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
    static LinkedList Search(LinkedList list, long key)
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

    static long HashFunction(long key)
    {
        return key % N;
    }

    static void Main()
    {
        Put(1234, 100); // в слот 179
        Put(1774, 120); // в слот 86
        Put(86, 180); // в слот 86 -> колизия

        Console.WriteLine("Отпечатва данните на елемента с ключ 86: {0}", Get(86));
        Console.WriteLine("Отпечатва данните на елемента с ключ 1234: {0}", Get(1234));
        Console.WriteLine("Отпечатва данните на елемента с ключ 1774: {0}", Get(1774));
        Console.WriteLine("Отпечатва данните на елемента с ключ 1773: {0}", Get(1773));
    }
}

class LinkedList
{
    public long Key { get; set; }
    public int Data { get; set; }
    public LinkedList Next { get; set; }
}

