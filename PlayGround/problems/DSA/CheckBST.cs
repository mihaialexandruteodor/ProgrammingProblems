using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround.problems.DSA
{
    // https://www.hackerrank.com/challenges/ctci-is-binary-search-tree/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=trees

    /*
      left child index in BST: 2*i + 1
      right child index in BST: 2*i + 2
     */
    public class CheckBST : IBaseSolution
    {
        public void printProblem()
        {
            Console.WriteLine("For the purposes of this challenge, we define a binary search tree to be a binary tree with the following properties:\r\n\r\nThe  value of every node in a node's left subtree is less than the data value of that node.\r\nThe  value of every node in a node's right subtree is greater than the data value of that node.\r\nThe  value of every node is distinct.\r\nFor example, the image on the left below is a valid BST. The one on the right fails on several counts:\r\n- All of the numbers on the right branch from the root are not larger than the root.\r\n- All of the numbers on the right branch from node 5 are not larger than 5.\r\n- All of the numbers on the left branch from node 5 are not smaller than 5.\r\n- The data value 1 is repeated.\r\nGiven the root node of a binary tree, determine if it is a binary search tree.\r\n\r\nFunction Description\r\n\r\nComplete the function checkBST in the editor below. It must return a boolean denoting whether or not the binary tree is a binary search tree.\r\n\r\ncheckBST has the following parameter(s):\r\n\r\nroot: a reference to the root node of a tree to test\r\nInput Format\r\n\r\nYou are not responsible for reading any input from stdin. Hidden code stubs will assemble a binary tree and pass its root node to your function as an argument.\r\n\r\nConstraints\r\n\r\nOutput Format\r\n\r\nYour function must return a boolean true if the tree is a binary search tree. Otherwise, it must return false.");
            Console.WriteLine();
        }

        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("Expect Yes, actual: " + solution.checkBST([1, 2, 3, 4, 5, 6, 7], 2));
            Console.WriteLine("Expect Yes, actual: " + solution.checkBST([3, 5, 7, 9, 11, 13, 15], 2));
            Console.WriteLine("Expect No, actual: " + solution.checkBST([1, 2, 4, 3, 5, 6, 7], 2));
        }


        public class Solution
        {

            static bool bstRoot(int[] tree, int rootIndex)
            {
                int rootVal = tree[rootIndex];
                bool solLeft = true, solRight = true;

                if (rootIndex * 2 + 1 < tree.Length)
                {
                    if (tree[rootIndex * 2 + 1] >= rootVal)
                    {
                        return false;
                    }
                    else
                    {
                        solLeft = bstRoot(tree, rootIndex * 2 + 1);
                    }
                }

                if (rootIndex * 2 + 2 < tree.Length)
                {
                    if (tree[rootIndex * 2 + 2] <= rootVal)
                    {
                        return false;
                    }
                    else
                    {
                        solRight = bstRoot(tree, rootIndex * 2 + 2);
                    }
                }

                return solLeft && solRight;

            }

            public string checkBST(int[] data, int number)
            {
           

                if (number < data[0])
                {
                    return "No";
                }

                int indexRoot = Array.IndexOf(data, number);

                if (indexRoot == -1)
                {
                    return "No";
                }

                if (bstRoot(data, indexRoot))
                {
                    return "Yes";
                }
                else
                {
                    return "No";
                }


            }
        }
    }
}
