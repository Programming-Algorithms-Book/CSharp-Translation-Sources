namespace JaggedSequence
{
    using System;

    public class Program
    {
        private const int NoInd = -1;

        private static readonly int[] X = { 0, 8, 3, 5, 7, 0, 8, 9, 10, 20, 20, 20, 12, 19, 11 }; /* 0-ият не се ползва */
        private static readonly int N = X.Length - 1; /* Брой */

        private static readonly int[] Fmin = new int[N]; /* Целева функция: макс. дължина на редица, завършваща с НАМАЛЯВАНЕ */
        private static readonly int[] FminBack = new int[N]; /* Предишен индекс от редицата на целевата функция Fmin */
        private static readonly int[] Fmax = new int[N]; /* Целева функция: макс. дължина на редица, завършваща с НАРАСТВАНЕ */
        private static readonly int[] FmaxBack = new int[N]; /* Предишен индекс от редицата на целевата функция Fmax */

        internal static void Main()
        {
            CalculateFMinMax();
            FindSolution();
        }

        private static void CalculateFMinMax()
        {
            int ind, ind2;
            /* Инициализация */
            Fmin[0] = Fmax[0] = 1;
            FminBack[0] = FmaxBack[0] = NoInd;
            /* Последователно пресмятане на двете целеви функции */
            for (ind = 1; ind < N; ind++)
            {
                FmaxBack[ind] = FminBack[ind] = NoInd;
                Fmin[ind] = Fmax[ind] = 0;
                for (ind2 = 0; ind2 < ind; ind2++)
                {
                    /* Опит за разширяване на намаляваща редица с нарастващ елемент */
                    if (Operation(X[ind2], X[ind]) && Fmin[ind2] > Fmax[ind])
                    {
                        Fmax[ind] = Fmin[ind2];
                        FmaxBack[ind] = ind2;
                    }

                    /* Опит за разширяване на нарастваща редица с намаляващ елемент */
                    if (Operation(X[ind], X[ind2]) && Fmax[ind2] > Fmin[ind])
                    {
                        Fmin[ind] = Fmax[ind2];
                        FminBack[ind] = ind2;
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
            for (ind = 1; ind < N; ind++)
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
                MarkSolutionElements(Fmin, Fmax, FminBack, FmaxBack, bestFminInd);
            }
            else
            {
                MarkSolutionElements(Fmax, Fmin, FmaxBack, FminBack, bestFmaxInd);
            }

            /* Извеждане на решението на екрана */
            for (ind = 0; ind < N; ind++)
            {
                if (NoInd == Fmin[ind])
                {
                    Console.Write("{0} ", X[ind]);
                }
            }

            Console.WriteLine();
        }

        private static void MarkSolutionElements(
            int[] f1, int[] f2, int[] indF1, int[] indF2, int indF)
        {
            if (indF1[indF] == NoInd)
            {
                return;
            }

            f1[indF] = f2[indF] = NoInd;
            MarkSolutionElements(f2, f1, indF2, indF1, indF1[indF]);
        }
    }
}