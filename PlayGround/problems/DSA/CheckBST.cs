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

        public void solve()
        {
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
