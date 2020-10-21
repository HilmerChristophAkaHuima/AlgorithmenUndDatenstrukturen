using System;

namespace Blatt2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            Console.WriteLine($"Summe aller Zahlen von 1 bis {n}: {Aufgabe1(n)}");
        }

        public static int Aufgabe1(int n)
        {
            int summe = 0;
            while (n > 0)
            {
                summe += n;
                n--;
            }

            return summe;
        }
    }
}
