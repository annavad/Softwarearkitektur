using System;

class Program
{
    static void Main(string[] args)
    {
        int n = 5;
        int p = 4;
        int resultat = Opgave4.Power(n, p);
        Console.WriteLine($"{n} opløftet til {p} er {resultat}");
    }
}

class Opgave4
{
    public static int Power(int n, int p)
    {
        // Termineringsregel: n^0 = 1
        if (p == 0)
        {
            return 1;
        }

        // Rekurrensregel: n^p = n * n^(p-1)
        return n * Power(n, p - 1);
    }
}

