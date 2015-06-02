using System;

class Program
{
    static int[,] A = {
        { 0, 1, 0, 0, 0, 0 }, 
        { 1, 0, 1, 0, 0, 1 }, 
        { 0, 1, 0, 0, 1, 0 }, 
        { 0, 0, 0, 0, 0, 1 }, 
        { 0, 0, 1, 0, 0, 0 }, 
        { 0, 1, 0, 1, 0, 0 }
    };
    
    static readonly int rows = A.GetLength(0);

    static void Main()
    {
        Console.WriteLine("Оцветяване на върховете по алгоритъм 1:");
        int[] colors1 = Solve1();
        ShowColor(colors1);
        Console.WriteLine("Оцветяване на върховете по алгоритъм 2:");
        int[] colors2 = Solve2();
        ShowColor(colors2);
    }
    
    /* върховете се разглеждат в произволен, а не сортиран по степента им ред */
    static int[] Solve1()
    {
        int[] colors = new int[rows];
        for (int i = 0; i < rows; i++)
        { /* оцветява i-тия връх с най-малкият възможен цвят */
            
            int c = 0;
            bool flag;
            do {
                c++;
                flag = true;
                for (int j = 0; j < i; j++)
                    if (A[i, j] == 1 && colors[j] == c)
                    {
                        flag = false;
                        break;
                    }
            } while (!flag);
            colors[i] = c;
        }
        return colors;
    }
    
    static int[] Solve2()
    {
        int c = 0, cn = 0;
        int[] colors = new int[rows];
        /* оцветява върхове само с първия цвят, докато е възможно, след това само с
         * втория и т.н., докато всички върхове бъдат оцветени
         */
        while (cn < rows)
        {
            c++;
            for (int i = 0; i < rows; i++)
            {
                if (colors[i] == 0)
                {
                    bool flag = true;
                    for (int j = 0; j < rows; j++)
                        if (A[i, j] == 1 && colors[j] == c)
                        {
                            flag = false;
                            break;
                        }
                    if (flag)
                    {
                        colors[i] = c;
                        cn++;
                    }
                }
            }
        }
        return colors;
    }
    
    static void ShowColor(int[] colors)
    {
        for (int i = 0; i < colors.Length; i++) 
            Console.Write("{0}-{1}; ", i + 1, colors[i]);
        Console.WriteLine();
    }
}
