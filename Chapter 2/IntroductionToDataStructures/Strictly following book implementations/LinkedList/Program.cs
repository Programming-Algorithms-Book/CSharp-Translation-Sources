﻿namespace LinkedList
{
    using System;

    public class Program
    {
        private static readonly Random Random = new Random();

        internal static void Main()
        {
            LinkedList<int, int> list = null;
            InsertBegin<int, int>(ref list, 0, 42);

            for (int i = 1; i < 6; i++)
            {
                int data = Random.Next() % 100;
                Console.WriteLine("Вмъкване преди: {0}({1})", i, data);
                InsertBefore<int, int>(list, i, data);
            }

            for (int i = 6; i < 10; i++)
            {
                int data = Random.Next() % 100;
                Console.WriteLine("Вмъкване след: {0}({1})", i, data);
                InsertAfter<int, int>(list, i, data);
            }

            Print<int, int>(list);
            DeleteNode<int, int>(list, 9);
            Print<int, int>(list);
            DeleteNode<int, int>(list, 0);
            Print<int, int>(list);
            DeleteNode<int, int>(list, 3);
            Print<int, int>(list);
            DeleteNode<int, int>(list, 5);
            Print<int, int>(list);
        
            // Изтриването на несъществуващ елемент ще доведе до грешка
            ////DeleteNode<int, int>(list, 5);
        }

        // Включва елемент в началото на свързан списък
        private static void InsertBegin<T, K>(ref LinkedList<T, K> list, K key, T data)
        {
            if (list == null)
            {
                list = new LinkedList<T, K>
                {
                    Key = key,
                    Data = data
                };
            }
            else
            {
                LinkedList<T, K> newList = new LinkedList<T, K>();

                newList.Key = list.Key;
                newList.Data = list.Data;
                newList.Next = list.Next;

                list.Next = newList;
                list.Key = key;
                list.Data = data;
            }
        }

        // Включва след елемент
        private static void InsertAfter<T, K>(LinkedList<T, K> list, K key, T data)
        {
            // Ако списъка е празен => специален случай
            if (list == null)
            {
                InsertBegin<T, K>(ref list, key, data);
                return;
            }

            LinkedList<T, K> newList = new LinkedList<T, K>
            {
                Key = key,
                Data = data,
                Next = list.Next
            };

            list.Next = newList;
        }

        // Включва преди елемента
        private static void InsertBefore<T, K>(LinkedList<T, K> list, K key, T data)
        {
            // Елемента трябва да се вмъкне преди първия
            if (list == null)
            {
                InsertBegin<T, K>(ref list, key, data);
                return;
            }

            LinkedList<T, K> newList = new LinkedList<T, K>
            {
                Data = list.Data,
                Key = list.Key,
                Next = list.Next
            };

            list.Next = newList;
            list.Key = key;
            list.Data = data;
        }

        // Изтриване на елемент от списъка
        private static void DeleteNode<T, K>(LinkedList<T, K> list, K key)
        {
            LinkedList<T, K> current = list;

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

        // Отпечатва елементите на свързан списък
        private static void Print<T, K>(LinkedList<T, K> list)
        {
            while (list != null)
            {
                Console.Write("{0}({1}) ", list.Key, list.Data);
                list = list.Next;
            }

            Console.WriteLine();
        }

        // Търси по ключ елемент в свързан списък
        private static LinkedList<T, K> Search<T, K>(LinkedList<T, K> list, K key)
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
    }
}