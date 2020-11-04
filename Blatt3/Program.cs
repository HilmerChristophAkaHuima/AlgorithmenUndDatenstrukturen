using System;
using System.Collections.Generic;

namespace Blatt3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { -13, 25, 34, 12, -3, 7, -87, 28, -77, 11 };

            int[][] b = { new int[] { -13, 25, 34, 12, -3, 7, -87, 28, -77, 11 }, new int[] { 50, 50, -150, 4, 5, 6, 7, 8, 9, 10 } };
            //Console.WriteLine($"{MaxTeilsum1(a)}");

            //Console.WriteLine($"{MaxTeilsum2dn3(b)}");
            //for (int i = 0; i < 4; i++)
            //{
            //    Console.WriteLine();
            //    for (int j = 0; j < 10; j++)
            //    {
            //        Console.Write($"{Aufgabe4Rekrusiv(i, j, 0)} |");
            //    }
            //}
            //Console.WriteLine($"\n{Aufgabe4Rekrusiv(4, 0, 0)} |");
            //Console.WriteLine($"\n{Aufgabe4Rekrusiv(5, 0, 0)} |");
            //Console.WriteLine($"\n{Aufgabe4Rekrusiv(6, 0, 0)} |");

            Console.WriteLine($"{Aufgabe4Rekrusiv(2, 2, 0)}");
            Aufgabe4Iterativ(2, 2);

        }

        public static int Aufgabe4Rekrusiv(int n, int m, int zahler)
        {
            Console.Write($"{zahler}: N={n} M={m}");
            if (n == 0)
            {
                Console.WriteLine(" m+1");
                return m + 1;
            }

            if (m == 0 && n >= 1)
            {
                Console.WriteLine(" f(n-1, 1)");
                return Aufgabe4Rekrusiv(n - 1, 1, zahler + 1);
            }

            Console.WriteLine(" f(n-1, f(n, m-1))");
            return Aufgabe4Rekrusiv(n - 1, Aufgabe4Rekrusiv(n, m - 1, zahler + 1), zahler + 1);
        }

        public static int Aufgabe4Iterativ(int n, int m)
        {
            Stack<StackInhalt> stapel = new Stack<StackInhalt>();
            //Stack<int> ergStapel = new Stack<int>();
            //int erg = 0;

            stapel.Push(new StackInhalt() { N = n, M = m });
            while (stapel.Count > 0)
            {
                StackInhalt si = stapel.Pop();
                Console.WriteLine($"{si.N} {si.M}");

                if (si.N == 0)
                {
                    if (stapel.Count > 0)
                    {
                        stapel.Push(new StackInhalt(){N = 1, M = si.M + 1});
                    }
                    else
                    {
                        return si.M + 1;
                    }
                }else if (si.M == 0 && si.N >= 1)
                {
                    stapel.Push(new StackInhalt() { N = n - 1, M = 1 });
                }
                else
                {
                    stapel.Push(new StackInhalt() { N = 1, M = m - 1 });
                }
            }

            return m + 1;
        }

        public static int MaxTeilsum1(int[] a)
        {
            int sum, max = int.MinValue;
            int i, j = 0;

            for (i = 0; i < a.Length; i++)
            {
                sum = 0;
                for (j = i; j < a.Length; j++)
                {
                    sum += a[j];
                    if (sum > max)
                    {
                        max = sum;
                        Console.WriteLine($"{i}, {j}");
                    }

                }
            }
            return max;
        }

        public static int MaxTeilsum2dn3(int[][] a)
        {
            int sum = int.MinValue;
            int max = int.MinValue;

            for (int i = 0; i < a.Length * a[0].Length; i++)
            {
                Console.WriteLine($"\n{i}");
                Console.WriteLine("+++++++++++++++++++++");
                sum = 0;

                for (int j = i / (a[0].Length); j < a.Length; j++)
                {
                    if (j == 1)
                    {
                        Console.WriteLine("--------------------");
                    }

                    int k = i;
                    if (i / (a[0].Length) == 1)
                    {
                        k = i - (a[0].Length - 1);
                    }
                    else if (j == 1)
                    {
                        k = 0;
                    }
                    for (; k < a[j].Length; k++)
                    {
                        sum += a[j][k];
                        Console.Write($"{i} {j} {k} {sum}");
                        if (sum > max)
                        {
                            max = sum;
                            Console.Write(" bigger");
                        }

                        Console.WriteLine();
                    }
                }
            }

            return max;
        }

        public static int MaxTeilsum2dn2(int[][] a)
        {
            int i, s, max = int.MinValue;
            int aktSum = 0;
            for (int j = 0; j < a.Length; j++)
            {
                for (i = 0; i < a[j].Length; i++)
                {
                    s = aktSum + a[j][i];
                    if (s > a[j][i]) aktSum = s;
                    else aktSum = a[j][i];
                    if (aktSum > max) max = aktSum;
                }
            }

            return max;
        }

    }

    class StackInhalt
    {
        public int N { get; set; }
        public int M { get; set; }
    }
}
