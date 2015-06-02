using System;

class Majorant3
{
    static void FindMajority<T>(T[] array, out T majority)
    {
        majority = default(T);
        int size2 = array.Length / 2;
        for (int i = 0; i < size2; i++)
        {
            int counter = 0;
            for (int j = i; j < array.Length; j++)
                if (counter + array.Length - j <= size2)
                    break;
                else if (array[i].Equals(array[j]))
                    counter++;
            if (counter > size2)
                majority = array[i];
        }
    }


    static void Main()
    {
        char[] array = { 'A', 'C', 'B', 'C', 'B', 'B', 'B', 'C', 'B', 'C', 'B', 'B', 'A' };
        char majority = default(char);
        FindMajority<char>(array, out majority);
        if (majority != default(char))
            Console.WriteLine("Мажорант: {0}", majority);
        else
            Console.WriteLine("Няма мажорант.");
    }
}