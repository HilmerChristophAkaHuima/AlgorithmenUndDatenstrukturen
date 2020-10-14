using System;
using System.Collections.Generic;
using System.Text;

namespace Blatt1
{
    class Program
    {
        static void Main(string[] args)
        {
            int initGroesse = 10000;
            initGroesse = Aufgabe3Matrix.LaufzeitErmittlungAdd(1, initGroesse);
            Console.WriteLine($"Größe bei 1 min: {initGroesse}");
            initGroesse = Aufgabe3Matrix.LaufzeitErmittlungAdd(2, initGroesse);
            Console.WriteLine($"Größe bei 2 min: {initGroesse}");
            initGroesse = Aufgabe3Matrix.LaufzeitErmittlungAdd(5, initGroesse);
            Console.WriteLine($"Größe bei 5 min: {initGroesse}");
            initGroesse = Aufgabe3Matrix.LaufzeitErmittlungAdd(10, initGroesse);
            Console.WriteLine($"Größe bei 10 min: {initGroesse}");

            Aufgabe3Matrix a = new Aufgabe3Matrix(1000, 1000);
            a.RandomFill();
            //a.Print();

            Console.WriteLine();
            Aufgabe3Matrix b = new Aufgabe3Matrix(1000, 1000);
            b.RandomFill();
            //b.Print();

            Console.WriteLine();
            Aufgabe3Matrix c = a.Add(b);
            //c.Print();

            //Console.WriteLine();
            //Aufgabe3Matrix d = a.Mult(b);
            //d.Print();

            //Primzahlen(100);

            //var a = 800000000;
            //var b = 400000000;
            //Console.WriteLine($"Für a = {a} und b = {b}");
            //Console.WriteLine($"ggT: {GroessterGemeinsamerTeiler(a, b)}");
            //Console.WriteLine($"kgV: {KleinsterGemeinsamesVielfache(a, b)}");
            //Console.WriteLine($"ggT Rekursive: {GroessterGemeinsamerTeilerRekursive(a, b)}");
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

        public static void Primzahlen(int k)
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
                    for (int j = zahlen.FindIndex((x) => x == i)+1; j < zahlen.Count; j++)
                    {
                        if (zahlen[j] % i == 0)
                        {
                            zahlen.RemoveAt(j);
                        }
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
