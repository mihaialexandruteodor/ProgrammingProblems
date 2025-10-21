package org.example.leetcode.problem128;

import java.util.TreeSet;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution128 extends BaseSolution {
    public Solution128() {
        this.name = "128. Longest Consecutive Sequence";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.GRAPHS;
        this.description = "Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.\r\n\r\nYou must write an algorithm that runs in O(n) time.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [100,4,200,1,3,2]\r\nOutput: 4\r\nExplanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.\r\nExample 2:\r\n\r\nInput: nums = [0,3,7,2,5,8,4,6,0,1]\r\nOutput: 9\r\nExample 3:\r\n\r\nInput: nums = [1,0,1,2]\r\nOutput: 3\r\n \r\n\r\nConstraints:\r\n\r\n0 <= nums.length <= 105\r\n-109 <= nums[i] <= 109";
        this.leetcodeurl = "https://leetcode.com/problems/longest-consecutive-sequence/";
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("[100,4,200,1,3,2], Expected : 4");
        System.out.println("Actual: " + solution.longestConsecutive(new int[] { 100, 4, 200, 1, 3, 2 }));
    }

    public class Solution {
        public int longestConsecutive(int[] nums) {
            if (nums.length == 0)
                return 0;

            TreeSet<Integer> vals = new TreeSet<>();
            for (int num : nums)
                vals.add(num);

            int maxConsec = 0;
            int currConsec = 1;
            int prevVal = vals.first() - 2;

            for (int val : vals) {
                if (val - prevVal == 1)
                    currConsec++;
                else {
                    maxConsec = Math.max(maxConsec, currConsec);
                    currConsec = 1;
                }
                prevVal = val;
            }

            maxConsec = Math.max(maxConsec, currConsec);
            return maxConsec;
        }
    }

}
