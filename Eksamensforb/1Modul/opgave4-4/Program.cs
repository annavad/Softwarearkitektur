using System;

class Program
{
    static void Main(string[] args)
    {
        string s = "EGAKNANAB";
        string resultat = Opgave4.Reverse(s);
        Console.WriteLine($"Reverse(\"{s}\") = \"{resultat}\"");
    }
}

class Opgave4
{
    public static string Reverse(string s)
    {
        // Termineringsregel: Hvis strengen er tom eller har én karakter
        if (s.Length <= 1)
        {
            return s;
        }
        
        // Rekurrensregel: Vend resten af strengen og tilføj den første karakter til sidst
        return s[s.Length - 1] + Reverse(s.Substring(0, s.Length - 1));
    }
}
