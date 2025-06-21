using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._55
{
    public class JumpGame : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.DynamicProgramming;
        // https://leetcode.com/problems/jump-game/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("[2,3,1,1,4], Expected : True");
            Console.WriteLine("Actual: " + solution.CanJump([2, 3, 1, 1, 4]));
        }

        public class Solution
        {
            public bool Jump(int position, int[] nums)
            {

                if (position == nums.Length - 1)
                    return true;

                int maxJumpLen = nums[position];
                if (maxJumpLen == 0)
                    return false;

                if (position + maxJumpLen >= nums.Length - 1)
                    return true;


                for (int i = maxJumpLen; i >= 1; --i)
                {
                    nums[position] = 0;
                    if (Jump(position + i, nums))
                        return true;
                }

                return false;

            }

            public bool CanJump(int[] nums)
            {
                return Jump(0, nums);
            }
        }

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("You are given an integer array nums. You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.\r\n\r\nReturn true if you can reach the last index, or false otherwise.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [2,3,1,1,4]\r\nOutput: true\r\nExplanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.\r\nExample 2:\r\n\r\nInput: nums = [3,2,1,0,4]\r\nOutput: false\r\nExplanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 104\r\n0 <= nums[i] <= 105");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}