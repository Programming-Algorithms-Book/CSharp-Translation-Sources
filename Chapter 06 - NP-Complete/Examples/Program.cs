namespace Examples
{
    using System;

    public class Program
    {
        internal static void Main(string[] args)
        {
            for (int x = 3;;)
            {
                for (int a = 1; a <= x; a++)
                {
                    for (int b = 1; b <= x; b++)
                    {
                        for (int c = 1; c <= x; c++)
                        {
                            for (int i = 3; i <= x; i++)
                            {
                                if (Math.Pow(a, i) + Math.Pow(b, i) == Math.Pow(c, i))
                                {
                                    Console.WriteLine("Found");
                                    return;
                                }
                            }
                        }
                    }
                }

                x++;
            }
        }
    }
}