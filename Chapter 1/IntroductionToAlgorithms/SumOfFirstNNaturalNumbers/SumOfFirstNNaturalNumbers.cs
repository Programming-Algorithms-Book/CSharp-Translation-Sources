using System;

class SumOfFirstNNaturalNumbers
{
    static void Main()
    {
        Console.Write("Въведете N: ");
        uint n = uint.Parse(Console.ReadLine());
        ulong sum = GetSum(n);
        Console.WriteLine("Сумата на първите {0} естествени числа е {1}", n, sum);
    }

    static ulong GetSum(uint n)
    {
        ulong sum = 0UL;
        for (uint i = 1; i <= n; i++)
            sum += i;
        return sum;
    }
}
