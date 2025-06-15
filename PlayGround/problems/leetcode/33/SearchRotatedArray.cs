using System.ComponentModel;

[Description("SearchRotatedArray")]
public class SearchRotatedArray : IBaseSolution
{
    // https://leetcode.com/problems/search-in-rotated-sorted-array/
    public void solve()
    {
        Solution solution = new Solution();
        Console.WriteLine("[4,5,6,7,0,1,2], t=0, Expected : 4");
        Console.WriteLine("Actual: " + solution.Search([4, 5, 6, 7, 0, 1, 2], 0));
    }

    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                    return mid;

                // Check if left half is sorted
                if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid])
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                // Right half is sorted
                else
                {
                    if (nums[mid] < target && target <= nums[right])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }

            return -1; // not found
        }
    }

}