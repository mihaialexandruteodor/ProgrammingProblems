using System;
using System.ComponentModel;

namespace problems.leetcode._104
{
    public class MaxDepthBinaryTree : IBaseSolution
    {
        // https://leetcode.com/problems/maximum-depth-of-binary-tree/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("[3,9,20,null,null,15,7], Expected : 3");
            Console.WriteLine("Actual: " + solution.MaxDepth(BuildTree([3, 9, 20, null, null, 15, 7])));
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
            public int MaxDepth(TreeNode root)
            {
                if (root == null)
                    return 0;
                if (root.left == null && root.right == null)
                    return 1;
                return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
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

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("EASY");
            Console.ResetColor();
            Console.WriteLine("Given the root of a binary tree, return its maximum depth.\r\n\r\nA binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: root = [3,9,20,null,null,15,7]\r\nOutput: 3\r\nExample 2:\r\n\r\nInput: root = [1,null,2]\r\nOutput: 2\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in the tree is in the range [0, 104].\r\n-100 <= Node.val <= 100");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}