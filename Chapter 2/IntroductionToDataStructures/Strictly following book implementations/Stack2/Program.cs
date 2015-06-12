namespace Stack2
{
    using System;

    public class Program
    {
        internal static void Main()
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
}