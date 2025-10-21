package org.example.leetcode.problem198;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution198 extends BaseSolution {
    public Solution198() {
        this.name = "198. House Robber";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.DYNAMIC_PROGRAMMING;
        this.description = "Problem: You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into on the same night.\r\n\r\nGiven an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [1,2,3,1]\r\nOutput: 4\r\nExplanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).\r\nTotal amount you can rob = 1 + 3 = 4.\r\nExample 2:\r\n\r\nInput: nums = [2,7,9,3,1]\r\nOutput: 12\r\nExplanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).\r\nTotal amount you can rob = 2 + 9 + 1 = 12.\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 100\r\n0 <= nums[i] <= 400";
        // https://leetcode.com/problems/house-robber/
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();

        int[] houses = new int[] { 2, 1, 1, 2 };
        System.out.println("Expected : 4");
        System.out.println("Actual: " + solution.rob(houses));
    }

    public class Solution {
        public int rob(int[] nums) {
            if (nums == null || nums.length == 0)
                return 0;
            if (nums.length == 1)
                return nums[0];

            int prev1 = 0; // max up to previous house
            int prev2 = 0; // max up to house before previous
            int current = 0;

            for (int num : nums) {
                current = Math.max(prev1, prev2 + num);
                prev2 = prev1;
                prev1 = current;
            }

            return current;
        }
    }

}
