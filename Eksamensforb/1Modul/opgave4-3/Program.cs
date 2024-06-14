using System;

class Program
{
    static void Main(string[] args)
    {
        int a = 5;
        int b = 4;
        int resultat = Opgave4.Multiply(a, b);
        Console.WriteLine($"{a} * {b} = {resultat}");
    }
}

class Opgave4
{
    public static int Multiply(int a, int b)
    {
        // Termineringsregel: 0 * b = 0
        if (a == 0)
        {
            return 0;
        }
        // Termineringsregel: 1 * b = b
        if (a == 1)
        {
            return b;
        }
        // Rekurrensregel: a * b = (a - 1) * b + b
        return Multiply(a - 1, b) + b;
    }
}
