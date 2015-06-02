using System;

class Program
{
    class Order
    {
        public int Left { get; set; }
        public int Right { get; set; }
    } 
    
    static int[] r = { 12, 13, 35, 3, 34, 2, 21, 10, 21, 6 }; /* Размерности на матриците */
    static readonly int n = r.Length - 1;            /* Брой матрици */
    static int[,] m = new int[n+1, n+1];             /* Таблица - целева функция */
    static Order[] order = new Order[(n+1) * (n+1)]; /* Ред на умножение на матриците */
    static int cnt;                                  /* Брой действия за пресмятането */
    
    static void Main()
    {
        Solve();
        cnt = 0;
        BuildOrder(1, n);
        Console.WriteLine("Минималният брой умножения е: {0}", m[1, n]);
        PrintMatrix();
        Console.WriteLine();
        PrintMultiplyPlan();
        Console.WriteLine();
        Console.Write("Ред на умножение на матриците: ");
        GetOrder(1, n);
    }
    
    /* Формира таблица, съдържаща минималния брой умножения, необходими за
     * умножението на всяка двойка матрици, както и индексът, за който се постига */
    static void Solve()
    {
        /* Инициализация */
        for (int i = 0; i < order.Length; ++i)
            order[i] = new Order();
        for (int i = 1; i <= n; i++)
            m[i, i] = 0; 
        /* Основен цикъл */
        for (int j = 1; j <= n; j++)
        {                        
            for (int i = 1; i <= n - j; i++)
            {
                m[i, i + j] = int.MaxValue;
                for (int k = i; k < i + j; k++)
                {
                    int t = m[i, k] + m[k + 1, i + j] + r[i-1] * r[k] * r[i + j];
                    /* Подобряване на текущото решение */
                    if (t < m[i, i + j])
                    {                    
                        m[i, i + j] = t;
                        m[i + j, i] = k;
                    }
                }
            }
        }
    }
    
    static int BuildOrder(int ll, int rr) /* Формира алгоритъм за умножение */
    {
        int ret = cnt++;
        if (ll < rr)
        {
            order[ret].Left = BuildOrder(ll, m[rr, ll]);
            order[ret].Right = BuildOrder(m[rr, ll] + 1, rr);
        }
        else 
        {
            order[ret].Left = ll;
            order[ret].Right = rr;
        }
        return ret;
    }
    
    static void PrintMatrix() /* Извежда матрицата на минимумите на екрана */
    {
        Console.WriteLine("Матрица на минимумите:");
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
                Console.Write("{0, 8}", m[i, j]);
            Console.WriteLine();
        }
    }
    
    static void PrintMultiplyPlan() /* Извежда план за умножение на матриците */
    {
        Console.WriteLine("План за умножение на матриците:");
        for (int i = 0; i < cnt; i++)
        {
            if (order[i].Left == order[i].Right)
                Console.WriteLine("L[{0}] = M{1}", i, order[i].Left);
            else
                Console.WriteLine("L[{0}] = L[{1}] * L[{2}]", i, order[i].Left, order[i].Right);
        }
    }
    
    static void GetOrder(int ll, int rr) /* Изразява реда на умножение с помощта на скоби */
    {
        if (ll == rr)
            Console.Write("M{0}", ll);
        else 
        {
            Console.Write("(");
            GetOrder(ll, m[rr, ll]);
            Console.Write("*");
            GetOrder(m[rr, ll] + 1, rr);
            Console.Write(")");
        }
    }
}