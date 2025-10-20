package org.example.leetcode.problem78;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution78 extends BaseSolution {
    public Solution78() {
        this.name = "78. Subsets";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.DYNAMIC_PROGRAMMING;
        this.description = "Given an integer array nums of unique elements, return all possible subsets (the power set).\r\n\r\nThe solution set must not contain duplicate subsets. Return the solution in any order.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [1,2,3]\r\nOutput: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]\r\nExample 2:\r\n\r\nInput: nums = [0]\r\nOutput: [[],[0]]\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 10\r\n-10 <= nums[i] <= 10\r\nAll the numbers of nums are unique.";
        // https://leetcode.com/problems/subsets/
    }

    @Override
    public void solve() {

    }

}
