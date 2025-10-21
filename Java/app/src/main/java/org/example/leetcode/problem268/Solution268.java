package org.example.leetcode.problem268;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution268 extends BaseSolution {
    public Solution268() {
        this.name = "268. Missing Number";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.BINARY;
        this.description = "Given an array nums containing n distinct numbers in the range [0, n], return the only number in the range that is missing from the array.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [3,0,1]\r\n\r\nOutput: 2\r\n\r\nExplanation:\r\n\r\nn = 3 since there are 3 numbers, so all numbers are in the range [0,3]. 2 is the missing number in the range since it does not appear in nums.\r\n\r\nExample 2:\r\n\r\nInput: nums = [0,1]\r\n\r\nOutput: 2\r\n\r\nExplanation:\r\n\r\nn = 2 since there are 2 numbers, so all numbers are in the range [0,2]. 2 is the missing number in the range since it does not appear in nums.\r\n\r\nExample 3:\r\n\r\nInput: nums = [9,6,4,2,3,5,7,0,1]\r\n\r\nOutput: 8\r\n\r\nExplanation:\r\n\r\nn = 9 since there are 9 numbers, so all numbers are in the range [0,9]. 8 is the missing number in the range since it does not appear in nums.\r\n\r\n  Constraints:\r\n\r\nn == nums.length\r\n1 <= n <= 104\r\n0 <= nums[i] <= n\r\nAll the numbers of nums are unique.\r\n \r\n\r\nFollow up: Could you implement a solution using only O(1) extra space complexity and O(n) runtime complexity?";
        // https://leetcode.com/problems/missing-number/
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();

        int[] nums = { 3, 0, 1 };
        System.out.println("[3,0,1], Expected : 2");
        System.out.println("Actual: " + solution.missingNumber(nums));
    }

    public class Solution {
        public int missingNumber(int[] nums) {
            int n = nums.length;
            int xor = 0;

            // XOR all indices and numbers
            for (int i = 0; i < n; i++) {
                xor ^= i;
                xor ^= nums[i];
            }

            // XOR with n
            xor ^= n;
            return xor;
        }
    }

}
