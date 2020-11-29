using System;

namespace Blatt6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Aufgabe2 list = new Aufgabe2();


            //list.Einfuegen(5);
            //list.Einfuegen(20);
            //list.Einfuegen(4);
            //list.Einfuegen(3);
            //list.Einfuegen(30);


            //Console.WriteLine("Linked List before sorting ");
            //list.PrintList(list.head);
            //Console.WriteLine("\nLinked List after sorting");
            //list.QuickSortStart(list.head);
            //list.PrintList(list.head);

            //Aufgabe3 a = Aufgabe3.CreateLottoZahlen(49);
            //Console.WriteLine(a);

            //Aufgabe3.ZahlenZiehen(49, a);

            int[] a = {45, 6, 50, 20, 15, 49, 1, 3, 7};
            //CountSort(a, 50);
            
            Console.WriteLine(string.Join(", ", CountingSort(a)));
        }

        public static void CountSort(int[] a, int k)
        {
            int j = 1; 
            int[] bin = new int[k + 1];

            for (int i = 0; i < a.Length; i++)
            {
                bin[a[i]]++;
            }

            for (int i = 0; i < a.Length; i++)
            {
                while (j < k && bin[j] == 0)
                {
                    j++;
                }
                a[i] = j;
                bin[j]--;
            }
        }

        public static int[] CountingSort(int[] array)
        {
            int[] sortedArray = new int[array.Length];

            // find smallest and largest value
            int minVal = array[0];
            int maxVal = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minVal) minVal = array[i];
                else if (array[i] > maxVal) maxVal = array[i];
            }

            // init array of frequencies
            int[] counts = new int[maxVal - minVal + 1];

            // init the frequencies
            for (int i = 0; i < array.Length; i++)
            {
                counts[array[i] - minVal]++;
            }

            // recalculate
            counts[0]--;
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] = counts[i] + counts[i - 1];
            }

            // Sort the array
            for (int i = array.Length - 1; i >= 0; i--)
            {
                sortedArray[counts[array[i] - minVal]--] = array[i];
            }

            return sortedArray;
        }

    }
}
