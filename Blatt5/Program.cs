using System;
using System.Collections;
using System.Collections.Generic;

namespace Blatt5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 11, 0, 3, 100, 2, 1, 4, 10, 5 };
            //InsertionSort(a, 1, 0, a[1]);

            MergeSort(a, 0, a.Length - 1);
            Console.WriteLine(String.Join(", ", a));

            int s = 10;

            Console.WriteLine($"Is {s} aus a machbar: {Aufgabe4(a, s)}");
        }

        public static void InsertionSort(int[] a, int i, int j, int key)
        {
            if (j >= 0 && a[j] > key)
            {
                a[j + 1] = a[j];
                InsertionSort(a, i, j - 1, key);
            }
            else
            {
                a[j + 1] = key;
                i++;
                if (i < a.Length)
                {
                    key = a[i];
                    InsertionSort(a, i, i -1, key);
                }
            }
        }

        public static void MergeSort(int[] a, int f, int l)
        {
            Stack<Tuple<int, int, int>> stack = new Stack<Tuple<int, int, int>>();

            int f2 = f;
            int l2 = l;

            while (f < l && f2 < l2)
            {
                int m = (f + l + 1) / 2;
                int m2 = (f2 + l2 + 1) / 2;
                stack.Push(new Tuple<int, int, int>(f, l, m));
                stack.Push(new Tuple<int, int, int>(f2, l2, m2));
                l = m - 1;
                f2 = m2;
            }

            for (int i = 0; i < stack.Count; i++)
            {
                var tuple = stack.Pop();
                Console.WriteLine(tuple);
                Merge(a, tuple.Item1, tuple.Item2, tuple.Item3);
            }
        }

        public static void Merge(int[] a, int f, int l, int m)
        {
            int i;
            int n = l - f + 1;
            int a1f = f, a1l = m - 1;
            int a2f = m, a2l = l;
            int[] anew = new int[n];
            for (i = 0; i < n; i++)
            {
                if (a1f <= a1l)
                {
                    if (a2f <= a2l)
                    {
                        if (a[a1f] <= a[a2f]) anew[i] = a[a1f++];
                        else anew[i] = a[a2f++];
                    }
                    else anew[i] = a[a1f++];
                }
                else anew[i] = a[a2f++];
            }
            for (i = 0; i < n; i++) a[f + i] = anew[i];
        }

        public static bool Aufgabe4(int[] a, int s)
        {
            // Use n <= 16 Insertionsort. if partitions > 2*Log n. Otherwise Quicksort. So its always O(n log n)
            Array.Sort(a);

            for (int i = 0; i < a.Length; i++)
            {
                int t = s - a[i];
                if (t > 0)
                {
                    if (t > a[i])
                    {
                        for (int j = i; j < a.Length; j++)
                        {
                            if (a[i] + a[j] == s)
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        for (int j = i; j < 0; j--)
                        {
                            if (a[i] + a[j] == s)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

    }
}
