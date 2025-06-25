using System;
using System.ComponentModel;
using System.Text;
using static IBaseSolution;

namespace problems.leetcode._15
{
    public class ThreeSum : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.Arrays;
        public static readonly string description = "Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.\r\n\r\nNotice that the solution set must not contain duplicate triplets.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [-1,0,1,2,-1,-4]\r\nOutput: [[-1,-1,2],[-1,0,1]]\r\nExplanation: \r\nnums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.\r\nnums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.\r\nnums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.\r\nThe distinct triplets are [-1,0,1] and [-1,-1,2].\r\nNotice that the order of the output and the order of the triplets does not matter.\r\nExample 2:\r\n\r\nInput: nums = [0,1,1]\r\nOutput: []\r\nExplanation: The only possible triplet does not sum up to 0.\r\nExample 3:\r\n\r\nInput: nums = [0,0,0]\r\nOutput: [[0,0,0]]\r\nExplanation: The only possible triplet sums up to 0.\r\n \r\n\r\nConstraints:\r\n\r\n3 <= nums.length <= 3000\r\n-105 <= nums[i] <= 105";

        // https://leetcode.com/problems/3sum/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("[-1,0,1,2,-1,-4], Expected : [[-1,-1,2],[-1,0,1]]");
            Console.Write("Actual: ");
            PrintListOfLists(solution.ThreeSum([-1, 0, 1, 2, -1, -4]));
        }

        static void PrintListOfLists(IList<IList<int>> list)
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
            Console.WriteLine(sb.ToString());
        }

        public class Solution
        {
            public class ListComparer : IEqualityComparer<List<int>>
            {
                public bool Equals(List<int> a, List<int> b)
                {
                    if (a == null || b == null) return false;
                    if (a.Count != b.Count) return false;
                    for (int i = 0; i < a.Count; i++)
                        if (a[i] != b[i])
                            return false;
                    return true;
                }

                public int GetHashCode(List<int> list)
                {
                    if (list == null) return 0;
                    unchecked
                    {
                        int hash = 19;
                        foreach (int i in list)
                            hash = hash * 31 + i.GetHashCode();
                        return hash;
                    }
                }
            }

            public IList<IList<int>> ThreeSum(int[] nums)
            {
                HashSet<List<int>> sol = new HashSet<List<int>>(new ListComparer());
                Array.Sort(nums);
                for (int i = 0; i < nums.Length - 2; ++i)
                {
                    int j = i + 1, k = nums.Length - 1;
                    while (j < k)
                    {
                        int sum = nums[i] + nums[j] + nums[k];
                        if (sum == 0)
                        {
                            sol.Add(new List<int>([nums[i], nums[j], nums[k]]));
                            ++j;
                        }
                        else
                        {
                            if (sum > 0)
                            {
                                --k;
                            }
                            else
                            {
                                ++j;
                            }
                        }
                    }
                }

                return new List<IList<int>>(sol); ;
            }
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}