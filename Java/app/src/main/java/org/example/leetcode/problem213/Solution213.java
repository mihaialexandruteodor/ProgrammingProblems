package org.example.leetcode.problem213;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution213 extends BaseSolution {
    public Solution213() {
        this.name = "213. House Robber II";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.DYNAMIC_PROGRAMMING;
        this.description = "You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed. All houses at this place are arranged in a circle. That means the first house is the neighbor of the last one. Meanwhile, adjacent houses have a security system connected, and it will automatically contact the police if two adjacent houses were broken into on the same night.\r\n\r\nGiven an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [2,3,2]\r\nOutput: 3\r\nExplanation: You cannot rob house 1 (money = 2) and then rob house 3 (money = 2), because they are adjacent houses.\r\nExample 2:\r\n\r\nInput: nums = [1,2,3,1]\r\nOutput: 4\r\nExplanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).\r\nTotal amount you can rob = 1 + 3 = 4.\r\nExample 3:\r\n\r\nInput: nums = [1,2,3]\r\nOutput: 3\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 100\r\n0 <= nums[i] <= 1000";
        // https://leetcode.com/problems/house-robber-ii/
    }

    @Override
    public void solve() {

    }

}
