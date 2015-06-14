using System;

internal class Program
{
    private const int NO_IND = -1;

    private static int[] x = { 0, 8, 3, 5, 7, 0, 8, 9, 10, 20, 20, 20, 12, 19, 11 }; /* 0-ият не се ползва */
    private static readonly int n = x.Length - 1; /* Брой */

    private static int[] Fmin = new int[n]; /* Целева функция: макс. дължина на редица, завършваща с НАМАЛЯВАНЕ */
    private static int[] Fmin_back = new int[n]; /* Предишен индекс от редицата на целевата функция Fmin */
    private static int[] Fmax = new int[n]; /* Целева функция: макс. дължина на редица, завършваща с НАРАСТВАНЕ */
    private static int[] Fmax_back = new int[n]; /* Предишен индекс от редицата на целевата функция Fmax */

    private static void Main()
    {
        CalculateFMinMax();
        FindSolution();
    }

    private static void CalculateFMinMax()
    {
        int ind, ind2;
        /* Инициализация */
        Fmin[0] = Fmax[0] = 1;
        Fmin_back[0] = Fmax_back[0] = NO_IND;
        /* Последователно пресмятане на двете целеви функции */
        for (ind = 1; ind < n; ind++)
        {
            Fmax_back[ind] = Fmin_back[ind] = NO_IND;
            Fmin[ind] = Fmax[ind] = 0;
            for (ind2 = 0; ind2 < ind; ind2++)
            {
                /* Опит за разширяване на намаляваща редица с нарастващ елемент */
                if (Operation(x[ind2], x[ind]) && Fmin[ind2] > Fmax[ind])
                {
                    Fmax[ind] = Fmin[ind2];
                    Fmax_back[ind] = ind2;
                }
                /* Опит за разширяване на нарастваща редица с намаляващ елемент */
                if (Operation(x[ind], x[ind2]) && Fmax[ind2] > Fmin[ind])
                {
                    Fmin[ind] = Fmax[ind2];
                    Fmin_back[ind] = ind2;
                }
            }
            /* Увеличаване с 1 заради текущия елемент */
            Fmin[ind]++;
            Fmax[ind]++;
        }
    }

    private static bool Operation(int a, int b)
    {
        return a < b;
    }

    private static void FindSolution()
    {
        int ind, bestFminInd, bestFmaxInd;
        /* Намиране (края) на най-дългата редица */
        bestFminInd = bestFmaxInd = 0;
        for (ind = 1; ind < n; ind++)
        {
            if (Fmin[bestFminInd] < Fmin[ind])
            {
                bestFminInd = ind;
            }
            if (Fmax[bestFmaxInd] < Fmax[ind])
            {
                bestFmaxInd = ind;
            }
        }
        /* Маркиране на елементите й */
        if (Fmin[bestFminInd] > Fmax[bestFmaxInd])
        {
            MarkSolutionElements(Fmin, Fmax, Fmin_back, Fmax_back, bestFminInd);
        }
        else
        {
            MarkSolutionElements(Fmax, Fmin, Fmax_back, Fmin_back, bestFmaxInd);
        }
        /* Извеждане на решението на екрана */
        for (ind = 0; ind < n; ind++)
        {
            if (NO_IND == Fmin[ind])
            {
                Console.Write("{0} ", x[ind]);
            }
        }
        Console.WriteLine();
    }

    private static void MarkSolutionElements(
        int[] f1, int[] f2, int[] fInd1, int[] fInd2, int indF)
    {
        if (fInd1[indF] == NO_IND)
        {
            return;
        }
        f1[indF] = f2[indF] = NO_IND;
        MarkSolutionElements(f2, f1, fInd2, fInd1, fInd1[indF]);
    }
}