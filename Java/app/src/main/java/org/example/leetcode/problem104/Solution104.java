package org.example.leetcode.problem104;

import java.util.LinkedList;
import java.util.Queue;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution104 extends BaseSolution {
    public Solution104() {
        this.name = "104. Maximum Depth of Binary Tree";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.TREES;
        this.description = "Given the root of a binary tree, return its maximum depth.\r\n\r\nA binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: root = [3,9,20,null,null,15,7]\r\nOutput: 3\r\nExample 2:\r\n\r\nInput: root = [1,null,2]\r\nOutput: 2\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in the tree is in the range [0, 104].\r\n-100 <= Node.val <= 100";
        this.leetcodeurl = "https://leetcode.com/problems/maximum-depth-of-binary-tree/";
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("[3,9,20,null,null,15,7], Expected : 3");
        System.out.println("Actual: " + solution.maxDepth(buildTree(new Integer[] { 3, 9, 20, null, null, 15, 7 })));
    }

    // TreeNode definition
    public static class TreeNode {
        int val;
        TreeNode left;
        TreeNode right;

        TreeNode(int val) {
            this.val = val;
        }

        TreeNode(int val, TreeNode left, TreeNode right) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution {
        public int maxDepth(TreeNode root) {
            if (root == null)
                return 0;
            return 1 + Math.max(maxDepth(root.left), maxDepth(root.right));
        }
    }

    // Tree builder utility
    public TreeNode buildTree(Integer[] values) {
        if (values == null || values.length == 0 || values[0] == null)
            return null;

        TreeNode root = new TreeNode(values[0]);
        Queue<TreeNode> queue = new LinkedList<>();
        queue.add(root);
        int i = 1;

        while (i < values.length) {
            TreeNode current = queue.poll();

            // Left child
            if (i < values.length && values[i] != null) {
                current.left = new TreeNode(values[i]);
                queue.add(current.left);
            }
            i++;

            // Right child
            if (i < values.length && values[i] != null) {
                current.right = new TreeNode(values[i]);
                queue.add(current.right);
            }
            i++;
        }

        return root;
    }

}
