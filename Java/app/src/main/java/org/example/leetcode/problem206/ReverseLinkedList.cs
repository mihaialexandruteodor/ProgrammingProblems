using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._206
{
    public class ReverseLinkedList : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Easy;
        public static readonly Topic topic = Topic.LinkedList;
        public static readonly string description = "Given the head of a singly linked list, reverse the list, and return the reversed list.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: head = [1,2,3,4,5]\r\nOutput: [5,4,3,2,1]\r\nExample 2:\r\n\r\nInput: head = [1,2]\r\nOutput: [2,1]\r\nExample 3:\r\n\r\nInput: head = []\r\nOutput: []\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in the list is the range [0, 5000].\r\n-5000 <= Node.val <= 5000";
        // https://leetcode.com/problems/reverse-linked-list/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("[1,2,3,4,5], Expected : [5,4,3,2,1]");
            Console.Write("Actual: " + Utils.PrintForConsole(solution.ReverseList(Utils.CreateLinkedList([1, 2, 3, 4, 5]))));
        }
        public class Solution
        {
            public ListNode ReverseList(ListNode head)
            {
                ListNode prev = null;
                ListNode curr = head;

                while (curr != null)
                {
                    ListNode next = curr.next; // temporarily store next node
                    curr.next = prev;          // reverse the current node's pointer
                    prev = curr;               // move prev one step forward
                    curr = next;               // move curr one step forward
                }

                return prev; // new head of the reversed list
            }
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}