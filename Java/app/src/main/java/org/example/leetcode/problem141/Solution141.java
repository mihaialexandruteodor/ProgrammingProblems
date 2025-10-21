package org.example.leetcode.problem141;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;
import org.example.leetcode.base.Utils.ListNode;

public class Solution141 extends BaseSolution {
    public Solution141() {
        this.name = "141. Linked List Cycle";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.LINKED_LISTS;
        this.description = "Given head, the head of a linked list, determine if the linked list has a cycle in it.\r\n\r\nThere is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.\r\n\r\nReturn true if there is a cycle in the linked list. Otherwise, return false.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: head = [3,2,0,-4], pos = 1\r\nOutput: true\r\nExplanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).\r\nExample 2:\r\n\r\nInput: head = [3,2,0,-4], pos = 1\r\nOutput: true\r\nExplanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).\r\nExample 2:\r\n\r\nInput: head = [1], pos = -1\r\nOutput: false\r\nExplanation: There is no cycle in the linked list.\r\n \r\n\r\nConstraints:\r\n\r\nThe number of the nodes in the list is in the range [0, 104].\r\n-105 <= Node.val <= 105\r\npos is -1 or a valid index in the linked-list.\r\n \r\n\r\nFollow up: Can you solve it using O(1) (i.e. constant) memory?";
        // https://leetcode.com/problems/linked-list-cycle/
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("[3,2,0,-4], pos = 1, Expected : True");
        System.out.println("Actual: " + solution.hasCycle(Utils.createLinkedList(new int[] { 3, 2, 0, -4 }, 1)));
    }

    public class Solution {
        public boolean hasCycle(ListNode head) {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null) {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                    return true;
            }

            return false;
        }
    }

}
