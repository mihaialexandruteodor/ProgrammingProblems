using System;
using System.ComponentModel;

namespace problems.leetcode._226
{
    public class InvertBinaryTree : IBaseSolution
    {
        // https://leetcode.com/problems/invert-binary-tree/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("[4,2,7,1,3,6,9], Expected : [4,7,2,9,6,3,1]");
            Console.Write("Actual: ");
            PrintTreeAsArray(solution.InvertTree(BuildTree([4, 2, 7, 1, 3, 6, 9])));
        }

        public class Solution
        {
            public TreeNode InvertTree(TreeNode root)
            {
                if (root == null)
                    return null;
                TreeNode left = root.left;
                TreeNode right = root.right;
                root.left = right;
                root.right = left;
                InvertTree(left);
                InvertTree(right);

                return root;
            }
        }


        public void PrintTreeAsArray(TreeNode root)
        {
            List<int?> result = new();
            if (root == null)
            {
                Console.WriteLine("[]");
                return;
            }

            Queue<TreeNode> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();
                if (current != null)
                {
                    result.Add(current.val);
                    queue.Enqueue(current.left);
                    queue.Enqueue(current.right);
                }
                else
                {
                    result.Add(null);
                }
            }

            // Trim trailing nulls
            for (int i = result.Count - 1; i >= 0; i--)
            {
                if (result[i] != null)
                    break;
                result.RemoveAt(i);
            }

            Console.Write("[");
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write(result[i]?.ToString() ?? "null");
                if (i < result.Count - 1)
                    Console.Write(",");
            }
            Console.WriteLine("]");
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
            Console.WriteLine("Given the root of a binary tree, invert the tree, and return its root.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: root = [4,2,7,1,3,6,9]\r\nOutput: [4,7,2,9,6,3,1]\r\nExample 2:\r\n\r\nInput: root = [2,1,3]\r\nOutput: [2,3,1]\r\nExample 3:\r\n\r\nInput: root = []\r\nOutput: []\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in the tree is in the range [0, 100].\r\n-100 <= Node.val <= 100");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}