namespace Queue
{
    using System;

    public class Program
    {
        private const int Max = 10;

        internal static void Main()
        {
            Queue<int> queue = new Queue<int>(Max);

            for (int i = 0; i < 2 * Max; i++)
            {
                queue.Put(i);
                int itemInFront = queue.Get();
                Console.Write("{0} ", itemInFront);
            }

            //// Това ще причини препълване при последното включване
            ////for (var i = 0; i < Max + 1; i++)
            ////{
            ////    queue.Put(i);
            ////}

            //// Това ще причини грешка при последното изключване, тъй като опашката е празна
            ////for (var i = 0; i < Max; i++)
            ////{
            ////    queue.Put(i);
            ////}

            ////for (int i = 0; i < Max + 1; i++)
            ////{
            ////    queue.Get();
            ////}
        }
    }
}