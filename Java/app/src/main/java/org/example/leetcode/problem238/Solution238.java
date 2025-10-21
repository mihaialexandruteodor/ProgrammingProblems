package org.example.leetcode.problem238;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution238 extends BaseSolution {
    public Solution238() {
        this.name = "238. Product of Array Except Self";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.ARRAYS;
        this.description = "Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].\r\n\r\nThe product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.\r\n\r\nYou must write an algorithm that runs in O(n) time and without using the division operation.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [1,2,3,4]\r\nOutput: [24,12,8,6]\r\nExample 2:\r\n\r\nInput: nums = [-1,1,0,-3,3]\r\nOutput: [0,0,9,0,0]\r\n \r\n\r\nConstraints:\r\n\r\n2 <= nums.length <= 105\r\n-30 <= nums[i] <= 30\r\nThe input is generated such that answer[i] is guaranteed to fit in a 32-bit integer.\r\n \r\n\r\nFollow up: Can you solve the problem in O(1) extra space complexity? (The output array does not count as extra space for space complexity analysis.)";
        this.leetcodeurl = "https://leetcode.com/problems/product-of-array-except-self/";
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();

        System.out.println("[1,2,3,4], Expected : [24,12,8,6]");
        System.out.println("Actual: " + Utils.printForConsole(solution.productExceptSelf(new int[] { 1, 2, 3, 4 })));
    }

    public class Solution {
        public int[] productExceptSelf(int[] nums) {
            int n = nums.length;
            int[] answer = new int[n];

            // Step 1: Calculate left products
            answer[0] = 1;
            for (int i = 1; i < n; i++) {
                answer[i] = answer[i - 1] * nums[i - 1];
            }

            // Step 2: Multiply by right products
            int R = 1;
            for (int i = n - 1; i >= 0; i--) {
                answer[i] *= R;
                R *= nums[i];
            }

            return answer;
        }
    }

}
