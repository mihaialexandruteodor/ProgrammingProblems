using System;
using System.ComponentModel;
using System.Text;
using static IBaseSolution;

namespace problems.leetcode._78
{
    public class Subsets : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.DynamicProgramming;
        public static readonly string description = "Given an integer array nums of unique elements, return all possible subsets (the power set).\r\n\r\nThe solution set must not contain duplicate subsets. Return the solution in any order.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [1,2,3]\r\nOutput: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]\r\nExample 2:\r\n\r\nInput: nums = [0]\r\nOutput: [[],[0]]\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 10\r\n-10 <= nums[i] <= 10\r\nAll the numbers of nums are unique.";
        // https://leetcode.com/problems/subsets/
        // BACKTRACKING
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("[1,2,3], Expected : [[],[1],[1,2],[1,2,3],[1,3],[2],[2,3],[3]]");
            Console.Write("Actual: " + FormatListOfLists(solution.Subsets([1, 2, 3])));
        }

        static string FormatListOfLists(IList<IList<int>> list)
        {
            var sb = new StringBuilder();
            sb.Append("[");

            for (int i = 0; i < list.Count; i++)
            {
                sb.Append("[");
                sb.Append(string.Join(",", list[i]));
                sb.Append("]");

                if (i < list.Count - 1)
                    sb.Append(",");
            }

            sb.Append("]");
            return sb.ToString();
        }

        public class Solution
        {
            public IList<IList<int>> Subsets(int[] nums)
            {
                List<IList<int>> res = new();

                void backtrack(int start, List<int> current)
                {
                    res.Add(new List<int>(current)); // Add a copy, not the reference

                    for (int i = start; i < nums.Length; ++i)
                    {
                        current.Add(nums[i]);
                        backtrack(i + 1, current);
                        current.RemoveAt(current.Count - 1); // Always remove last added
                    }
                }

                backtrack(0, new List<int>());

                return res;
            }
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}