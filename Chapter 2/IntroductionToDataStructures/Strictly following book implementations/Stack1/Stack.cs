using System;

class Program
{
    static void Main()
    {
    }
}

public class Stack<T>
{
    private readonly T[] stack;
    private int top;

    public Stack()
    {
        this.stack = new T[10];
        this.top = 0;
    }

    public void Push(T item)
    {
        this.stack[this.top] = item;
        this.top++;
    }

    public T Pop()
    {
        this.top--;
        T item = this.stack[this.top];
        return item;
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