using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._213
{
    public class HouseRobber2 : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.DynamicProgramming;
        // https://leetcode.com/problems/house-robber-ii/
        public void solve()
        {
            Solution solution = new Solution();
            Console.WriteLine("[2,3,2], Expected : 3");
            Console.WriteLine("Actual: " + solution.Rob([2, 3, 2]));
        }

        public class Solution
        {
            public int Rob(int[] nums)
            {
                int n = nums.Length;
                if (n == 0) return 0;
                if (n == 1) return nums[0];
                if (n == 2) return Math.Max(nums[0], nums[1]);

                return Math.Max(RobLinear(nums, 0, n - 2), RobLinear(nums, 1, n - 1));
            }

            private int RobLinear(int[] nums, int start, int end)
            {
                int prev1 = 0, prev2 = 0;

                for (int i = start; i <= end; i++)
                {
                    int current = Math.Max(prev2 + nums[i], prev1);
                    prev2 = prev1;
                    prev1 = current;
                }

                return prev1;
            }
        }


        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed. All houses at this place are arranged in a circle. That means the first house is the neighbor of the last one. Meanwhile, adjacent houses have a security system connected, and it will automatically contact the police if two adjacent houses were broken into on the same night.\r\n\r\nGiven an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [2,3,2]\r\nOutput: 3\r\nExplanation: You cannot rob house 1 (money = 2) and then rob house 3 (money = 2), because they are adjacent houses.\r\nExample 2:\r\n\r\nInput: nums = [1,2,3,1]\r\nOutput: 4\r\nExplanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).\r\nTotal amount you can rob = 1 + 3 = 4.\r\nExample 3:\r\n\r\nInput: nums = [1,2,3]\r\nOutput: 3\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 100\r\n0 <= nums[i] <= 1000");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}