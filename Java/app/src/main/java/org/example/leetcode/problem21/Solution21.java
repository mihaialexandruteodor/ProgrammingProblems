package org.example.leetcode.problem21;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution21 extends BaseSolution {
    public Solution21() {
        this.name = "21. Merge Two Sorted Lists";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.LINKED_LISTS;
        this.description = "You are given the heads of two sorted linked lists list1 and list2.\r\n\r\nMerge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.\r\n\r\nReturn the head of the merged linked list.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: list1 = [1,2,4], list2 = [1,3,4]\r\nOutput: [1,1,2,3,4,4]\r\nExample 2:\r\n\r\nInput: list1 = [], list2 = []\r\nOutput: []\r\nExample 3:\r\n\r\nInput: list1 = [], list2 = [0]\r\nOutput: [0]\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in both lists is in the range [0, 50].\r\n-100 <= Node.val <= 100\r\nBoth list1 and list2 are sorted in non-decreasing order.";
        // https://leetcode.com/problems/merge-two-sorted-lists/
    }

    @Override
    public void solve() {

    }

}
