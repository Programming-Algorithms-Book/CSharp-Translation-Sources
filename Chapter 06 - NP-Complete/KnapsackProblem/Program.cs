namespace KnapsackProblem
{
    using System;

    public class Program
    {
        private const int MaxN = 100;
        private const uint N = 10;
        private const float M = 10.5F;
        private static readonly double[] C = { 10.3, 9.0, 12.0, 8.0, 4.0, 8.4, 9.1, 17.0, 6.0, 9.7 };
        private static readonly double[] ArrayM = { 4.0, 2.6, 3.0, 5.3, 6.4, 2.0, 4.0, 5.1, 3.0, 4.0 };

        private static readonly uint[] Taken = new uint[MaxN];
        private static readonly uint[] SaveTaken = new uint[MaxN];

        private static uint tn, sn;
        private static double maxV, vTemp, tTemp, totalV;

        internal static void Main(string[] args)
        {
            uint i;
            tn = 0;
            maxV = 0;
            totalV = 0;
            for (i = 0; i < N; i++)
            {
                totalV += C[i];
            }

            Generate(0);
            Console.WriteLine("Максимално тегло: {0:F2}\nИзбрани предмети: ", maxV);
            for (i = 0; i < sn; i++)
            {
                Console.Write("{0} ", SaveTaken[i] + 1);
            }

            Console.WriteLine();
        }

        private static void Generate(uint i)
        {
            uint k;
            if (tTemp > M)
            {
                return;
            }

            if (vTemp + totalV < maxV)
            {
                return;
            }

            if (i == N)
            {
                if (vTemp > maxV)
                {
                    /* запазване на оптималното решение */
                    maxV = vTemp;
                    sn = tn;
                    for (k = 0; k < tn; k++)
                    {
                        SaveTaken[k] = Taken[k];
                    }
                }

                return;
            }

            Taken[tn++] = i;
            vTemp += C[i];
            totalV -= C[i];
            tTemp += ArrayM[i];
            Generate(i + 1);
            tn--;
            vTemp -= C[i];
            tTemp -= ArrayM[i];
            Generate(i + 1);
            totalV += C[i];
        }
    }
}