using System.ComponentModel;

namespace problems.leetcode._152
{
    public class MaxProductSubarray : IBaseSolution
    {
        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Problem: Given an integer array nums, find a subarray that has the largest product, and return the product.\r\n\r\nThe test cases are generated so that the answer will fit in a 32-bit integer.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [2,3,-2,4]\r\nOutput: 6\r\nExplanation: [2,3] has the largest product 6.\r\nExample 2:\r\n\r\nInput: nums = [-2,0,-1]\r\nOutput: 0\r\nExplanation: The result cannot be 2, because [-2,-1] is not a subarray.\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 2 * 104\r\n-10 <= nums[i] <= 10\r\nThe product of any subarray of nums is guaranteed to fit in a 32-bit integer.");
            Console.WriteLine();
        }

        // https://leetcode.com/problems/maximum-product-subarray/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("[2,3,-2,4], Expected : 6");
            Console.WriteLine("Actual: " + solution.MaxProduct([2, 3, -2, 4]));
        }

        public class Solution
        {
            public int MaxProduct(int[] nums)
            {
                if (nums == null || nums.Length == 0)
                    return 0;

                int maxProd = nums[0];
                int minProd = nums[0];
                int result = nums[0];

                for (int i = 1; i < nums.Length; i++)
                {
                    int tempMax = maxProd;
                    maxProd = Math.Max(nums[i], Math.Max(maxProd * nums[i], minProd * nums[i]));
                    minProd = Math.Min(nums[i], Math.Min(tempMax * nums[i], minProd * nums[i]));
                    result = Math.Max(result, maxProd);
                }

                return result;
            }
        }
    }
}