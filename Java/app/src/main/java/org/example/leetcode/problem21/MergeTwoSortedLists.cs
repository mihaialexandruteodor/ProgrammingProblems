using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._21
{
    public class MergeTwoSortedLists : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Easy;
        public static readonly Topic topic = Topic.LinkedList;
        public static readonly string description = "You are given the heads of two sorted linked lists list1 and list2.\r\n\r\nMerge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.\r\n\r\nReturn the head of the merged linked list.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: list1 = [1,2,4], list2 = [1,3,4]\r\nOutput: [1,1,2,3,4,4]\r\nExample 2:\r\n\r\nInput: list1 = [], list2 = []\r\nOutput: []\r\nExample 3:\r\n\r\nInput: list1 = [], list2 = [0]\r\nOutput: [0]\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in both lists is in the range [0, 50].\r\n-100 <= Node.val <= 100\r\nBoth list1 and list2 are sorted in non-decreasing order.";
        // https://leetcode.com/problems/merge-two-sorted-lists/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("list1 = [1,2,4], list2 = [1,3,4], Expected : [1,1,2,3,4,4]");
            Console.Write("Actual: " + Utils.PrintForConsole(solution.MergeTwoLists(Utils.CreateLinkedList([1, 2, 4]), Utils.CreateLinkedList([1, 3, 4]))));
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
        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}