using System;

class longpath
{
    /* Максимален брой върхове в графа */ 
    const int MAXN = 200;
    /* Брой върхове в графа */ 
    const uint n = 6; 
    /* Матрица на съседство на графа */ 
    static int[,] A = new int[,]
    {
        { 0, 10, 0, 5, 0, 0 },
        { 0, 0, 5, 0, 0, 15 },
        { 0, 0, 0, 10, 5, 0 },
        { 0, 10, 0, 0, 10, 0 },
        { 0, 5, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 }
    }; 
 
    static uint[] vertex = new uint[MAXN], 
    savePath = new uint[MAXN]; 
    static int[] used = new int[MAXN]; 
    static int maxLen, tempLen, si, ti; 
 
    static void addVertex(uint i) 
    {
        uint j, k; 
        if (tempLen > maxLen)
        { /* намерили сме по-дълъг път => запазваме го */ 
            maxLen = tempLen; 
            for (j = 0; j <= ti; j++)
                savePath[j] = vertex[j]; 
            si = ti; 
        }
        for (k = 0; k < n; k++)
        { 
            if (used[k]==0)
            { /* ако върхът k не участва в пътя до момента */ 
                /* ако върхът, който добавяме, е съседен на последния от пътя */ 
                if (A[i,k] > 0)
                { 
                    tempLen += A[i,k]; 
                    used[k] = 1;    /* маркираме k като участващ в пътя */ 
                    vertex[ti++] = k;  /* добавяме върха k към пътя */ 
                    addVertex(k); 
                    used[k] = 0;    /* връщане от рекурсията */ 
                    tempLen -= A[i,k];
                    ti--; 
                }
            }
        }
    }

    static void Main(string[] args)
    {
        uint i; 
        maxLen = 0;
        tempLen = 0;
        si = 0;
        ti = 1; 
        for (i = 0; i < n; i++)
            used[i] = 0; 
        for (i = 0; i < n; i++)
        { 
            used[i] = 1;
            vertex[0] = i; 
 
            addVertex(i); 
            used[i] = 0; 
        }
        Console.WriteLine("Най-дългият път е: "); 
        for (i = 0; i < si; i++)
            Console.Write("{0} ", savePath[i] + 1); 
        Console.WriteLine("\nс обща дължина {0}", maxLen);         
    }
}