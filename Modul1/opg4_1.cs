Console.WriteLine(Opgave4_1.sfd(5, 30));

class Opgave4_1
{
    public static int sfd(int a, int b)
    {
        if (b <= a && a % b == 0)
        {
          return b;  
        }
        else
        {
            if (a < b)
            {
                return sfd(b, a);
            }
            else
            {
                return sfd(b, a % b);
            }
        }
    }
}