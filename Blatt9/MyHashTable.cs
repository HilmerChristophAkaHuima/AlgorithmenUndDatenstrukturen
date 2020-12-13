using System;
using System.Collections.Generic;
using System.Text;

namespace Blatt9
{
    public class MyHashTable
    {
        public Tuple<int>[] Nodes { get; set; }

        public int Quantity { get; set; } = 0;

        public MyHashTable(int size)
        {
            Nodes = new Tuple<int>[size];
        }

        public int HashCode(int key)
        {
            return key % Nodes.Length;
        }

        public void InsertLinear(int val)
        {
            Tuple<int> temp = new Tuple<int>(val);

            int index = HashCode(val);

            while (Nodes[index] != null && Nodes[index].Item1 != val && Nodes[index].Item1 != -1)
            {
                index++;
                index %= Nodes.Length;
            }

            if (Nodes[index] == null || Nodes[index].Item1 == -1)
            {
                Quantity++;
            }

            Nodes[index] = temp;
        }

        public void Print()
        {
            for (int i = 0; i < Nodes.Length; i++)
            {
                Console.WriteLine($"Value = {Nodes[i]?.Item1}");
            }
        }
    }
}
