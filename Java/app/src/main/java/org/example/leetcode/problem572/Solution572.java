package org.example.leetcode.problem572;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution572 extends BaseSolution {
    public Solution572() {
        this.name = "572. Subtree of Another Tree";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.TREES;
        this.description = "Given the roots of two binary trees root and subRoot, return true if there is a subtree of root with the same structure and node values of subRoot and false otherwise.\r\n\r\nA subtree of a binary tree tree is a tree that consists of a node in tree and all of this node's descendants. The tree tree could also be considered as a subtree of itself.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: root = [3,4,5,1,2], subRoot = [4,1,2]\r\nOutput: true\r\nExample 2:\r\n\r\nInput: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]\r\nOutput: false\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in the root tree is in the range [1, 2000].\r\nThe number of nodes in the subRoot tree is in the range [1, 1000].\r\n-104 <= root.val <= 104\r\n-104 <= subRoot.val <= 104";
        // https://leetcode.com/problems/subtree-of-another-tree/
    }

    @Override
    public void solve() {

    }

}
