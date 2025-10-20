package org.example.leetcode.problem226;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution226 extends BaseSolution {
    public Solution226() {
        this.name = "226. Invert Binary Tree";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.TREES;
        this.description = "Given the root of a binary tree, invert the tree, and return its root.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: root = [4,2,7,1,3,6,9]\r\nOutput: [4,7,2,9,6,3,1]\r\nExample 2:\r\n\r\nInput: root = [2,1,3]\r\nOutput: [2,3,1]\r\nExample 3:\r\n\r\nInput: root = []\r\nOutput: []\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in the tree is in the range [0, 100].\r\n-100 <= Node.val <= 100";
        // https://leetcode.com/problems/invert-binary-tree/
    }

    @Override
    public void solve() {

    }

}
