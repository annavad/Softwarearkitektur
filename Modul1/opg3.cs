Console.WriteLine(Opgave3.Faculty(5));

class Opgave3 
{
    public static int Faculty(int n)
    {
        int resultat;
        if (n == 0) {
            resultat = 1;
        } else {
            resultat = n * Faculty(n - 1);
        }
        return resultat;
    }
}