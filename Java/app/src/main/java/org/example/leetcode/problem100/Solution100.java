package org.example.leetcode.problem100;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution100 extends BaseSolution {
    public Solution100() {
        this.name = "100. Same Tree";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.TREES;
        this.description = "Given the roots of two binary trees p and q, write a function to check if they are the same or not.\r\n\r\nTwo binary trees are considered the same if they are structurally identical, and the nodes have the same value.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: p = [1,2,3], q = [1,2,3]\r\nOutput: true\r\nExample 2:\r\n\r\nInput: p = [1,2,3], q = [1,2,3]\r\nOutput: true\r\nExample 2:\r\n\r\nInput: p = [1,2,1], q = [1,1,2]\r\nOutput: false\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in both trees is in the range [0, 100].\r\n-104 <= Node.val <= 104";
        // https://leetcode.com/problems/same-tree/
    }

    @Override
    public void solve() {

    }

}
