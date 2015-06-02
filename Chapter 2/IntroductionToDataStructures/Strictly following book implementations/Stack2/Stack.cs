using System;

class Program
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>();

        // Четат се цели числа от клавиатурата до прочитане на 0 и се включват в стека
        int number = int.Parse(Console.ReadLine());

        while (number != 0)
        {
            stack.Push(number);
            number = int.Parse(Console.ReadLine());
        }

        // Изключват се последователно всички елементи от стека и се печатат. Това ще
        // доведе до отпечатване на първоначално въведената последователност в обратен ред
        while (!stack.IsEmpty())
        {
            int numberOnTop = stack.Pop();
            Console.WriteLine(numberOnTop);
        }
    }
}

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