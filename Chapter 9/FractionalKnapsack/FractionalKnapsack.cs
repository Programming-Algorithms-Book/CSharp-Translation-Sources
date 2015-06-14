namespace FractionalKnapsack
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            const double M = 16; /* ограничително тегло на раницата */
            double[] value = { 25.0, 12.0, 16.0 }; /* себестойност на предметите */
            double[] quant = { 10.0, 8.0, 8.0 }; /* количества от предметите */
            double[] ratio = value.Zip(quant, (v, q) => v / q).ToArray(); /* отношения стойност/количество  */
            Sort(ratio, value, quant);
            Solve(M, value, quant);
        }

        private static void Swap(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
        }

        /* сортира предметите по себестойност */

        private static void Sort(double[] ratio, double[] value, double[] quant)
        {
            for (int i = 0; i < ratio.Length - 1; i++)
            {
                for (int j = i + 1; j < ratio.Length; j++)
                {
                    if (ratio[j] > ratio[i])
                    {
                        Swap(ref value[i], ref value[j]);
                        Swap(ref quant[i], ref quant[j]);
                        Swap(ref ratio[i], ref ratio[j]);
                    }
                }
            }
        }

        /* намира решението */

        private static void Solve(double m, double[] value, double[] quant)
        {
            int i = 0;
            double t = 0;
            double v = 0;

            while (t + quant[i] <= m)
            {
                /* взима цели предмети, докато може */
                Console.WriteLine("Избира 100% от предмет със стойност {0:F2} и тегло {1:F2}", value[i], quant[i]);
                t += quant[i];
                v += value[i];
                i++;
            }

            Console.WriteLine(
                "Избира се {0:F2}% от предмет със стойност {1:F2} и тегло {2:F2}",    
                ((m - t) / quant[i]) * 100, 
                value[i], 
                quant[i]);

            v += (m - t) * (value[i] / quant[i]);
            Console.WriteLine("Обща получена цена: {0:F2}\n", v);
        }
    }
}