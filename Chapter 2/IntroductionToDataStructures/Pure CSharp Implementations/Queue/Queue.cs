using System;

class QueueExample
{
    const int Max = 10;

    static void Main()
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

class Queue<T>
{
    private const int DefaultCapacity = 4;

    private T[] queue;
    private int front;
    private int rear;

    public int Count { get; private set; }

    public int Capacity
    {
        get { return this.queue.Length; }
    }

    public Queue(int capacity = DefaultCapacity)
    {
        this.queue = new T[capacity];
        this.front = 0;
        this.rear = 0;
        this.Count = 0;
    }

    public void Enqueue(T item)
    {
        if (this.front == this.rear && this.Count != 0) // Проверка за препълване 
        {
            // Препълване - индексите са равни, а опашката не е празна 
            EnsureCapacity();
        }

        this.queue[this.rear] = item;
        this.rear++;

        if (this.rear >= this.queue.Length)
        {
            this.rear = 0;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count <= 0) // Проверка за празна опашка 
        {
            throw new InvalidOperationException("Опашката е празна!");
        }

        T item = this.queue[this.front];
        this.front++;

        if (this.front >= this.queue.Length)
        {
            this.front = 0;
        }

        this.Count--;

        return item;
    }

    public bool IsEmpty()
    {
        return this.Count <= 0;
    }

    private void EnsureCapacity()
    {
        int newCapacity = this.queue.Length * 2;
        int oldCount = this.Count;
        T[] newQueue = new T[newCapacity];

        int i = 0;
        while (this.Count != 0)
        {
            newQueue[i] = this.Dequeue();
            i++;
        }

        this.front = 0;
        this.rear = i;
        this.Count = oldCount;
        this.queue = newQueue;
    }
}