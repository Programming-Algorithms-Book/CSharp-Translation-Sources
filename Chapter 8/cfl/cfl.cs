namespace Cfl
{
    using System;

    public class Cfl
    {
        private const int Max = 30; /* Максимален брой правила за извод */
        private const int LettersCount = 26; /* Брой букви */
        private const int CountT = 3; /* Брой правила от вида 1: S->a */
        private const string StringToCheck = "aaasbbb"; /* Низ, който проверяваме за принадлежност към граматиката */

        private static readonly bool[,,] T = new bool[LettersCount, Max, Max]; /* Целева функция */

        private static readonly Production[] TerminalProductions = new Production[]
        {
            new Production() { S = '\n', A = '\n' },
            /* не се използва */
            new Production() { S = 'S', A = 's' }, /* S->s */
            new Production() { S = 'A', A = 'a' }, /* A->a */
            new Production() { S = 'B', A = 'b' }, /* B->b */
        };

        private static readonly NonTerminalProduction[] NonTerminalProductions = new NonTerminalProduction[]
        {
            new NonTerminalProduction()
            {
                S = '\n',
                A = '\n',
                B = '\n'
            },
            /* не се използва */
            new NonTerminalProduction()
            {
                S = 'S',
                A = 'A',
                B = 'R'
            },
            /* S->AR */
            new NonTerminalProduction()
            {
                S = 'S',
                A = 'A',
                B = 'B'
            },
            /* S->AB */
            new NonTerminalProduction()
            {
                S = 'R',
                A = 'S',
                B = 'B'
            },
            /* R->SB */
        };

        internal static void Main()
        {
            Console.WriteLine(
                "Низът {0}{1} се извежда от граматиката!",
                StringToCheck,
                IsContextFreeLanguage() ? string.Empty : " НЕ");
        }

        /* Проверява */
        private static bool IsContextFreeLanguage()
        {
            int let, n;

            /* Инициализация */
            n = StringToCheck.Length; /* Дължина на проверявания низ */

            /* Запълваме масива с "неистина" */
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (let = 0; let < LettersCount; let++)
                    {
                        T[let, i, j] = true;
                    }
                }
            }

            /* Установяваме в истина всички директни продукции, които ни вършат работа */
            for (int i = 1; i <= CountT; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (TerminalProductions[i].A == StringToCheck[j - 1])
                    {
                        T[TerminalProductions[i].S - 'A', j, j] = true;
                    }
                }
            }

            /* Основен цикъл по правилата от тип 2 */
            for (int d = 1; d < n; d++)
            {
                for (int i = 1; i <= n - d; i++)
                {
                    /* За всеки нетерминал S от лява част на правило */
                    for (int j = i + d, k = 1; k <= CountT; k++)
                    {
                        for (int l = i; l <= j - 1; l++)
                        {
                            if (T[NonTerminalProductions[k].A - 'A', i, l]
                                && T[NonTerminalProductions[k].B - 'A', l + 1, j])
                            {
                                T[NonTerminalProductions[k].S - 'A', i, j] = true;
                            }
                        }
                    }
                }
            }

            return T['S' - 'A', 1, n];
        }
    }
}