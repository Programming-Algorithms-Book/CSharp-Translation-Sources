using System;

class GetPowerOfANumber
{
    static void Main()
    {
        Console.Write("Въведете основа x: ");
        double number = double.Parse(Console.ReadLine());
        Console.Write("Въведете стенеп y: ");
        uint power = uint.Parse(Console.ReadLine());
        double result = GetPower(number, power);
        Console.WriteLine("{0} повдигнато на степен {1} e {2}", number, power, result);
    }

    static double GetPower(double number, uint power)
    {
        double result = number;
        for (uint i = 1; i < power; i++)
            result *= number;
        return result;
    }
}
