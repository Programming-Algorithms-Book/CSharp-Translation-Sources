namespace Stack2
{
    using System;

    public class Stack<T>
    {
        private const int Max = 10;

        private readonly T[] stack;
        private int top;

        public Stack()
        {
            this.stack = new T[Max];
            this.top = 0;
        }

        public void Push(T item)
        {
            if (this.top == Max)
            {
                throw new InvalidOperationException("Препълване на стека!");
            }
            else
            {
                this.stack[this.top] = item;
                this.top++;
            }
        }

        public T Pop()
        {
            if (this.top == 0)
            {
                throw new InvalidOperationException("Стекът е празен!");
            }
            else
            {
                this.top--;
                T item = this.stack[this.top];
                return item;
            }
        }

        public bool IsEmpty()
        {
            if (this.top == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}