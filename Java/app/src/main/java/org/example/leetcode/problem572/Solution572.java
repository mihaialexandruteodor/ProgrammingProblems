package org.example.leetcode.problem572;

import java.util.LinkedList;
import java.util.Queue;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution572 extends BaseSolution {
    public Solution572() {
        this.name = "572. Subtree of Another Tree";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.TREES;
        this.description = "Given the roots of two binary trees root and subRoot, return true if there is a subtree of root with the same structure and node values of subRoot and false otherwise.\r\n\r\nA subtree of a binary tree tree is a tree that consists of a node in tree and all of this node's descendants. The tree tree could also be considered as a subtree of itself.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: root = [3,4,5,1,2], subRoot = [4,1,2]\r\nOutput: true\r\nExample 2:\r\n\r\nInput: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]\r\nOutput: false\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in the root tree is in the range [1, 2000].\r\nThe number of nodes in the subRoot tree is in the range [1, 1000].\r\n-104 <= root.val <= 104\r\n-104 <= subRoot.val <= 104";
        this.leetcodeurl = "https://leetcode.com/problems/subtree-of-another-tree/";
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();

        TreeNode root = buildTree(new Integer[] { 3, 4, 5, 1, 2 });
        TreeNode subRoot = buildTree(new Integer[] { 4, 1, 2 });
        System.out.println("Expected : True");
        System.out.println("Actual: " + solution.isSubtree(root, subRoot));
    }

    public class Solution {
        public boolean isSubtree(TreeNode root, TreeNode subRoot) {
            if (root == null)
                return false;
            if (isSame(root, subRoot))
                return true;
            return isSubtree(root.left, subRoot) || isSubtree(root.right, subRoot);
        }

        private boolean isSame(TreeNode s, TreeNode t) {
            if (s == null && t == null)
                return true;
            if (s == null || t == null)
                return false;
            if (s.val != t.val)
                return false;
            return isSame(s.left, t.left) && isSame(s.right, t.right);
        }
    }

    // Utility method to build TreeNode from array
    public TreeNode buildTree(Integer[] values) {
        if (values == null || values.length == 0 || values[0] == null)
            return null;

        TreeNode root = new TreeNode(values[0]);
        Queue<TreeNode> queue = new LinkedList<>();
        queue.add(root);
        int i = 1;

        while (i < values.length) {
            TreeNode current = queue.poll();

            if (i < values.length && values[i] != null) {
                current.left = new TreeNode(values[i]);
                queue.add(current.left);
            }
            i++;

            if (i < values.length && values[i] != null) {
                current.right = new TreeNode(values[i]);
                queue.add(current.right);
            }
            i++;
        }

        return root;
    }

    // TreeNode definition
    public class TreeNode {
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

}
