using System;

namespace Blatt4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = {34, 45, 12, 34, 23, 18, 38, 17, 43, 51};
            Console.WriteLine("[{0}]", string.Join(", ", a));

            //InsertionSort(a);
            //Console.WriteLine("[{0}]", string.Join(", ", a));
            //InsertionSortReverse(a);
            //Console.WriteLine("[{0}]", string.Join(", ", a));

            //BubbleSortMaxBubble(a);
            //Console.WriteLine("[{0}]", string.Join(", ", a));

            //SelectionSortMax(a);
            //Console.WriteLine("[{0}]", string.Join(", ", a));

            Quicksort(a, 0, a.Length-1);
            Console.WriteLine("[{0}]", string.Join(", ", a));
        }

        public static void InsertionSort(int[] a)
        {
            int key;

            for (int j = 1; j < a.Length; j++)
            {
                key = a[j];
                int i = j - 1;
                while (i >= 0 && a[i] > key)
                {
                    a[i + 1] = a[i];
                    i = i - 1;
                }
                a[i + 1] = key;
            }
        }

        public static void InsertionSortReverse(int[] a)
        {
            int key;

            for (int j = 1; j < a.Length; j++)
            {
                key = a[j];
                int i = j - 1;
                while (i >= 0 && a[i] < key)
                {
                    a[i + 1] = a[i];
                    i = i - 1;
                }
                a[i + 1] = key;
            }
        }

        public static void BubbleSort(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = a.Length - 2; j >= i; j--)
                {
                    if (a[j] > a[j + 1])
                    {
                        int h = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = h;
                    }
                }
            }
        }

        public static void BubbleSortMaxBubble(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j =  0; j < a.Length-i; j++)
                {
                    if (j > 0 && a[j] < a[j - 1])
                    {
                        Console.WriteLine($"{a[j]} | {a[j-1]}");
                        int h = a[j];
                        a[j] = a[j - 1];
                        a[j - 1] = h;
                    }
                }
            }
        }

        public static void SelectionSort(int[] a)
        {
            int min;
            for (int i = 0; i < a.Length; i++)
            {
                min = i;
                for (int j = i; j < a.Length; j++)
                {
                    if (a[j] < a[min]) min = j;
                }

                int h = a[i];
                a[i] = a[min];
                a[min] = h;
            }
        }

        public static void SelectionSortMax(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int max = a.Length - 1 - i;
                for (int j = max; j >= 0; j--)
                {
                    if (a[j] > a[max]) max = j;
                }

                int h = a[a.Length - 1 - i];
                a[a.Length - 1 - i] = a[max];
                a[max] = h;
            }
        }

        public static void Quicksort(int[] a, int f, int l)
        {
            int part = new Random().Next(f<l?f:l, f > l ? f : l);
            if (f < l)
            {
                Console.WriteLine($"{f} -> {l}");
                Console.WriteLine("[{0}]", string.Join(", ", a));
                PreparePartition(a, f, l, ref part);
                Quicksort(a, f, part - 1);
                Quicksort(a, part + 1, l);
            }
        }

        private static void PreparePartition(int[] a, int f, int l,ref int p)
        {
            int pivot = a[f];

            p = f - 1;
            for (int i = f; i <= l; i++)
            {
                if (a[i] <= pivot)
                {
                    p++;
                    swap(ref a[i], ref a[p]);
                }
            }

            // Pivot an die
            // richtige Stelle
            swap(ref a[f], ref a[p]);
        }

        private static void swap(ref int a,ref int b)
        {
            Console.WriteLine($"{a} <-> {b}");
            int h = b;
            b = a;
            a = h;
        }

        public int[,] multipliziern(int[,] a, int[,] b)
        {
            int[,] erg = new int[a.Length, a.Length];

            if (a.Length == 1)
            {
                erg[0,0] = a[0,0] * b[0,0];
            }
            else
            {
                int[,] A11 = split(a, 0, 0);
                int[,] A12 = split(a, 0, a.Length / 2);
                int[,] A21 = split(a, a.Length / 2, 0);
                int[,] A22 = split(a, a.Length / 2, a.Length / 2);

                int[,] B11 = split(b, 0, 0);
                int[,] B12 = split(b, 0, a.Length / 2);
                int[,] B21 = split(b, a.Length, 0);
                int[,] B22 = split(b, a.Length / 2, a.Length);

                int[,] H1 = multipliziern(add(A11, A22), add(B11, B22));
                int[,] H2 = multipliziern(add(A21, A22), B11);
                int[,] H3 = multipliziern(A11, sub(B12, B22));
                int[,] H4 = multipliziern(A22, sub(B21, B11));
                int[,] H5 = multipliziern(add(A11, A12), B22);
                int[,] H6 = multipliziern(sub(A21, A12), add(B11, B12));
                int[,] H7 = multipliziern(sub(A12, A22), add(B21, B22));

                int[,] C11 = add(sub(add(H1, H4), H5), H7);
                int[,] C12 = add(H3, H5);
                int[,] C21 = add(H2, H4);
                int[,] C22 = add(sub(add(H1, H3), H2), H6);

                join(C11, erg, 0, 0);
                join(C12, erg, 0, a.Length /2);
                join(C21, erg, a.Length /2, 0);
                join(C22, erg, a.Length /2, a.Length /2);
            }

            return erg;
        }

        public int[,] split(int[,] a, int x, int y)
        {
            int[,] erg = new int[a.Length /2, a.Length / 2];

            for (int i = x; i < x + (a.Length / 2); i++)
            {
                for (int j = y; j < y + (a.Length/2); j++)
                {
                    erg[i-x,j-y] = a[i,j];
                }
            }

            return erg;
        }

        public void join(int[,] a, int[,] b, int x, int y)
        {
            for (int i = x; i < x + a.Length; i++)
            {
                for (int j = y; j < y + a.GetLength(0); j++)
                {
                    b[i,j] = a[i - x, j - y];
                }
            }
        }

        public int[,] add(int[,] a, int[,] b)
        {
            int[,] erg = new int[a.Length, a.GetLength(0)];
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    erg[i, j] = a[i, j] + b[i, j];
                }
            }

            return erg;
        }

        public int[,] sub(int[,] a, int[,] b)
        {
            int[,] erg = new int[a.Length, a.GetLength(0)];
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    erg[i, j] = a[i, j] - b[i, j];
                }
            }

            return erg;
        }

        public void TestSortAlgo()
        {
            Random r = new Random();
            int zeit = 0;
            int anzahl = 0;

            for (int i = 0; zeit < 1000*60; i++)
            {
                for (anzahl = 0; zeit < 1000 * 60; anzahl++)
                {
                    
                }
            }
        }

    }
}
