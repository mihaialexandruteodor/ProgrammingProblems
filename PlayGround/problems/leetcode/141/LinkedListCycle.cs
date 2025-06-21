using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._141
{
    public class LinkedListCycle : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Easy;
        public static readonly Topic topic = Topic.LinkedList;
        // https://leetcode.com/problems/linked-list-cycle/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("[3,2,0,-4], pos = 1, Expected : True");
            Console.WriteLine("Actual: " + solution.HasCycle(CreateLinkedList([3, 2, 0, -4], 1)));
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }

        public ListNode CreateLinkedList(int[] values, int pos)
        {
            if (values == null || values.Length == 0) return null;

            ListNode head = new ListNode(values[0]);
            ListNode current = head;
            ListNode loop = pos == 0 ? head : null;


            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                if (i == pos)
                    loop = current;
                current = current.next;
            }

            current.next = loop;

            return head;
        }
        public class Solution
        {
            public bool HasCycle(ListNode head)
            {
                ListNode fast = head;
                ListNode slow = head;

                while (fast != null && fast.next != null)
                {
                    fast = fast.next.next;
                    slow = slow.next;

                    if (fast == slow)
                        return true;
                }

                return false;
            }
        }

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("EASY");
            Console.ResetColor();
            Console.WriteLine("Given head, the head of a linked list, determine if the linked list has a cycle in it.\r\n\r\nThere is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.\r\n\r\nReturn true if there is a cycle in the linked list. Otherwise, return false.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: head = [3,2,0,-4], pos = 1\r\nOutput: true\r\nExplanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).\r\nExample 2:\r\n\r\nInput: head = [3,2,0,-4], pos = 1\r\nOutput: true\r\nExplanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).\r\nExample 2:\r\n\r\nInput: head = [1], pos = -1\r\nOutput: false\r\nExplanation: There is no cycle in the linked list.\r\n \r\n\r\nConstraints:\r\n\r\nThe number of the nodes in the list is in the range [0, 104].\r\n-105 <= Node.val <= 105\r\npos is -1 or a valid index in the linked-list.\r\n \r\n\r\nFollow up: Can you solve it using O(1) (i.e. constant) memory?");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}