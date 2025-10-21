package org.example.leetcode.problem55;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution55 extends BaseSolution {
    public Solution55() {
        this.name = "55. Jump Game";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.DYNAMIC_PROGRAMMING;
        this.description = "You are given an integer array nums. You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.\r\n\r\nReturn true if you can reach the last index, or false otherwise.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [2,3,1,1,4]\r\nOutput: true\r\nExplanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.\r\nExample 2:\r\n\r\nInput: nums = [3,2,1,0,4]\r\nOutput: false\r\nExplanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 104\r\n0 <= nums[i] <= 105";
        // https://leetcode.com/problems/jump-game/
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("[2,3,1,1,4], Expected : True");
        System.out.println("Actual: " + solution.canJump(new int[] { 2, 3, 1, 1, 4 }));
    }

    public class Solution {

        public boolean jump(int position, int[] nums) {
            if (position == nums.length - 1)
                return true;

            int maxJumpLen = nums[position];
            if (maxJumpLen == 0)
                return false;

            if (position + maxJumpLen >= nums.length - 1)
                return true;

            for (int i = maxJumpLen; i >= 1; --i) {
                nums[position] = 0;
                if (jump(position + i, nums))
                    return true;
            }

            return false;
        }

        public boolean canJump(int[] nums) {
            return jump(0, nums);
        }
    }

}
