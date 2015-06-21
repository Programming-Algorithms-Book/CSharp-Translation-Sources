namespace LinkedList
{
    using System;

    public class LinkeListExample
    {
        internal static void Main()
        {
            LinkedList<int> list = new LinkedList<int>();
            LinkedListNode<int> first = list.AddFirst(42);
            var random = new Random();

            for (int i = 1; i < 6; i++)
            {
                int value = random.Next() % 10;
                Console.WriteLine("Вмъкване преди: {0} - стойност {1}", first.Value, value);
                first = list.AddBefore(first, value);
            }

            LinkedListNode<int> current = first;

            for (int i = 6; i < 10; i++)
            {
                int value = random.Next() % 10;
                Console.WriteLine("Вмъкване след: {0} - стойност {1}", current.Value, value);
                current = list.AddAfter(current, value);
            }

            list.Print();

            // Изтриването на несъществуващ елемент ще доведе до грешка
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    int value = random.Next() % 10;
                    Console.WriteLine("Изтриване на елемент със стойност {0}", value);
                    list.DeleteNode(value);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                list.Print();
            }
        }
    }
}