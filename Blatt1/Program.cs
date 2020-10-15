using System;
using System.Collections.Generic;
using System.Text;

namespace Blatt1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int initGroesse = 1434;
            //initGroesse = Aufgabe3Matrix.LaufzeitErmittlungAdd(1, initGroesse);
            //Console.WriteLine($"Größe bei 1 min: {initGroesse}");
            //initGroesse = Aufgabe3Matrix.LaufzeitErmittlungAdd(2, initGroesse);
            //Console.WriteLine($"Größe bei 2 min: {initGroesse}");
            //initGroesse = Aufgabe3Matrix.LaufzeitErmittlungAdd(5, initGroesse);
            //Console.WriteLine($"Größe bei 5 min: {initGroesse}");
            //initGroesse = Aufgabe3Matrix.LaufzeitErmittlungAdd(10, initGroesse);
            //Console.WriteLine($"Größe bei 10 min: {initGroesse}");

            //initGroesse = 1434;
            //initGroesse = Aufgabe3Matrix.LaufzeitErmittlungMult(1, initGroesse);
            //Console.WriteLine($"Größe bei 1 min: {initGroesse}");
            //initGroesse = Aufgabe3Matrix.LaufzeitErmittlungMult(2, initGroesse);
            //Console.WriteLine($"Größe bei 2 min: {initGroesse}");
            //initGroesse = Aufgabe3Matrix.LaufzeitErmittlungMult(5, initGroesse);
            //Console.WriteLine($"Größe bei 5 min: {initGroesse}");
            //initGroesse = Aufgabe3Matrix.LaufzeitErmittlungMult(10, initGroesse);
            //Console.WriteLine($"Größe bei 10 min: {initGroesse}");

            //SiebDesEratosthenes(100000);

            var a = 12;
            var b = 16;
            Console.WriteLine($"Für a = {a} und b = {b}");
            Console.WriteLine($"ggT: {GroessterGemeinsamerTeiler(a, b)}");
            Console.WriteLine($"kgV: {KleinsterGemeinsamesVielfacheKompliziert(a, b)}");
            Console.WriteLine($"ggT Rekursiv: {GroessterGemeinsamerTeilerRekursive(a, b)}");
            Console.WriteLine($"kgV Rekursiv: {KleinsterGemeinsamesVielfacheKompliziertRekursiv(a, b)}");
        }

        /*
         * Euklidische Algorithmus
         */
        public static int GroessterGemeinsamerTeiler(int a, int b)
        {
            while (b > 0)
            {
                var rest = a % b;
                a = b;
                b = rest;
            }
            return a;
        }

        public static int GroessterGemeinsamerTeilerRekursive(int a, int b)
        {
            if (b <= 0)
            {
                return a;
            }
            var rest = a % b;
            a = b;
            b = rest;
            return GroessterGemeinsamerTeilerRekursive(a, b);
        }

        /*
         * z.B. wenn a und b Teilerfremd sind ist ggT 1 und dadurch ist das kgV das Produkt von a und b.
         */
        public static int KleinsterGemeinsamesVielfache(int a, int b)
        {
            return a * b / GroessterGemeinsamerTeiler(a, b);
        }

        public static int KleinsterGemeinsamesVielfacheKompliziert(int a, int b)
        {
            int kleiner;
            int groesser;
            if (a > b)
            {
                kleiner = b;
                groesser = a;
            }
            else
            {
                kleiner = a;
                groesser = b;
            }

            for (int i = kleiner; i < a * b; i += kleiner)
            {
                if (i % groesser == 0 && i != groesser)
                {
                    return i;
                }
            }

            return a * b;
        }

        public static int KleinsterGemeinsamesVielfacheKompliziertRekursiv(int a, int b)
        {
            int kleiner;
            int groesser;
            if (a > b)
            {
                kleiner = b;
                groesser = a;
            }
            else
            {
                kleiner = a;
                groesser = b;
            }

            return KleinsterGemeinsamesVielfacheKompliziertRekursiv(a, b, groesser, kleiner);
        }

        public static int KleinsterGemeinsamesVielfacheKompliziertRekursiv(int a, int  b, int groesser, int kleiner)
        {
            if (kleiner % groesser == 0 && kleiner != groesser)
            {
                return kleiner;
            }

            if (kleiner >= a * b)
            {
                return kleiner * groesser;
            }

            return KleinsterGemeinsamesVielfacheKompliziertRekursiv(a, b, groesser, kleiner *2);
        }

        public static void DruckTabelle(List<int> tabelle, int k)
        {
            for (int i = 1; i <= k; i++)
            {
                if (tabelle.Contains(i))
                {
                    Console.Write($"{i} \t");
                }
                else
                {
                    Console.Write("\t");
                }

                Console.Write('|');
                if (i % 10 == 0)
                {
                    Console.WriteLine();
                    for (int j = 0; j < 81; j++)
                    {
                        Console.Write('-');
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void SiebDesEratosthenes(int k)
        {
            List<int> zahlen = new List<int>();
            for (int i = 2; i <= k; i++)
            {
                zahlen.Add(i);
            }

            DruckTabelle(zahlen, k);

            for (int i = 2; i <= k; i++)
            {
                if (zahlen.Contains(i))
                {
                    for (int j = i * 2; j <= k; j += i)
                    {
                        zahlen.Remove(j);
                    }

                }
            }

            Console.WriteLine();
            DruckTabelle(zahlen, k);
        }

        public static int Fibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n >= 3)
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }

            return 1;
        }
    }
}
