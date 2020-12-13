using System;

namespace Blatt9
{
    class Program
    {
        static void Main(string[] args)
        {
            MyHashTable table = new MyHashTable(11);
            table.InsertLinear(10);
            table.InsertLinear(22);
            table.InsertLinear(31);
            table.InsertLinear(4);
            table.InsertLinear(15);
            table.InsertLinear(28);
            table.InsertLinear(17);
            table.InsertLinear(88);
            table.InsertLinear(59);
            table.Print();

            SkipList list = new SkipList(3, 0.5);
            list.Insert(3);
            list.Insert(6);
            list.Insert(7);
            list.Insert(9);
            list.Insert(12);
            list.Insert(19);
            list.Insert(17);
            list.Insert(26);
            list.Insert(21);
            list.Insert(25);
            list.Print();

            Console.WriteLine(list.Search(19));
            Console.WriteLine(list.Search(1));

            list.Delete(19);
            list.Print();
        }
    }
}
