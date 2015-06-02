using System;

class Program
{
    static void Main()
    {
        Solve(3, 7);
    }
    
    /* намалява p/q, докато p стане равно на 1 */
    static void Cancel(ref long p, ref long q)
    {
        if (q % p == 0)
        {
            q /= p;
            p = 1;
        }
    }
    
    static void Solve(long p, long q)
    {
        Console.Write("{0}/{1} = ", p, q);
        Cancel(ref p, ref q);
    
        while (p > 1)
        {
            /* намира максималната дроб 1/r, 1/r<=p/q */
            long r = (q + p) / p;
            Console.Write("{0}/{1} + ", 1, r);
    
            /* изчислява p/q - 1/r */
            p = p * r - q;
            q = q * r;
            Cancel(ref p, ref q);
        }
        if (p > 0) Console.Write("{0}/{1}", p, q);
        Console.WriteLine();
    }
}
