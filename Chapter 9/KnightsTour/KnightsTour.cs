using System;

class Program
{
    const int MAX_MOVES = 8;
    const int n = 12;
    static int[] moveX = { +1, -1, +1, -1, +2, +2, -2, -2 };
    static int[] moveY = { +2, +2, -2, -2, +1, -1, +1, -1 };
        
    static void Main()
    {
        Solve();
    }
    
    static void Solve()
    {
        /* инициализация */
        int[,] a = new int[12, 12];
        a[0, 0] = 1;
        int x = 0;
        int y = 0;
        int p = 1;
    
        /* повтаря "алчната" стъпка, докато попълни цялата дъска */
        while (p < 12 * 12)
        {
            int min = int.MaxValue; 
            int choose = -1;
            for (int i = 0; i < MAX_MOVES; i++)
            {
                int temp = CountMoves(a, x + moveX[i], y + moveY[i]);
                if (temp < min)
                {
                    min = temp;
                    choose = i;
                }
            }
            x += moveX[choose];
            y += moveY[choose];
            a[x, y] = ++p;
        }
    
        /* отпечатва резултата */
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++) Console.Write("{0, 4}", a[i, j]);
            Console.WriteLine();
        }
    }
    
    static int CountMoves(int[,] a, int x, int y)
    {
        int i, number = 0;
        if (x < 0 || y < 0 || x >= n || y >= n || a[x, y] != 0)
            return int.MaxValue;    /* невалиден ход */
        for (i = 0; i < MAX_MOVES; i++)
        {
            int nx = x + moveX[i], ny = y + moveY[i];
            if (nx >= 0 && ny >= 0 && nx < n && ny < n && a[nx, ny] == 0) number++;
        }
        return number;
    }
}


