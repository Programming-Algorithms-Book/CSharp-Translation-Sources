namespace Queue
{
    using System;

    public class QueueExample
    {
        private const int Max = 10;

        internal static void Main()
        {
            Queue<int> queue = new Queue<int>(Max);

            for (int i = 0; i < 2 * Max; i++)
            {
                queue.Enqueue(i);
                int itemInFront = queue.Dequeue();
                Console.Write("{0} ", itemInFront);
            }

            Console.WriteLine();

            // Това ще причини препълване и увеличаване на капацитета при последното включване
            for (var i = 0; i < Max + 1; i++)
            {
                queue.Enqueue(i);
            }

            while (queue.Count > 0)
            {
                int itemInFront = queue.Dequeue();
                Console.Write("{0} ", itemInFront);
            }

            Console.WriteLine();

            // Това ще причини грешка при последното изключване, тъй като опашката е празна
            try
            {
                queue.Dequeue();
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }
    }
}