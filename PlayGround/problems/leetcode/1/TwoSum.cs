using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._1
{
    public class TwoSum : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Easy;
        public static readonly Topic topic = Topic.Arrays;

        // https://leetcode.com/problems/two-sum/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("[2,7,11,15], t=9, Expected : [0,1]");
            Console.WriteLine("Actual: [" + string.Join(",", solution.TwoSum([2, 7, 11, 15], 9)) + "]");
        }

        public class Solution
        {
            public int[] TwoSum(int[] nums, int target)
            {
                for (int i = 0; i < nums.Length - 1; ++i)
                {
                    for (int j = i + 1; j < nums.Length; ++j)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            return new int[] { i, j };
                        }
                    }
                }
                return null;
            }
        }

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("EASY");
            Console.ResetColor();
            Console.WriteLine("Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.\r\n\r\nYou may assume that each input would have exactly one solution, and you may not use the same element twice.\r\n\r\nYou can return the answer in any order.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [2,7,11,15], target = 9\r\nOutput: [0,1]\r\nExplanation: Because nums[0] + nums[1] == 9, we return [0, 1].\r\nExample 2:\r\n\r\nInput: nums = [3,2,4], target = 6\r\nOutput: [1,2]\r\nExample 3:\r\n\r\nInput: nums = [3,3], target = 6\r\nOutput: [0,1]\r\n \r\n\r\nConstraints:\r\n\r\n2 <= nums.length <= 104\r\n-109 <= nums[i] <= 109\r\n-109 <= target <= 109\r\nOnly one valid answer exists.\r\n \r\n\r\nFollow-up: Can you come up with an algorithm that is less than O(n2) time complexity?");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}