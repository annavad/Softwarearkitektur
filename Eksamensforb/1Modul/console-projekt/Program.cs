using System;

public class trekant
{
  public static int areal(int bredde) {
    int resultat;
    if (bredde == 1) {
      resultat = 1;
        } else {
            resultat = bredde + areal(bredde - 1);
        }
            return resultat;
    }
  
}

class Program
{ 
    static void Main(string[] args)
    {
        int bredde = 5;
        int resultat = trekant.areal(bredde);
        Console.WriteLine($"Arealet af trekanten med bredde {bredde} er {resultat}");
    }
}