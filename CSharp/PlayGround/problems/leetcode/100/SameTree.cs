using System;
using System.ComponentModel;
using static IBaseSolution;
using static problems.leetcode._104.MaxDepthBinaryTree;

namespace problems.leetcode._100
{
    public class SameTree : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Easy;
        public static readonly Topic topic = Topic.Tree;
        public static readonly string description = "Given the roots of two binary trees p and q, write a function to check if they are the same or not.\r\n\r\nTwo binary trees are considered the same if they are structurally identical, and the nodes have the same value.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: p = [1,2,3], q = [1,2,3]\r\nOutput: true\r\nExample 2:\r\n\r\nInput: p = [1,2,3], q = [1,2,3]\r\nOutput: true\r\nExample 2:\r\n\r\nInput: p = [1,2,1], q = [1,1,2]\r\nOutput: false\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in both trees is in the range [0, 100].\r\n-104 <= Node.val <= 104";
        // https://leetcode.com/problems/same-tree/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("p = [1,2,3], q = [1,2,3], Expected : True");
            Console.WriteLine("Actual: " + solution.IsSameTree(BuildTree([1, 2, 3]), BuildTree([1, 2, 3])));
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        public class Solution
        {
            public bool IsSameTree(TreeNode p, TreeNode q)
            {
                if (p == null && q == null)
                    return true;

                if (p == null && q != null)
                    return false;

                if (p != null && q == null)
                    return false;

                if (p.val != q.val)
                    return false;

                if (p.left != null && q.left != null)
                    if (p.left.val != q.left.val)
                        return false;

                if (p.right != null && q.right != null)
                    if (p.right.val != q.right.val)
                        return false;

                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }
        }

        public TreeNode BuildTree(int?[] values)
        {
            if (values == null || values.Length == 0 || values[0] == null)
                return null;

            TreeNode root = new TreeNode(values[0].Value);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1;

            while (i < values.Length)
            {
                TreeNode current = queue.Dequeue();

                // Add left child
                if (i < values.Length && values[i] != null)
                {
                    current.left = new TreeNode(values[i].Value);
                    queue.Enqueue(current.left);
                }
                i++;

                // Add right child
                if (i < values.Length && values[i] != null)
                {
                    current.right = new TreeNode(values[i].Value);
                    queue.Enqueue(current.right);
                }
                i++;
            }

            return root;
        }
        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}