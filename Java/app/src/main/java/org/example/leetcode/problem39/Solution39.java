package org.example.leetcode.problem39;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution39 extends BaseSolution {
    public Solution39() {
        this.name = "39. Combination Sum";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.DYNAMIC_PROGRAMMING;
        this.description = "Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.\r\n\r\nThe same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the frequency of at least one of the chosen numbers is different.\r\n\r\nThe test cases are generated such that the number of unique combinations that sum up to target is less than 150 combinations for the given input.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: candidates = [2,3,6,7], target = 7\r\nOutput: [[2,2,3],[7]]\r\nExplanation:\r\n2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.\r\n7 is a candidate, and 7 = 7.\r\nThese are the only two combinations.\r\nExample 2:\r\n\r\nInput: candidates = [2,3,5], target = 8\r\nOutput: [[2,2,2,2],[2,3,3],[3,5]]\r\nExample 3:\r\n\r\nInput: candidates = [2], target = 1\r\nOutput: []\r\n \r\n\r\nConstraints:\r\n\r\n1 <= candidates.length <= 30\r\n2 <= candidates[i] <= 40\r\nAll elements of candidates are distinct.\r\n1 <= target <= 40";
        // https://leetcode.com/problems/combination-sum/
    }

    @Override
    public void solve() {

    }

}
