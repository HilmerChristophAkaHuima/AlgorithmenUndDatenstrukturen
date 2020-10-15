using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Blatt1
{
    public class Aufgabe3Matrix
    {
        public int M { get; private set; }
        public int N { get; private set; }
        public int[,] Matrix { get; set; }

        public TimeSpan Laufzeit { get; set; }
        public int Schritte { get; set; }

        public Aufgabe3Matrix(int m, int n)
        {
            M = m;
            N = n;
            Matrix = new int[m, n];
        }

        public void Init()
        {
            Matrix = new int[M, N];
        }

        public void Print()
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"{Matrix[i, j]} \t");

                    if (j < N-1)
                    {
                        Console.Write('|');
                    }
                }

                Console.WriteLine();
                for (int j = 0; j < 8 * N; j++)
                {
                    Console.Write('-');
                }
                Console.WriteLine();

            }
        }

        public void RandomFill()
        {
            Random rnd = new Random();
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Matrix[i, j] = rnd.Next(100);
                }
            }
        }

        public Aufgabe3Matrix Add(Aufgabe3Matrix b)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            Schritte = 0;
            if (b.M != M || b.N != N)
            {
                throw new Exception("Kann nicht addiert werden.");
            }
            Aufgabe3Matrix erg = new Aufgabe3Matrix(M, N);
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Schritte++;
                    erg.Matrix[i, j] = Matrix[i, j] + b.Matrix[i, j];
                }
            }
            s.Stop();
            Laufzeit = s.Elapsed;
            b.Laufzeit = s.Elapsed;
            b.Schritte = Schritte;

            return erg;
        }

        public Aufgabe3Matrix Mult(Aufgabe3Matrix b)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            Schritte = 0;
            if (N != b.M)
            {
                throw new Exception("Kann nicht Multipliziert werden.");
            }
            Aufgabe3Matrix erg = new Aufgabe3Matrix(M, b.N);
            for (int i = 0; i < b.N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        Schritte++;
                        erg.Matrix[j, i] += Matrix[j, k] * b.Matrix[k, i];
                    }
                }
            }
            s.Stop();
            Laufzeit = s.Elapsed;
            b.Laufzeit = s.Elapsed;
            b.Schritte = Schritte;

            return erg;
        }

        public static int LaufzeitErmittlungAdd(int minuten, int initGroesse)
        {
            int intervall = 1000;
            Aufgabe3Matrix a;
            Aufgabe3Matrix b;

            do
            {
                a = new Aufgabe3Matrix(initGroesse, initGroesse);
                a.RandomFill();

                b = new Aufgabe3Matrix(initGroesse, initGroesse);
                b.RandomFill();

                a.Add(b);

                Console.WriteLine($"Akt. Größe: {initGroesse} und Laufzeit: {a.Laufzeit}");
                if (a.Laufzeit.TotalMilliseconds - minuten * 60 * 1000 > 1000)
                {
                    intervall /= 2;
                    initGroesse = initGroesse - intervall;
                }
                else if (a.Laufzeit.TotalMilliseconds - minuten * 60 * 1000 < 500)
                {
                    intervall *= 2;
                    initGroesse = initGroesse + intervall;
                }
                Console.WriteLine($"Akt. Größe: {initGroesse}");


            } while ((a.Laufzeit.TotalMilliseconds - minuten * 60 * 1000 > 1000) || (a.Laufzeit.TotalMilliseconds - minuten * 60 * 1000 < 500));
            
            return initGroesse;
        }

        public static int LaufzeitErmittlungMult(int minuten, int initGroesse)
        {
            int intervall = 100;
            Aufgabe3Matrix a;
            Aufgabe3Matrix b;

            do
            {
                a = new Aufgabe3Matrix(initGroesse, initGroesse);
                a.RandomFill();

                b = new Aufgabe3Matrix(initGroesse, initGroesse);
                b.RandomFill();

                a.Mult(b);

                Console.WriteLine($"Akt. Größe: {initGroesse} und Laufzeit: {a.Laufzeit}");
                if (a.Laufzeit.TotalMilliseconds - minuten * 60 * 1000 > 1000)
                {
                    intervall /= 2;
                    initGroesse = initGroesse - intervall;
                }
                else if (a.Laufzeit.TotalMilliseconds - minuten * 60 * 1000 < 0)
                {
                    intervall *= 2;
                    initGroesse = initGroesse + intervall;
                }
                Console.WriteLine($"Akt. Größe: {initGroesse}");


            } while ((a.Laufzeit.TotalMilliseconds - minuten * 60 * 1000 > 1000) || (a.Laufzeit.TotalMilliseconds - minuten * 60 * 1000 < 0));

            return initGroesse;
        }

    }
}
