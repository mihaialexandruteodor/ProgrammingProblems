package org.example.leetcode.problem19;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution19 extends BaseSolution {
    public Solution19() {
        this.name = "19. Remove Nth Node From End of List";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.LINKED_LISTS;
        this.description = "Given the head of a linked list, remove the nth node from the end of the list and return its head.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: head = [1,2,3,4,5], n = 2\r\nOutput: [1,2,3,5]\r\nExample 2:\r\n\r\nInput: head = [1], n = 1\r\nOutput: []\r\nExample 3:\r\n\r\nInput: head = [1,2], n = 1\r\nOutput: [1]\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in the list is sz.\r\n1 <= sz <= 30\r\n0 <= Node.val <= 100\r\n1 <= n <= sz\r\n \r\n\r\nFollow up: Could you do this in one pass?";
        // https://leetcode.com/problems/remove-nth-node-from-end-of-list/
    }

    @Override
    public void solve() {

    }

}
