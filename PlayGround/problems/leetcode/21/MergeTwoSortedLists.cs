using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._21
{
    public class MergeTwoSortedLists : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Easy;
        public static readonly Topic topic = Topic.LinkedList;
        // https://leetcode.com/problems/merge-two-sorted-lists/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("list1 = [1,2,4], list2 = [1,3,4], Expected : [1,1,2,3,4,4]");
            Console.Write("Actual: ");
            PrintLinkedListAsArray(solution.MergeTwoLists(CreateLinkedList([1, 2, 4]), CreateLinkedList([1, 3, 4])));
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
            public ListNode MergeTwoLists(ListNode list1, ListNode list2)
            {
                ListNode dummy = new ListNode(0); // Dummy head
                ListNode curr = dummy;

                while (list1 != null && list2 != null)
                {
                    if (list1.val < list2.val)
                    {
                        curr.next = list1;
                        list1 = list1.next;
                    }
                    else
                    {
                        curr.next = list2;
                        list2 = list2.next;
                    }
                    curr = curr.next;
                }

                // Append the remaining nodes
                if (list1 != null)
                {
                    curr.next = list1;
                }
                else if (list2 != null)
                {
                    curr.next = list2;
                }

                return dummy.next; // Head of the merged list
            }
        }

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("EASY");
            Console.ResetColor();
            Console.WriteLine("You are given the heads of two sorted linked lists list1 and list2.\r\n\r\nMerge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.\r\n\r\nReturn the head of the merged linked list.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: list1 = [1,2,4], list2 = [1,3,4]\r\nOutput: [1,1,2,3,4,4]\r\nExample 2:\r\n\r\nInput: list1 = [], list2 = []\r\nOutput: []\r\nExample 3:\r\n\r\nInput: list1 = [], list2 = [0]\r\nOutput: [0]\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in both lists is in the range [0, 50].\r\n-100 <= Node.val <= 100\r\nBoth list1 and list2 are sorted in non-decreasing order.");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}