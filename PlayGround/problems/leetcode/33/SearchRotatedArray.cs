using System.ComponentModel;

namespace problems.leetcode._33
{
    public class SearchRotatedArray : IBaseSolution
    {
        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEDIUM");
            Console.ResetColor();
            Console.WriteLine("Problem: There is an integer array nums sorted in ascending order (with distinct values).\r\n\r\nPrior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length) such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].\r\n\r\nGiven the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.\r\n\r\nYou must write an algorithm with O(log n) runtime complexity.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [4,5,6,7,0,1,2], target = 0\r\nOutput: 4\r\nExample 2:\r\n\r\nInput: nums = [4,5,6,7,0,1,2], target = 3\r\nOutput: -1\r\nExample 3:\r\n\r\nInput: nums = [1], target = 0\r\nOutput: -1\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 5000\r\n-104 <= nums[i] <= 104\r\nAll values of nums are unique.\r\nnums is an ascending array that is possibly rotated.\r\n-104 <= target <= 104");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }

        // https://leetcode.com/problems/search-in-rotated-sorted-array/
        public void solve()
        {
            printProblem();
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
}