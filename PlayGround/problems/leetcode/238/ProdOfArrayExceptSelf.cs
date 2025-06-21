using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._238
{
    public class ProdOfArrayExceptSelf : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Medium;
        public static readonly Topic topic = Topic.Arrays;
        // https://leetcode.com/problems/product-of-array-except-self/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("[1,2,3,4], Expected : [24,12,8,6]");
            Console.WriteLine("Actual: [" + string.Join(",", solution.ProductExceptSelf([1, 2, 3, 4])) + "]");
        }

        public class Solution
        {
            public int[] ProductExceptSelf(int[] nums)
            {

                if (nums.Where(x => x != 0).Count() == 0)
                    return nums;

                int prod = nums.Aggregate(1, (a, b) => a * b);
                int[] answer = new int[nums.Length];

                for (int i = 0; i < nums.Length; ++i)
                {
                    if (nums[i] == 0)
                    {
                        nums[i] = 1;
                        if (nums.Where(x => x == 0).Count() > 0)
                            answer[i] = 0;
                        else
                            answer[i] = nums.Aggregate(1, (a, b) => a * b);
                        nums[i] = 0;
                    }
                    else
                        answer[i] = prod / nums[i];
                }

                return answer;
            }
        }

        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].\r\n\r\nThe product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.\r\n\r\nYou must write an algorithm that runs in O(n) time and without using the division operation.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [1,2,3,4]\r\nOutput: [24,12,8,6]\r\nExample 2:\r\n\r\nInput: nums = [-1,1,0,-3,3]\r\nOutput: [0,0,9,0,0]\r\n \r\n\r\nConstraints:\r\n\r\n2 <= nums.length <= 105\r\n-30 <= nums[i] <= 30\r\nThe input is generated such that answer[i] is guaranteed to fit in a 32-bit integer.\r\n \r\n\r\nFollow up: Can you solve the problem in O(1) extra space complexity? (The output array does not count as extra space for space complexity analysis.)");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}