using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._19
{
    public class RemoveNthNodeFromEndOfList : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.LinkedList;
        public static readonly string description = "Given the head of a linked list, remove the nth node from the end of the list and return its head.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: head = [1,2,3,4,5], n = 2\r\nOutput: [1,2,3,5]\r\nExample 2:\r\n\r\nInput: head = [1], n = 1\r\nOutput: []\r\nExample 3:\r\n\r\nInput: head = [1,2], n = 1\r\nOutput: [1]\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in the list is sz.\r\n1 <= sz <= 30\r\n0 <= Node.val <= 100\r\n1 <= n <= sz\r\n \r\n\r\nFollow up: Could you do this in one pass?";
        // https://leetcode.com/problems/remove-nth-node-from-end-of-list/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("[1,2,3,4,5], n=2, Expected : [1,2,3,5]");
            Console.Write("Actual: " + Utils.PrintForConsole(solution.RemoveNthFromEnd(Utils.CreateLinkedList([1, 2, 3, 4, 5]), 2)));
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

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}