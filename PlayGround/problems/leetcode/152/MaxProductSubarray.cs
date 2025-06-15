using System.ComponentModel;

namespace problems.leetcode._152
{
    public class MaxProductSubarray : IBaseSolution
    {
        // https://leetcode.com/problems/maximum-product-subarray/
        public void solve()
        {
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