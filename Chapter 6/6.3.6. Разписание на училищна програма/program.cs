using System;

class program
{
    /* Максимален брой учители */
    const int MAXT = 100;
    /* Максимален брой класове */
    const int MAXC = 100;
    /* Брой учители */
    const uint t = 3;
    /* Брой класове */
    const uint c = 4;
    static uint[,] cl = new uint[,]
    {
        { 5, 5, 5 },
        /* информация за клас 1 */ { 5, 5, 5 },
        { 5, 0, 0 },
        { 0, 0, 5 },
    /* информация за клас C */ };

    const uint MAX_VALUE = 20000;

    static byte[,] usedC = new byte[100, MAXC];
    static uint[] teach = new uint[MAXT];
    static uint minimal;

   static void generate(uint teacher, uint level, uint mX, uint totalHours)
    {
        uint i, j;
        if (totalHours >= minimal)
            return;
        if (teacher == t)
        {
            uint min = MAX_VALUE;
            for (i = 0; i < c; i++)
                for (j = 0; j < t; j++)
                    if (cl[i, j] < min && 0 != cl[i, j])
                        min = cl[i, j];
            if (min == MAX_VALUE)
            {
                if (totalHours < minimal)
                    minimal = totalHours;
            }
            else
            {
                generate(0, level + 1, min, totalHours + min);
            }
            return;
        }
        /* определя клас за учителя teacher, с който той да проведе min часа */
        for (i = 0; i < c; i++)
        {
            if (cl[i, teacher] > 0 && usedC[level, i] == 0)
            {
                cl[i, teacher] -= mX;
                usedC[level, i] = 1;
                generate(teacher + 1, level, mX, totalHours);
                usedC[level, i] = 0;  /* връщане */
                cl[i, teacher] += mX;
            }
        }
        /* Ако не е намерено присвояване за учителя, това означава, че не са му останали
        * часове за преподаване */
        if (i == c) generate(teacher + 1, level, mX, totalHours);
    }
    static void Main(string[] args)
    {
        uint i, j;
        for (i = 0; i < 100; i++)
            for (j = 0; j < c; j++) usedC[i,j] = 0;
        minimal = MAX_VALUE;
        generate(t, 0, 0, 0);
        Console.WriteLine("Минималното разписание е с продължителност {0} часа.", minimal);
    }
    }