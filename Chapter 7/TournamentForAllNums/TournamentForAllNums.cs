using System;

class TournamentForAllNums
{
    private const int MaxMatrixSize = 100;

    static void CopyMatrix(int[,] matrix, int stX, int stY, int count, int add)
    {
        for (int i = 0; i < count; i++)
            for (int j = 0; j < count; j++)
                matrix[i + stX, j + stY] = matrix[i + 1, j + 1] + add;
    }

    static void FindSolution(int[,] matrix, int n) /* Построява таблицата */
    {
        int i;
        if (n % 2 == 0) /* Ако n е четно, задачата се свеждаме към n-1 */
            n--;

        /* Попълва се таблицата за n - тук е гарантирано нечетно. */
        for (i = 0; i < n * (n + 1); i++)
            matrix[i % (n + 1), i / (n + 1)] = i % n + 1;

        /* Възстановява се стойността на n */
        if (n % 2 == 1) n++;

        for (i = 0; i < n; i++)
        {
            if (n % 2 == 0)     /* Запълват се последният стълб и ред при четно n */
                matrix[i, n - 1] = matrix[n - 1, i] = matrix[i, i];
            matrix[i, i] = 0;        /* Запълва се с 0 главният диагонал */
        }
    }

    static void Print(int[,] m, int n)        /* Извежда резултата */
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write("{0} ", m[i, j]);
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int numberOfTeams = 4;
        int[,] matrix = new int[MaxMatrixSize, MaxMatrixSize];
        FindSolution(matrix, numberOfTeams);
        Print(matrix, numberOfTeams);
    }
}