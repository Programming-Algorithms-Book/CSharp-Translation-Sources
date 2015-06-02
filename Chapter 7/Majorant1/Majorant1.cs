using System;

class Majorant1
{
    static int CountElements<T>(T[] array, T candidate)
    {
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
            if (array[i].Equals(candidate))
                counter++;

        return counter;
    }

    static void FindMajority<T>(T[] array, out T majority)
    {
        majority = default(T);
        var size = array.Length/2;
        for (int i = 0; i < array.Length; i++)
            if (CountElements(array, array[i]) > size)
                majority = array[i];
    }

    static void Main()
    {
        char[] array = {'A', 'C', 'C', 'C', 'C', 'B', 'B', 'C', 'C', 'C', 'B', 'C', 'C'};
        char majority = default(char);
        FindMajority<char>(array, out majority);
        if (majority != default(char))
            Console.WriteLine("Мажорант: {0}", majority);
        else
            Console.WriteLine("Масивът няма мажорант.");
    }
}