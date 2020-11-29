using System;

namespace Blatt7
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree b = new Tree();
            b.Insert(6);
            b.Insert(3);
            b.Insert(1);
            b.Insert(8);
            b.Insert(7);
            b.Insert(9);

            b.Print();

            b = new Tree();
            b.Insert(45);
            b.Insert(23);
            b.Insert(57);
            b.Insert(12);
            b.Insert(20);

            b.Print();

            b.DeleteValue(23);

            b.Print();

            b = new Tree();
            b.Insert(45);
            b.Insert(23);
            b.Insert(57);
            b.Insert(12);
            b.Insert(20);

            b.Print();

            b.DeleteValueIterativ(23);

            b.Print();

            int[] inorder = {10, 15, 17, 19, 20, 25};
            int[] prorder = {17, 15, 10, 20, 19, 25};

            b = Tree.InOrderPreOrderTreeCreater(inorder, prorder);
            b.Print();
        }
    }
}
