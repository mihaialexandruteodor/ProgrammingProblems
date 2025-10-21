package org.example.leetcode.problem100;

import java.util.LinkedList;
import java.util.Queue;

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
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("p = [1,2,3], q = [1,2,3], Expected : True");
        System.out.println("Actual: " + solution.isSameTree(buildTree(new Integer[] { 1, 2, 3 }),
                buildTree(new Integer[] { 1, 2, 3 })));
    }

    public class Solution {
        public boolean isSameTree(TreeNode p, TreeNode q) {
            if (p == null && q == null)
                return true;
            if (p == null || q == null)
                return false;
            if (p.val != q.val)
                return false;
            return isSameTree(p.left, q.left) && isSameTree(p.right, q.right);
        }
    }

    // TreeNode helper
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
