using System;
using System.Collections.Generic;
using System.Text;

namespace Blatt6
{
    class Aufgabe3
    {
        public int[] Zahlen { get; set; }
        public bool Empty { get; set; }
        public bool Full { get; set; }
        public int First { get; set; }
        public int Last { get; set; }

        public Aufgabe3(int n)
        {
            Zahlen = new int[n];
            Empty = true;
            Full = false;
        }

        public void Enqueue(int i)
        {
            if (!Full)
            {
                Empty = false;
                Zahlen[Last] = i;
                Last = (Last + 1) % Zahlen.Length;
                Full = First == Last;
            }
            else { 
                throw new Exception();
            }
        }

        public int Dequeue()
        {
            if (!Empty)
            {
                Full = false;
                int ret = Zahlen[First];
                First = (First + 1) % Zahlen.Length;
                Empty = First == Last;
                return ret;
            }
            throw new Exception();
        }

        public int GetFirstObject()
        {
            if (!Empty)
            {
                return Zahlen[First];
            }
            throw new Exception();
        }

        public override string ToString()
        {
            return String.Join(", ", Zahlen);
        }

        public static Aufgabe3 CreateLottoZahlen(int zahlen)
        {
            Aufgabe3 a3 = new Aufgabe3(zahlen);

            for (int i = 1; i <= zahlen; i++)
            {
                a3.Enqueue(i);
            }

            return a3;
        }

        public static void ZahlenZiehen(int maxZahlen, Aufgabe3 input)
        {
            Random r = new Random();
            Aufgabe3 output = new Aufgabe3(maxZahlen - 6);

            int schritt = r.Next(1, maxZahlen/6);
            Console.WriteLine($"Schrittweite: {schritt}");

            int zahlenGezogen = 0;
            for (int i = 0; i < maxZahlen; i++)
            {
                int gezogeneZahl = input.Dequeue();
                if(zahlenGezogen < 6 && i == zahlenGezogen * schritt)
                {
                    Console.WriteLine($"Zieh Zahl an Stelle: {i}");
                    zahlenGezogen++;
                }
                else
                {
                    output.Enqueue(gezogeneZahl);
                }
            }
            Console.WriteLine(output);
        }

    }
}
