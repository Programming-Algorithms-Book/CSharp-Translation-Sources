using System;
using System.Linq;

class Program
{
    static void Main()
    {
        const double M = 16;                      /* ограничително тегло на раницата */
        double[] value = { 25.0, 12.0, 16.0 };    /* себестойност на предметите */
        double[] quant = { 10.0, 8.0, 8.0 };      /* количества от предметите */
        double[] ratio = value.Zip(quant, (v, q) => v / q).ToArray(); /* отношения стойност/количество  */
        Sort(ratio, value, quant);
        Solve(M, value, quant);
    }
    
    static void Swap(ref double a, ref double b)
    {
        double temp = a; a = b; b = temp; 
    }
    
    /* сортира предметите по себестойност */
    static void Sort(double[] ratio, double[] value, double[] quant)
    {
        for (int i = 0; i < ratio.Length - 1; i++)
            for (int j = i + 1; j < ratio.Length; j++)
                if (ratio[j] > ratio[i])
                {
                    Swap(ref value[i], ref value[j]);
                    Swap(ref quant[i], ref quant[j]);
                    Swap(ref ratio[i], ref ratio[j]);
                }
    }
    
    /* намира решението */
    static void Solve(double M, double[] value, double[] quant)
    {
        int i = 0;
        double T = 0, V = 0;
        while (T + quant[i] <= M)
        {   /* взима цели предмети, докато може */
            Console.WriteLine("Избира 100% от предмет със стойност {0:F2} и тегло {1:F2}", value[i], quant[i]);
            T += quant[i]; V += value[i];
            i++;
        }
        Console.WriteLine("Избира се {0:F2}% от предмет със стойност {1:F2} и тегло {2:F2}", 
                          ((M - T) / quant[i]) * 100, value[i], quant[i]);
        V += (M - T) * (value[i] / quant[i]);
        Console.WriteLine("Обща получена цена: {0:F2}\n", V);
    }
}