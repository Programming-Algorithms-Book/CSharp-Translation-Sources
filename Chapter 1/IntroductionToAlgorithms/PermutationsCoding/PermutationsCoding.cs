using System;

class PermutationsCoding
{
    const uint n = 6;
    const uint Code = 551;

    static readonly uint[] Permutation = { 5, 3, 6, 4, 2, 1 };

    static ulong CodePermutation(uint n, uint[] permutation)
    {
        uint[] p = new uint[n];
        ulong r = 0;
        ulong result = 0;
        for (uint i = 0; i < n; i++) p[i] = i + 1;
        for (uint pos = 0; pos < n; pos++)
        {
            r = 0;
            while (permutation[pos] != p[r]) r++;
            result = result * (n - pos) + r;
            for (ulong i = r + 1; i < n; i++) p[i - 1] = p[i];
        }

        return result;
    }

    static void DecodePermutation(uint codeNumber, uint n, uint[] permutation)
    {
        uint[] p = new uint[n];
        for (uint i = 0; i < n; i++) p[i] = i + 1;
        uint k = n;
        uint m = 0;
        do
        {
            m = n - k + 1;
            permutation[k - 1] = codeNumber % m;
            if (k > 1) codeNumber /= m;
        } while (--k > 0);
        k = 0;
        do
        {
            m = permutation[k];
            permutation[k] = p[m];
            if (k < n)
                for (uint i = m + 1; i < n; i++) p[i - 1] = p[i];
        } while (++k < n);
    }

    static void Main()
    {
        Console.WriteLine("Дадената пермутация се кодира като {0} \n", CodePermutation(n, Permutation));
        Console.Write("Декодираме пермутацията отговаряща на числото {0}: ", Code);
        DecodePermutation(Code, n, Permutation);
        for (uint i = 0; i < n; i++) Console.Write("{0} ", Permutation[i]);
        Console.WriteLine();
    }
}
