using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround.problems.DSA
{
    public class MyLinkedList
    {
        public class Node
        {
            public int val;
            public Node prev, next;

            public Node(int _val)
            {
                val = _val;
            }
        }

        private Node head;
        private Node tail;
        private int listSize;

        public MyLinkedList()
        {
            head = null;
            tail = null;
            listSize = 0;
        }

        public int Get(int index)
        {
            if (index < 0 || index >= listSize)
                return -1;

            Node curr = head;
            for (int i = 0; i < index; i++)
                curr = curr.next;

            return curr.val;
        }

        public void AddAtHead(int val)
        {
            Node newNode = new Node(val);
            newNode.next = head;
            if (head != null)
                head.prev = newNode;

            head = newNode;

            if (tail == null) // List was empty
                tail = head;

            listSize++;
        }

        public void AddAtTail(int val)
        {
            Node newNode = new Node(val);
            if (tail == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
            }

            listSize++;
        }

        public void AddAtIndex(int index, int val)
        {
            if (index < 0 || index > listSize)
                return;

            if (index == 0)
            {
                AddAtHead(val);
                return;
            }

            if (index == listSize)
            {
                AddAtTail(val);
                return;
            }

            Node curr = head;
            for (int i = 0; i < index - 1; i++)
                curr = curr.next;

            Node newNode = new Node(val);
            newNode.next = curr.next;
            newNode.prev = curr;
            curr.next.prev = newNode;
            curr.next = newNode;

            listSize++;
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= listSize)
                return;

            if (index == 0)
            {
                head = head.next;
                if (head != null)
                    head.prev = null;
                else
                    tail = null;
            }
            else
            {
                Node curr = head;
                for (int i = 0; i < index; i++)
                    curr = curr.next;

                curr.prev.next = curr.next;
                if (curr.next != null)
                    curr.next.prev = curr.prev;
                else
                    tail = curr.prev;
            }

            listSize--;
        }
    }

}
