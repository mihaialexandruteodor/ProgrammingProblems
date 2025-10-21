package org.example.leetcode.problem78;

import java.util.ArrayList;
import java.util.List;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution78 extends BaseSolution {
    public Solution78() {
        this.name = "78. Subsets";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.DYNAMIC_PROGRAMMING;
        this.description = "Given an integer array nums of unique elements, return all possible subsets (the power set).\r\n\r\nThe solution set must not contain duplicate subsets. Return the solution in any order.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [1,2,3]\r\nOutput: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]\r\nExample 2:\r\n\r\nInput: nums = [0]\r\nOutput: [[],[0]]\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 10\r\n-10 <= nums[i] <= 10\r\nAll the numbers of nums are unique.";
        this.leetcodeurl = "https://leetcode.com/problems/subsets/";
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("[1,2,3], Expected : [[],[1],[1,2],[1,2,3],[1,3],[2],[2,3],[3]]");
        System.out.println("Actual: " + Utils.printForConsole(solution.subsets(new int[] { 1, 2, 3 })));
    }

    public class Solution {

        public List<List<Integer>> subsets(int[] nums) {
            List<List<Integer>> res = new ArrayList<>();

            backtrack(0, new ArrayList<>(), nums, res);
            return res;
        }

        private void backtrack(int start, List<Integer> current, int[] nums, List<List<Integer>> res) {
            res.add(new ArrayList<>(current)); // Add a copy

            for (int i = start; i < nums.length; i++) {
                current.add(nums[i]);
                backtrack(i + 1, current, nums, res);
                current.remove(current.size() - 1); // remove last added
            }
        }
    }

}
