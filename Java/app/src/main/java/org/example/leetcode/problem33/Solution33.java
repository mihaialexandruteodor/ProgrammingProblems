package org.example.leetcode.problem33;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution33 extends BaseSolution {
    public Solution33() {
        this.name = "33. Search in Rotated Sorted Array";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.ARRAYS;
        this.description = "Problem: There is an integer array nums sorted in ascending order (with distinct values).\r\n\r\nPrior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length) such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].\r\n\r\nGiven the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.\r\n\r\nYou must write an algorithm with O(log n) runtime complexity.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [4,5,6,7,0,1,2], target = 0\r\nOutput: 4\r\nExample 2:\r\n\r\nInput: nums = [4,5,6,7,0,1,2], target = 3\r\nOutput: -1\r\nExample 3:\r\n\r\nInput: nums = [1], target = 0\r\nOutput: -1\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 5000\r\n-104 <= nums[i] <= 104\r\nAll values of nums are unique.\r\nnums is an ascending array that is possibly rotated.\r\n-104 <= target <= 104";
        this.leetcodeurl = "https://leetcode.com/problems/search-in-rotated-sorted-array/";
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("[4,5,6,7,0,1,2], t=0, Expected : 4");
        System.out.println("Actual: " + solution.search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0));
    }

    public class Solution {

        public int search(int[] nums, int target) {
            int left = 0, right = nums.length - 1;

            while (left <= right) {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                    return mid;

                if (nums[left] <= nums[mid]) { // left half sorted
                    if (nums[left] <= target && target < nums[mid])
                        right = mid - 1;
                    else
                        left = mid + 1;
                } else { // right half sorted
                    if (nums[mid] < target && target <= nums[right])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }

            return -1;
        }
    }

}
