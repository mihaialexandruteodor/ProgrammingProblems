package org.example.leetcode.problem143;

import java.util.ArrayList;
import java.util.List;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;
import org.example.leetcode.base.Utils.ListNode;

public class Solution143 extends BaseSolution {
    public Solution143() {
        this.name = "143. Reorder List";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.LINKED_LISTS;
        this.description = "Problem: You are given the head of a singly linked-list. The list can be represented as:\r\n\r\nL0 → L1 → … → Ln - 1 → Ln\r\nReorder the list to be on the following form:\r\n\r\nL0 → Ln → L1 → Ln - 1 → L2 → Ln - 2 → …\r\nYou may not modify the values in the list's nodes. Only nodes themselves may be changed.\r\n\r\n \r\n\r\nExample 1:Input: head = [1,2,3,4]\r\nOutput: [1,4,2,3]\r\nInput: head = [1,2,3,4,5]\r\nOutput: [1,5,2,4,3]\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in the list is in the range [1, 5 * 104].\r\n1 <= Node.val <= 1000";
        this.leetcodeurl = "https://leetcode.com/problems/reorder-list/";
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);

        Solution solution = new Solution();

        System.out.println("[1,2,3,4], Expected : [1,4,2,3]");
        int[] list1 = new int[] { 1, 2, 3, 4 };
        ListNode head1 = Utils.createLinkedList(list1);
        solution.reorderList(head1);
        System.out.print("Actual: ");
        printLinkedListAsArray(head1);

        System.out.println("[1,2,3,4,5], Expected : [1,5,2,4,3]");
        int[] list2 = new int[] { 1, 2, 3, 4, 5 };
        ListNode head2 = Utils.createLinkedList(list2);
        solution.reorderList(head2);
        System.out.print("Actual: ");
        printLinkedListAsArray(head2);
    }

    public void printLinkedListAsArray(ListNode head) {
        List<Integer> values = new ArrayList<>();
        while (head != null) {
            values.add(head.val);
            head = head.next;
        }
        System.out.println(Utils.printForConsole(values));
    }

    public class Solution {
        public void reorderList(ListNode head) {
            if (head == null || head.next == null)
                return;

            // Step 1: Find the middle
            ListNode slow = head;
            ListNode fast = head.next;
            while (fast != null && fast.next != null) {
                slow = slow.next;
                fast = fast.next.next;
            }

            // Step 2: Reverse second half
            ListNode second = slow.next;
            slow.next = null;

            ListNode prev = null;
            while (second != null) {
                ListNode temp = second.next;
                second.next = prev;
                prev = second;
                second = temp;
            }

            // Step 3: Merge two halves
            ListNode first = head;
            second = prev;

            while (second != null) {
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
