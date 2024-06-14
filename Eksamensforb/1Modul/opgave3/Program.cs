using System;

class Program 
{
    static void Main(string[] args) 
    {
        Console.WriteLine(Opgave3.Faculty(5)); // Output skal være '120'.
    }
}

class Opgave3 {
    public static int Faculty(int n) {
       // Termineringsregel: 0! = 1
       if (n == 0) 
       {
        return 1;
       }
       //Rekurrensregel: n! = n * (n -1)!
       return n * Faculty(n - 1);
    }
}