using System.ComponentModel;

namespace problems.leetcode._23
{
    public class MergeKSortedLists : IBaseSolution
    {
        // https://leetcode.com/problems/merge-k-sorted-lists/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("[[1,4,5],[1,3,4],[2,6]], Expected : [1,1,2,3,4,4,5,6]");
            Console.Write("Actual: ");
            PrintLinkedListAsArray(solution.MergeKLists([CreateLinkedList([1, 4, 5]),
            CreateLinkedList([1, 3, 4]), CreateLinkedList([2, 6])]));
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

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("HARD");
            Console.ResetColor();
            Console.WriteLine("Problem: You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.\r\n\r\nMerge all the linked-lists into one sorted linked-list and return it.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: lists = [[1,4,5],[1,3,4],[2,6]]\r\nOutput: [1,1,2,3,4,4,5,6]\r\nExplanation: The linked-lists are:\r\n[\r\n  1->4->5,\r\n  1->3->4,\r\n  2->6\r\n]\r\nmerging them into one sorted list:\r\n1->1->2->3->4->4->5->6\r\nExample 2:\r\n\r\nInput: lists = []\r\nOutput: []\r\nExample 3:\r\n\r\nInput: lists = [[]]\r\nOutput: []\r\n \r\n\r\nConstraints:\r\n\r\nk == lists.length\r\n0 <= k <= 104\r\n0 <= lists[i].length <= 500\r\n-104 <= lists[i][j] <= 104\r\nlists[i] is sorted in ascending order.\r\nThe sum of lists[i].length will not exceed 104.");
            Console.WriteLine();
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

            public ListNode MergeKLists(ListNode[] lists)
            {
                if (lists.Length == 0)
                    return null;

                ListNode curr = lists[0];

                for (int i = 1; i < lists.Length; ++i)
                {
                    curr = MergeTwoLists(curr, lists[i]);
                }

                return curr;
            }
        }
    }
}