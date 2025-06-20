using System;
using System.ComponentModel;

namespace problems.leetcode._19
{
    public class RemoveNthNodeFromEndOfList : IBaseSolution
    {
        // https://leetcode.com/problems/remove-nth-node-from-end-of-list/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("[1,2,3,4,5], n=2, Expected : [1,2,3,5]");
            Console.Write("Actual: ");
            PrintLinkedListAsArray(solution.RemoveNthFromEnd(CreateLinkedList([1, 2, 3, 4, 5]), 2));
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public void PrintLinkedListAsArray(ListNode head)
        {
            List<int> values = new List<int>();
            while (head != null)
            {
                values.Add(head.val);
                head = head.next;
            }
            string result = "[" + string.Join(",", values) + "]";
            Console.WriteLine(result);
        }

        public ListNode CreateLinkedList(int[] values)
        {
            if (values == null || values.Length == 0) return null;

            ListNode head = new ListNode(values[0]);
            ListNode current = head;

            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;
            }

            return head;
        }

        public class Solution
        {
            public ListNode RemoveNthFromEnd(ListNode head, int n)
            {
                List<ListNode> list = new();
                ListNode iterator = head;
                while (iterator != null)
                {
                    list.Add(iterator);
                    iterator = iterator.next;
                }

                int targetIndex = list.Count - n;
                if (targetIndex == 0)
                    return head.next;

                iterator = list.ElementAt(targetIndex - 1);
                ListNode delNode = iterator.next;
                iterator.next = delNode.next;
                delNode.next = null;

                return head;

            }
        }

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Given the head of a linked list, remove the nth node from the end of the list and return its head.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: head = [1,2,3,4,5], n = 2\r\nOutput: [1,2,3,5]\r\nExample 2:\r\n\r\nInput: head = [1], n = 1\r\nOutput: []\r\nExample 3:\r\n\r\nInput: head = [1,2], n = 1\r\nOutput: [1]\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in the list is sz.\r\n1 <= sz <= 30\r\n0 <= Node.val <= 100\r\n1 <= n <= sz\r\n \r\n\r\nFollow up: Could you do this in one pass?");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}