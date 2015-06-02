using System;

class cuts
{
    struct Element
    {
        public int Value { get; set; }
        public int Action { get; set; }
    }

    const int MaxSize = 100;
    const int NotCalculated = -1;

    static Element[,] f = new Element[MaxSize, MaxSize];
    static int sizeX, sizeY; /* Размерност на парчето */

    static void Init()
    {
        int x, y;
        /* Входни данни */
        sizeX = 13;
        sizeY = 9;

        /* Инициализация */
        for (x = 1; x <= sizeX; x++)
            for (y = 1; y <= sizeY; y++)
            {
                f[x, y].Value = NotCalculated;
                f[x, y].Action = 0;
            }

        /* Входни данни */
        f[11, 1].Value = 28; 
        f[5, 3].Value = 31;
        f[1, 2].Value = 4; 
        f[2, 1].Value = 2;
        f[3, 1].Value = 7; 
        f[10, 1].Value = 23;
        f[3, 2].Value = 14; 
        f[3, 3].Value = 17;
        f[5, 4].Value = 41; 
        f[5, 7].Value = 96;
    }

    static int Solve(int x, int y)
    {
        int bestAction = 0;
        int i, bestSolution, x2 = x / 2, y2 = y / 2;
        if (f[x, y].Value != NotCalculated) 
            return f[x, y].Value; /* Вече е пресмятана */

        bestSolution = 0;
        if (x > 1)
        {  
            /* Срязваме го хоризонтално и викаме рекурсия за двете части */
            for (i = 1; i <= x2; i++)
                if (Solve(i, y) + Solve(x - i, y) > bestSolution)
                {
                    bestSolution = Solve(i, y) + Solve(x - i, y);
                    bestAction = i;
                }
        }

        if (y > 1)
        {  
            /* Срязваме го вертикално и викаме рекурсия за двете части */
            for (i = 1; i <= y2; i++)
                if (Solve(x, i) + Solve(x, y - i) > bestSolution)
                {
                    bestSolution = Solve(x, i) + Solve(x, y - i);
                    bestAction = -i;
                }
        }

        f[x, y].Value = bestSolution;
        f[x, y].Action = bestAction;
        return bestSolution;
    }

    static void PrintSolution(int x, int y)
    {
        if (x > 0 && y > 0 && f[x, y].Value > 0)
        {
            if (f[x, y].Action > 0)
            {
                PrintSolution(f[x, y].Action, y);
                PrintSolution(x - f[x, y].Action, y);
            }
            else if (f[x, y].Action < 0)
            {
                PrintSolution(x, -f[x, y].Action);
                PrintSolution(x, y - (-f[x, y].Action));
            }
            else
                Console.Write("({0},{1}) --> {2}  ", x, y, f[x, y].Value);
        }
    }

    static void Main()
    {
        Init();
        Console.WriteLine("Максимална цена {0}", Solve(sizeX, sizeY));
        Console.WriteLine("Размери (X,Y)-->Цена");
        PrintSolution(sizeX, sizeY);
        Console.WriteLine();
    }
    
}
