using System;
using System.Collections.Generic;
using System.Text;

namespace Blatt6
{
    public class Aufgabe2
    {
        public Node head;

        public class Node
        {
            public int data;
            public Node next;
            public Node prev;

            public Node(int d)
            {
                data = d;
                next = null;
                prev = null;
            }
        }

        Node lastNode(Node node)
        {
            while (node.next != null)
                node = node.next;
            return node;
        }
        Node Partition(Node l, Node h)
        {
            int x = h.data;

            Node i = l.prev;
            int temp;

            for (Node j = l; j != h; j = j.next)
            {
                if (j.data <= x)
                {
                    i = (i == null) ? l : i.next;
                    temp = i.data;
                    i.data = j.data;
                    j.data = temp;
                }
            }
            i = (i == null) ? l : i.next;
            temp = i.data;
            i.data = h.data;
            h.data = temp;
            return i;
        }

        void Quicksort(Node l, Node h)
        {
            if (h != null && l != h && l != h.next)
            {
                Node temp = Partition(l, h);
                Quicksort(l, temp.prev);
                Quicksort(temp.next, h);
            }
        }
        public void QuickSortStart(Node node)
        {

            Node head = lastNode(node);

            Quicksort(node, head);
        }
        public void PrintList(Node head)
        {
            while (head != null)
            {
                Console.Write(head.data + " ");
                head = head.next;
            }
        }

        public void Einfuegen(int new_Data)
        {
            Node new_Node = new Node(new_Data);


            if (head == null)
            {
                head = new_Node;
                return;
            }


            new_Node.next = head;

            head.prev = new_Node;

            new_Node.prev = null;

            head = new_Node;
        }
    }
}
