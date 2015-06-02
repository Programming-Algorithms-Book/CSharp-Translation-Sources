using System;

public class Class1
{
    static int Main()
    {         
        for (int x = 3;;)
        { 
            for (int a = 1; a <= x; a++) 
                for (int b = 1; b <= x; b++) 
                    for (int c = 1; c <= x; c++) 
                        for (int i = 3; i <= x; i++) 
                            if (Math.Pow(a, i) + Math.Pow(b, i) == Math.Pow(c, i)) 
                                Environment.Exit(0); 
            x++; 
        }
        return 0; 
    }
}