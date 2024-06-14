using System;

class Program
{
    static void Main(string[] args)
    {
        int a = 56;
        int b = 98;
        int resultat = Opgave4.SFD(a, b);
        Console.WriteLine($"Største fælles divisor af {a} og {b} er {resultat}");
    }
}

class Opgave4
{
    public static int SFD(int a, int b)
    {
        if (b == 0)
        {
            return a;
        }
        return SFD(b, a % b);
    }
}
