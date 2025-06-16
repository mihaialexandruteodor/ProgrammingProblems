using System.ComponentModel;
using static PlayGround.problems.DSA.IntersectionOfTwoLinkedLists;

namespace problems.leetcode._143
{
    public class ReorderList : IBaseSolution
    {
        // https://leetcode.com/problems/reorder-list/
        public void solve()
        {
            printProblem();

            Solution solution = new Solution();
            Console.WriteLine("[1,2,3,4], Expected : [1,4,2,3]");
            int[] list1 = [1, 2, 3, 4];
            ListNode head1 = CreateLinkedList(list1);
            solution.ReorderList(head1);
            Console.Write("Actual: ");
            PrintLinkedListAsArray(head1);

            Console.WriteLine("[1,2,3,4,5], Expected : [1,5,2,4,3]");
            int[] list2 = [1, 2, 3, 4, 5];
            ListNode head2 = CreateLinkedList(list2);
            solution.ReorderList(head2);
            Console.Write("Actual: ");
            PrintLinkedListAsArray(head2);
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Problem: You are given the head of a singly linked-list. The list can be represented as:\r\n\r\nL0 → L1 → … → Ln - 1 → Ln\r\nReorder the list to be on the following form:\r\n\r\nL0 → Ln → L1 → Ln - 1 → L2 → Ln - 2 → …\r\nYou may not modify the values in the list's nodes. Only nodes themselves may be changed.\r\n\r\n \r\n\r\nExample 1:Input: head = [1,2,3,4]\r\nOutput: [1,4,2,3]\r\nInput: head = [1,2,3,4,5]\r\nOutput: [1,5,2,4,3]\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in the list is in the range [1, 5 * 104].\r\n1 <= Node.val <= 1000");
            Console.WriteLine();
        }

        /**
     * Definition for singly-linked list.
     *  */
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
            public void ReorderList(ListNode head)
            {
                if (head == null || head.next == null) return;

                // Step 1: Find the middle
                ListNode slow = head;
                ListNode fast = head.next;

                while (fast != null && fast.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }

                // Step 2: Reverse second half
                ListNode second = slow.next;
                slow.next = null; // break the list

                ListNode prev = null;
                while (second != null)
                {
                    ListNode temp = second.next;
                    second.next = prev;
                    prev = second;
                    second = temp;
                }

                // Step 3: Merge two halves
                ListNode first = head;
                second = prev;

                while (second != null)
                {
                    ListNode temp1 = first.next;
                    ListNode temp2 = second.next;

                    first.next = second;
                    second.next = temp1;

                    first = temp1;
                    second = temp2;
                }
            }
        }
    }
}