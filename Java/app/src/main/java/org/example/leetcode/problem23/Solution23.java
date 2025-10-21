package org.example.leetcode.problem23;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;
import org.example.leetcode.base.Utils.ListNode;

public class Solution23 extends BaseSolution {
    public Solution23() {
        this.name = "23. Merge k Sorted Lists";
        this.difficulty = Utils.Difficulty.HARD;
        this.topic = Utils.Topic.LINKED_LISTS;
        this.description = "Problem: You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.\r\n\r\nMerge all the linked-lists into one sorted linked-list and return it.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: lists = [[1,4,5],[1,3,4],[2,6]]\r\nOutput: [1,1,2,3,4,4,5,6]\r\nExplanation: The linked-lists are:\r\n[\r\n  1->4->5,\r\n  1->3->4,\r\n  2->6\r\n]\r\nmerging them into one sorted list:\r\n1->1->2->3->4->4->5->6\r\nExample 2:\r\n\r\nInput: lists = []\r\nOutput: []\r\nExample 3:\r\n\r\nInput: lists = [[]]\r\nOutput: []\r\n \r\n\r\nConstraints:\r\n\r\nk == lists.length\r\n0 <= k <= 104\r\n0 <= lists[i].length <= 500\r\n-104 <= lists[i][j] <= 104\r\nlists[i] is sorted in ascending order.\r\nThe sum of lists[i].length will not exceed 104.";
        // https://leetcode.com/problems/merge-k-sorted-lists/
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("[[1,4,5],[1,3,4],[2,6]], Expected : [1,1,2,3,4,4,5,6]");
        System.out.println("Actual: " + Utils.printForConsole(solution.mergeKLists(new ListNode[] {
                Utils.createLinkedList(new int[] { 1, 4, 5 }),
                Utils.createLinkedList(new int[] { 1, 3, 4 }),
                Utils.createLinkedList(new int[] { 2, 6 })
        })));
    }

    public class Solution {

        public ListNode mergeTwoLists(ListNode list1, ListNode list2) {
            ListNode dummy = new ListNode(0);
            ListNode curr = dummy;

            while (list1 != null && list2 != null) {
                if (list1.val < list2.val) {
                    curr.next = list1;
                    list1 = list1.next;
                } else {
                    curr.next = list2;
                    list2 = list2.next;
                }
                curr = curr.next;
            }

            if (list1 != null) {
                curr.next = list1;
            } else if (list2 != null) {
                curr.next = list2;
            }

            return dummy.next;
        }

        public ListNode mergeKLists(ListNode[] lists) {
            if (lists.length == 0)
                return null;

            ListNode curr = lists[0];
            for (int i = 1; i < lists.length; ++i) {
                curr = mergeTwoLists(curr, lists[i]);
            }
            return curr;
        }
    }

}
