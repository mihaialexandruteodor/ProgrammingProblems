using System.ComponentModel;

[Description("MinRotatedSortedArray")]
public class MinRotatedSortedArray : IBaseSolution
{
    // https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
    // 
    public void solve()
    {
        Solution solution = new Solution();
        Console.WriteLine("[4,5,6,7,0,1,2], Expected : 0");
        Console.WriteLine("Actual: " + solution.FindMin([4, 5, 6, 7, 0, 1, 2]));
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