namespace HashTable
{
    using System;

    public class HashTableExample
    {
        internal static void Main()
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
}
