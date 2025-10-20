package org.example.leetcode.problem152;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution152 extends BaseSolution {
    public Solution152() {
        this.name = "152. Maximum Product Subarray";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.ARRAYS;
        this.description = "Problem: Given an integer array nums, find a subarray that has the largest product, and return the product.\r\n\r\nThe test cases are generated so that the answer will fit in a 32-bit integer.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [2,3,-2,4]\r\nOutput: 6\r\nExplanation: [2,3] has the largest product 6.\r\nExample 2:\r\n\r\nInput: nums = [-2,0,-1]\r\nOutput: 0\r\nExplanation: The result cannot be 2, because [-2,-1] is not a subarray.\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 2 * 104\r\n-10 <= nums[i] <= 10\r\nThe product of any subarray of nums is guaranteed to fit in a 32-bit integer.";
        // https://leetcode.com/problems/maximum-product-subarray/
    }

    @Override
    public void solve() {

    }

}
