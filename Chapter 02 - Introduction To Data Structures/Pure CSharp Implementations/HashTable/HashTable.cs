namespace HashTable
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Можем да използваме имплементирания от нас свързан списък, но за по-голямо удобство 
    /// в тази имплементация на Хеш таблица ще се използва вградения в .NET
    /// </summary>
    public class HashTable<K, T>
    {
        private const double Overflow = 0.8;
        private const int DefaultCapacity = 211;

        private LinkedList<KeyValuePair<K, T>>[] hashList;
        private int totalCount;

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
            get { return this.Find(key); }
            set { this.Add(key, value); }
        }

        // Намира стойност по ключ
        public T Find(K key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Грешка: Ключът не може да бъде null!");
            }

            int index = this.GetHashedIndex(key);

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

            int index = this.GetHashedIndex(key);
            KeyValuePair<K, T> newPair = new KeyValuePair<K, T>(key, value);
            LinkedList<KeyValuePair<K, T>> chain = this.GetChain(index);

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

            var index = this.GetHashedIndex(key);
            var chain = this.GetChain(index);

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
}