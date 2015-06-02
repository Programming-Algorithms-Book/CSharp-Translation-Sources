using System;
using System.Collections.Generic;

class HashTableExample
{
    static void Main()
    {
        HashTable<int, int> hashTable = new HashTable<int, int>();

        hashTable.Add(1234, 100); // в слот 179
        hashTable.Add(1774, 120); // в слот 86
        hashTable.Add(86, 180); // в слот 86 -> колизия

        Console.WriteLine("Отпечатва данните на елемента с ключ 86: {0}", hashTable.Find(86));
        Console.WriteLine("Отпечатва данните на елемента с ключ 1234: {0}", hashTable.Find(1234));
        Console.WriteLine("Отпечатва данните на елемента с ключ 1774: {0}", hashTable.Find(1774));

        try
        {
            Console.WriteLine("Отпечатва данните на елемента с ключ 1773: {0}", hashTable.Find(1773));
        }
        catch (InvalidOperationException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
    }
}


// Можем да използваме имплементирания от нас свързан списък, но за по-голямо удобство
// в тази имплементация на Хеш таблица ще се използва вградения в .NET
class HashTable<K, T>
{
    private const int DefaultCapacity = 211;

    private LinkedList<KeyValuePair<K, T>>[] hashList;
    private int totalCount;
    private const double Overflow = 0.8;

    public HashTable(int capacity = DefaultCapacity)
    {
        this.hashList = new LinkedList<KeyValuePair<K, T>>[capacity];
    }

    public int Count
    {
        get { return this.totalCount; }
    }

    // Индексатор за по-лесна работа с хеш таблицата.
    public T this[K key]
    {
        get { return Find(key); }
        set { Add(key, value); }
    }

    // Намира стойност по ключ
    public T Find(K key)
    {
        if (key == null)
        {
            throw new ArgumentNullException("Грешка: Ключът не може да бъде null!");
        }

        int index = GetHashedIndex(key);

        if (this.hashList[index] != null)
        {
            foreach (KeyValuePair<K, T> pair in this.hashList[index])
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }
        }

        throw new InvalidOperationException("Грешка: Ключът не е намерен!");
    }

    // Добавя двойка ключ-стойност
    public void Add(K key, T value)
    {
        if (key == null)
        {
            throw new ArgumentNullException("Грешка: ключът не може да бъде null!");
        }

        int index = GetHashedIndex(key);
        KeyValuePair<K, T> newPair = new KeyValuePair<K, T>(key, value);
        LinkedList<KeyValuePair<K, T>> chain = GetChain(index);

        if (chain != null)
        {
            foreach (KeyValuePair<K, T> pair in chain)
            {
                if (pair.Key.Equals(newPair.Key))
                {
                    this.totalCount--;
                    chain.Remove(pair);
                    break;
                }
            }
        }

        chain.AddLast(newPair);
        this.totalCount++;

        if (this.totalCount > this.hashList.Length * Overflow)
        {
            this.Resize();
        }
    }

    // Премахва двойка ключ-стойност
    public bool Remove(K key)
    {
        if (key == null)
        {
            throw new ArgumentNullException("Грешка: ключът не може да бъде null!");
        }

        var index = GetHashedIndex(key);
        var chain = GetChain(index);

        if (chain != null)
        {
            foreach (KeyValuePair<K, T> pair in chain)
            {
                if (pair.Key.Equals(key))
                {
                    chain.Remove(pair);
                    this.totalCount--;
                    return true;
                }
            }
        }

        return false;
    }

    public void Clear()
    {
        this.hashList = new LinkedList<KeyValuePair<K, T>>[this.hashList.Length];
        this.totalCount = 0;
    }

    private void Resize()
    {
        LinkedList<KeyValuePair<K, T>>[] oldHashList = this.hashList;
        this.hashList = new LinkedList<KeyValuePair<K, T>>[oldHashList.Length * 2];

        for (int i = 0; i < oldHashList.Length; i++)
        {
            if (oldHashList[i] != null)
            {
                foreach (KeyValuePair<K, T> pair in oldHashList[i])
                {
                    this.Add(pair.Key, pair.Value);
                }
            }
        }
    }

    private LinkedList<KeyValuePair<K, T>> GetChain(int index)
    {
        if (this.hashList[index] == null)
        {
            this.hashList[index] = new LinkedList<KeyValuePair<K, T>>();
        }

        LinkedList<KeyValuePair<K, T>> chain = this.hashList[index];
        return chain;
    }

    private int GetHashedIndex(K key)
    {
        int hashedIndex = key.GetHashCode() % this.hashList.Length;

        if (hashedIndex > 0)
        {
            return hashedIndex;
        }
        else
        {
            return hashedIndex * -1;
        }
    }
}