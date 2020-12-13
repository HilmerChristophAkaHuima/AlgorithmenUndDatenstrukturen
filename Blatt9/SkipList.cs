using System;
using System.Collections.Generic;
using System.Text;

namespace Blatt9
{
    public class Nodes
    {
        public int Key { get; set; }
        public Nodes[] Forward { get; set; }

        public Nodes(int key, int level)
        {
            Key = key;
            Forward = new Nodes[level+1];
        }
    }

    public class SkipList
    {
        public int MaxLevel { get; set; }
        public double Fraction { get; set; }
        public int Level { get; set; }
        public Nodes First { get; set; }

        public SkipList(int max, double fraction)
        {
            MaxLevel = max;
            Fraction = fraction;
            Level = 0;

            First = new Nodes(-1, MaxLevel);
        }

        public void Insert(int key)
        {
            Nodes curr = First;

            Nodes[] update = new Nodes[MaxLevel+1];

            for (int i = Level; i >= 0; i--)
            {
                while (curr.Forward[i] != null && curr.Forward[i].Key < key)
                {
                    curr = curr.Forward[i];
                }

                update[i] = curr;
            }

            curr = curr.Forward[0];

            if (curr == null || curr.Key != key)
            {
                Random random = new Random();
                double r = random.NextDouble();
                int rLevel = 0;
                while (r < Fraction && rLevel < MaxLevel)
                {
                    rLevel++;
                    r = random.NextDouble();
                }

                if (rLevel > Level)
                {
                    for (int i = Level+1; i < rLevel+1; i++)
                    {
                        update[i] = First;
                    }

                    Level = rLevel;
                }

                Nodes temp = new Nodes(key, rLevel);

                for (int i = 0; i <= rLevel; i++)
                {
                    temp.Forward[i] = update[i].Forward[i];
                    update[i].Forward[i] = temp;
                }
            }
        }

        public void Delete(int key)
        {
            Nodes curr = First;

            Nodes[] update = new Nodes[MaxLevel+1];

            for (int i = Level; i >= 0; i--)
            {
                while (curr.Forward[i] != null && curr.Forward[i].Key < key)
                {
                    curr = curr.Forward[i];
                }

                update[i] = curr;
            }

            curr = curr.Forward[0];

            if (curr != null && curr.Key == key)
            {
                for (int i = 0; i <= Level; i++)
                {
                    if (update[i].Forward[i] != curr)
                    {
                        break;
                    }

                    update[i].Forward[i] = curr.Forward[i];
                }
            }

            while (Level > 0 && First.Forward[Level] == null)
            {
                Level--;
            }
        }

        public bool Search(int key)
        {
            Nodes curr = First;

            for (int i = Level; i >= 0; i--)
            {
                while (curr.Forward[i] != null && curr.Forward[i].Key < key)
                {
                    curr = curr.Forward[i];
                }
            }

            curr = curr.Forward[0];

            return (curr != null && curr.Key == key);
        }

        public void Print()
        {
            for (int i = 0; i <= Level; i++)
            {
                Nodes node = First.Forward[i];
                Console.Write($"Level {i}: ");
                while (node != null)
                {
                    Console.Write($"{node.Key} ");
                    node = node.Forward[i];
                }
                Console.WriteLine();
            }
        }
    }
}
