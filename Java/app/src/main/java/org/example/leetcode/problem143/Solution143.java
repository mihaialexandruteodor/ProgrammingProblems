package org.example.leetcode.problem143;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution143 extends BaseSolution {
    public Solution143() {
        this.name = "143. Reorder List";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.LINKED_LISTS;
        this.description = "Problem: You are given the head of a singly linked-list. The list can be represented as:\r\n\r\nL0 → L1 → … → Ln - 1 → Ln\r\nReorder the list to be on the following form:\r\n\r\nL0 → Ln → L1 → Ln - 1 → L2 → Ln - 2 → …\r\nYou may not modify the values in the list's nodes. Only nodes themselves may be changed.\r\n\r\n \r\n\r\nExample 1:Input: head = [1,2,3,4]\r\nOutput: [1,4,2,3]\r\nInput: head = [1,2,3,4,5]\r\nOutput: [1,5,2,4,3]\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in the list is in the range [1, 5 * 104].\r\n1 <= Node.val <= 1000";
        // https://leetcode.com/problems/reorder-list/
    }

    @Override
    public void solve() {

    }

}
