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

            Aufgabe3 a = Aufgabe3.CreateLottoZahlen(49);
            Console.WriteLine(a);

            Aufgabe3.ZahlenZiehen(49, a);
        }
    }
}
