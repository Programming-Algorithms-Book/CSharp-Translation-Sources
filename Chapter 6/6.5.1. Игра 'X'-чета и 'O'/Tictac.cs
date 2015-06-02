using System;

class Tictac
{
    /* Стартов играч */
    const int startPlayer = 2;

    /* Стартова конфигурация */
    static char[,] board =
    {
        { '.', '.', 'X' },
        { '.', '.', '.' },
        { 'X', '.', 'O' }
    };

    /* Връща стойност 1, ако конфигурацията е терминална и печели играч 1, стойност
    * 2, ако е терминална и печели играч 2, стойност 3, ако играта е реми, и 0, ако
    * конфигурацията не е терминална.
    */
    static int terminal(char[,] a)
    {
        uint i, j;
        for (i = 0; i < 3; i++)
        {
            /* проверка на вертикалите */
            for (j = 0; j < 3; j++)
                if (a[i, j] != a[i, 0])
                    break;
            if (3 == j && a[i, 0] != '.')
            {
                if (a[i, 0] == 'X')
                    return 1;
                else
                    return 2;
            }
            /* проверка на хоризонталите */
            for (j = 0; j < 3; j++)
                if (a[j, i] != a[0, i])
                    break;
            if (3 == j && a[i, 0] != '.')
            {
                if (a[0, i] == 'X')
                    return 1;
                else
                    return 2;
            }
            /* проверка на диагоналите */
            if (a[0, 0] == a[1, 1] && a[1, 1] == a[2, 2] && a[1, 1] != '.')
                if (a[0, 0] == 'X')
                    return 1;
                else
                    return 2;
            if (a[2, 0] == a[1, 1] && a[1, 1] == a[0, 2] && a[1, 1] != '.')
                if (a[2, 0] == 'X')
                    return 1;
                else
                    return 2;
        }
        /* дали не е реми (дали всички позиции са заети) */
        for (i = 0; i < 3; i++)
            for (j = 0; j < 3; j++)
                if (a[i, j] == '.')
                    return 0;
        return 3;
    }

    /* Връща 1, ако конфигурацията е печеливша за играча player, 2 — ако е губеща и
    * 3, ако е неопределена
    */
    static byte checkPosition(int player, char[,] board)
    {
        uint i, j, result;
        int t = terminal(board);
        if (t != 0)
        {
            if (player == t)
                return 1;
            if (3 == t)
                return 3;
            if (player != t)
                return 2;
        }
        else
        {
            int otherPlayer, playerSign;
            if (player == 1)
            {
                playerSign = 'X';
                otherPlayer = 2;
            }
            else
            {
                playerSign = 'O';
                otherPlayer = 1;
            }

            /* char boardi[3][3]; Ј
            * определя позицията
            */
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (board[i, j] == '.')
                    {
                        board[i, j] = (char)playerSign;
                        result = checkPosition(otherPlayer, board);
                        board[i, j] = '.';
                        if (result == 2)
                            return 1;  /* конфигурацията е губеща за противника, */
                        /* следователно е печеливша за играча player */
                        if (result == 3)
                            return 3;  /* конфигурацията е неопределена */
                    }
                }
            }
            /* ако сме достигнали дотук, значи всички наследници са печеливши конфигурации и
            * следователно тази е губеща за играча player
            */
            return 2;
        }
        return 0;
    }


    static void Main(string[] args)
    {
        Console.WriteLine("{0}", checkPosition(startPlayer, board));
    }
}