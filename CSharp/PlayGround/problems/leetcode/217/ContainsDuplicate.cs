using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._217
{
    public class ContainsDuplicate : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Easy;
        public static readonly Topic topic = Topic.Arrays;
        public static readonly string description = "Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [1,2,3,1]\r\n\r\nOutput: true\r\n\r\nExplanation:\r\n\r\nThe element 1 occurs at the indices 0 and 3.\r\n\r\nExample 2:\r\n\r\nInput: nums = [1,2,3,4]\r\n\r\nOutput: false\r\n\r\nExplanation:\r\n\r\nAll elements are distinct.\r\n\r\nExample 3:\r\n\r\nInput: nums = [1,1,1,3,3,4,3,2,4,2]\r\n\r\nOutput: true\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 105\r\n-109 <= nums[i] <= 109";
        // https://leetcode.com/problems/contains-duplicate/
        public void solve()
        {
            Utils.Instance.PrintProblem(description, difficulty, topic);
            Solution solution = new Solution();
            Console.WriteLine("[1,2,3,4], Expected : False");
            Console.WriteLine("Actual: " + solution.ContainsDuplicate([1, 2, 3, 4]));
        }

        public class Solution
        {
            public bool ContainsDuplicate(int[] nums)
            {
                HashSet<int> set = new();
                foreach (int num in nums)
                    if (set.Contains(num))
                        return true;
                    else
                        set.Add(num);

                return false;
            }
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }

    }
}