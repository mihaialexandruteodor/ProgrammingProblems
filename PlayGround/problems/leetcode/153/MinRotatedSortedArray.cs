using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._153
{
    public class MinRotatedSortedArray : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.Arrays;
        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Problem: Suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, the array nums = [0,1,2,4,5,6,7] might become:\r\n\r\n[4,5,6,7,0,1,2] if it was rotated 4 times.\r\n[0,1,2,4,5,6,7] if it was rotated 7 times.\r\nNotice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].\r\n\r\nGiven the sorted rotated array nums of unique elements, return the minimum element of this array.\r\n\r\nYou must write an algorithm that runs in O(log n) time.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [3,4,5,1,2]\r\nOutput: 1\r\nExplanation: The original array was [1,2,3,4,5] rotated 3 times.\r\nExample 2:\r\n\r\nInput: nums = [4,5,6,7,0,1,2]\r\nOutput: 0\r\nExplanation: The original array was [0,1,2,4,5,6,7] and it was rotated 4 times.\r\nExample 3:\r\n\r\nInput: nums = [11,13,15,17]\r\nOutput: 11\r\nExplanation: The original array was [11,13,15,17] and it was rotated 4 times. \r\n \r\n\r\nConstraints:\r\n\r\nn == nums.length\r\n1 <= n <= 5000\r\n-5000 <= nums[i] <= 5000\r\nAll the integers of nums are unique.\r\nnums is sorted and rotated between 1 and n times.");
            Console.WriteLine();
        }

        // https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
        // 
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("[4,5,6,7,0,1,2], Expected : 0");
            Console.WriteLine("Actual: " + solution.FindMin([4, 5, 6, 7, 0, 1, 2]));
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
        public class Solution
        {
            public int FindMin(int[] nums)
            {
                if (nums[0] < nums[nums.Length - 1] || nums.Length == 1)
                    return nums[0];

                int min = int.MaxValue;
                int i = 0;
                while (i < nums.Length - 1)
                {
                    if (nums[i] > nums[i + 1])
                        return nums[i + 1];
                    if (nums[i] < min)
                        min = nums[i];
                    ++i;
                }
                return min;
            }
        }
    }
}