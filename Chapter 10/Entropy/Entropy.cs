using System;

class Program
{
    static void Main()
    {
        double[] probs = new[]{ 0.2, 0.2, 0.15, 0.15, 0.10, 0.10, 0.05, 0.05 };
        
        Console.Write("Източник, зададен с честоти на срещане: ");
        foreach (double prob in probs)
            Console.Write("{0:F2} ", prob);
        Console.WriteLine();
    
        double entr = CalcEntropy(probs);
        Console.WriteLine("Ентропия на източника: {0:F5}", entr);
        Console.WriteLine("Теоретична цена на кода: {0:F5}", entr + 1);
        
        int[] lengths = CalcLengths(probs);
        Console.Write("Дължини на кодовете: ");
        for (int i = 0; i < lengths.Length; i++)
            Console.Write("{0} ", lengths[i]);
        Console.WriteLine();
        Console.WriteLine("Цена на кода при горните дължини: {0:F2}", CalcValue(probs, lengths));
    }
    
    /* Пресмята ентропията на източника */
    static double CalcEntropy(double[] probs) 
    {
        // също sum = -probs.Select(p*Math.Log(p, 2)).Sum()j
        double sum = 0;
        for (int i = 0; i < probs.Length; i++)
            sum -= probs[i]*Math.Log(probs[i], 2);
        return sum;
    }
    
    /* Пресмята дължините на кодовете на отделните букви */
    static int[] CalcLengths(double[] probs)
    {
        // също probs.Select(p => Math.Ceiling(Math.Log(1.0 / p, 2))).ToArray()
        int[] lengths = new int[probs.Length];
        for (int i = 0; i < probs.Length; i++)
            lengths[i] = (int)Math.Ceiling(Math.Log(1.0 / probs[i], 2));
        return lengths;
    }
    
    /* Пресмята цената на кода */
    static double CalcValue(double[] probs, int[] lengths)
    {
        // също sum = probs.Zip(lengths, (p, l) => p*l).Sum()
        double sum = 0;
        for (int i = 0; i < probs.Length; i++)
            sum += probs[i]*lengths[i];
        return sum;
    }
}
