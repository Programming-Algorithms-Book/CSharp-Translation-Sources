namespace Queue
{
    using System;

    public class Queue<T>
    {
        private readonly int max;
        private readonly T[] queue;

        private int front;
        private int rear;
        private bool empty;

        public Queue(int max)
        {
            this.max = max;
            this.queue = new T[this.max];
            this.front = 0;
            this.rear = 0;
            this.empty = true;
        }

        public void Put(T item)
        {
            // Проверка за препълване 
            if (this.front == this.rear && !this.empty)
            {
                // Препълване - индексите са равни, а опашката не е празна 
                throw new InvalidOperationException("Препълване на опашката!");
            }

            this.queue[this.rear] = item;
            this.rear++;

            if (this.rear >= this.max)
            {
                this.rear = 0;
            }

            this.empty = false;
        }

        public T Get()
        {
            // Проверка за празна опашка 
            if (this.empty)
            {
                throw new InvalidOperationException("Опашката е празна!");
            }

            T item = this.queue[this.front];
            this.front++;

            if (this.front >= this.max)
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
}