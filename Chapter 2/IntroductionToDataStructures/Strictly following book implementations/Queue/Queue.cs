using System;

class Program
{
    private const int Max = 10;

    static void Main()
    {
        Queue<int> queue = new Queue<int>(Max);

        for (int i = 0; i < 2 * Max; i++)
        {
            queue.Put(i);
            int itemInFront = queue.Get();
            Console.Write("{0} ", itemInFront);
        }

        // Това ще причини препълване при последното включване
        //for (var i = 0; i < Max + 1; i++)
        //{
        //    queue.Put(i);
        //}

        // Това ще причини грешка при последното изключване, тъй като опашката е празна
        //for (var i = 0; i < Max; i++)
        //{
        //    queue.Put(i);
        //}

        //for (int i = 0; i < Max + 1; i++)
        //{
        //    queue.Get();
        //}
    }
}

public class Queue<T>
{
    private readonly int Max;
    private readonly T[] queue;

    private int front;
    private int rear;
    private bool empty;

    public Queue(int max)
    {
        this.Max = max;
        this.queue = new T[Max];
        this.front = 0;
        this.rear = 0;
        this.empty = true;
    }

    public void Put(T item)
    {
        if (this.front == this.rear && !this.empty) // Проверка за препълване 
        {
            // Препълване - индексите са равни, а опашката не е празна 
            throw new InvalidOperationException("Препълване на опашката!");
        }

        this.queue[this.rear] = item;
        this.rear++;

        if (this.rear >= Max)
        {
            this.rear = 0;
        }

        this.empty = false;
    }

    public T Get()
    {
        if (this.empty) // Проверка за празна опашка 
        {
            throw new InvalidOperationException("Опашката е празна!");
        }

        T item = this.queue[this.front];
        this.front++;

        if (this.front >= Max)
        {
            this.front = 0;
        }

        if (this.front == this.rear)
        {
            this.empty = true;
        }

        return item;
    }
}

