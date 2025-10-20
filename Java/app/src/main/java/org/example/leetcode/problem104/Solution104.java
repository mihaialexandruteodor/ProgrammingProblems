package org.example.leetcode.problem104;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution104 extends BaseSolution {
    public Solution104() {
        this.name = "104. Maximum Depth of Binary Tree";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.TREES;
        this.description = "Given the root of a binary tree, return its maximum depth.\r\n\r\nA binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: root = [3,9,20,null,null,15,7]\r\nOutput: 3\r\nExample 2:\r\n\r\nInput: root = [1,null,2]\r\nOutput: 2\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in the tree is in the range [0, 104].\r\n-100 <= Node.val <= 100";
        // https://leetcode.com/problems/maximum-depth-of-binary-tree/
    }

    @Override
    public void solve() {

    }

}
