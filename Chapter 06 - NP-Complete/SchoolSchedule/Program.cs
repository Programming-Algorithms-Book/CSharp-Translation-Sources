namespace SchoolSchedule
{
    using System;

    public class Program
    {
        /* Максимален брой учители */
        private const int MaxT = 100;
        /* Максимален брой класове */
        private const int MaxC = 100;
        /* Брой учители */
        private const uint T = 3;

        private const uint MaxValue = 20000;

        /* Брой класове */
        private const uint C = 4;

        private static readonly uint[,] Cl =
        {
            { 5, 5, 5 },
            /* информация за клас 1 */ { 5, 5, 5 },
            { 5, 0, 0 },
            { 0, 0, 5 },
            /* информация за клас C */
        };

        private static readonly byte[,] UsedC = new byte[100, MaxC];
        private static uint[] teach = new uint[MaxT];
        private static uint minimal;

        internal static void Main(string[] args)
        {
            uint i, j;
            for (i = 0; i < 100; i++)
            {
                for (j = 0; j < C; j++)
                {
                    UsedC[i, j] = 0;
                }
            }

            minimal = MaxValue;
            Generate(T, 0, 0, 0);
            Console.WriteLine("Минималното разписание е с продължителност {0} часа.", minimal);
        }

        private static void Generate(uint teacher, uint level, uint mX, uint totalHours)
        {
            uint i, j;
            if (totalHours >= minimal)
            {
                return;
            }

            if (teacher == T)
            {
                uint min = MaxValue;
                for (i = 0; i < C; i++)
                {
                    for (j = 0; j < T; j++)
                    {
                        if (Cl[i, j] < min && 0 != Cl[i, j])
                        {
                            min = Cl[i, j];
                        }
                    }
                }

                if (min == MaxValue)
                {
                    if (totalHours < minimal)
                    {
                        minimal = totalHours;
                    }
                }
                else
                {
                    Generate(0, level + 1, min, totalHours + min);
                }

                return;
            }

            /* определя клас за учителя teacher, с който той да проведе min часа */
            for (i = 0; i < C; i++)
            {
                if (Cl[i, teacher] > 0 && UsedC[level, i] == 0)
                {
                    Cl[i, teacher] -= mX;
                    UsedC[level, i] = 1;
                    Generate(teacher + 1, level, mX, totalHours);
                    UsedC[level, i] = 0;  /* връщане */
                    Cl[i, teacher] += mX;
                }
            }

            /* Ако не е намерено присвояване за учителя, това означава, че не са му останали
        * часове за преподаване */
            if (i == C)
            {
                Generate(teacher + 1, level, mX, totalHours);
            }
        }
    }
}