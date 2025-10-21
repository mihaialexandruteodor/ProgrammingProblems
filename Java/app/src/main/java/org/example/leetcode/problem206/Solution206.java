package org.example.leetcode.problem206;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution206 extends BaseSolution {
    public Solution206() {
        this.name = "206. Reverse Linked List";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.LINKED_LISTS;
        this.description = "Given the head of a singly linked list, reverse the list, and return the reversed list.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: head = [1,2,3,4,5]\r\nOutput: [5,4,3,2,1]\r\nExample 2:\r\n\r\nInput: head = [1,2]\r\nOutput: [2,1]\r\nExample 3:\r\n\r\nInput: head = []\r\nOutput: []\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in the list is the range [0, 5000].\r\n-5000 <= Node.val <= 5000";
        this.leetcodeurl = "https://leetcode.com/problems/reverse-linked-list/";
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();

        int[] values = { 1, 2, 3, 4, 5 };
        Utils.ListNode head = Utils.createLinkedList(values);

        System.out.println("[1,2,3,4,5], Expected : [5,4,3,2,1]");
        System.out.println("Actual: " + Utils.printForConsole(solution.reverseList(head)));
    }

    public class Solution {
        public Utils.ListNode reverseList(Utils.ListNode head) {
            Utils.ListNode prev = null;
            Utils.ListNode curr = head;

            while (curr != null) {
                Utils.ListNode next = curr.next; // temporarily store next node
                curr.next = prev; // reverse the current node's pointer
                prev = curr; // move prev one step forward
                curr = next; // move curr one step forward
            }

            return prev; // new head of the reversed list
        }
    }

}
