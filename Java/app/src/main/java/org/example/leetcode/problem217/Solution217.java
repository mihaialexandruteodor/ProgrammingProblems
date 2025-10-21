package org.example.leetcode.problem217;

import java.util.HashSet;
import java.util.Set;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution217 extends BaseSolution {
    public Solution217() {
        this.name = "217. Contains Duplicate";
        this.difficulty = Utils.Difficulty.EASY;
        this.topic = Utils.Topic.ARRAYS;
        this.description = "Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [1,2,3,1]\r\n\r\nOutput: true\r\n\r\nExplanation:\r\n\r\nThe element 1 occurs at the indices 0 and 3.\r\n\r\nExample 2:\r\n\r\nInput: nums = [1,2,3,4]\r\n\r\nOutput: false\r\n\r\nExplanation:\r\n\r\nAll elements are distinct.\r\n\r\nExample 3:\r\n\r\nInput: nums = [1,1,1,3,3,4,3,2,4,2]\r\n\r\nOutput: true\r\n\r\n \r\n\r\nConstraints:\r\n\r\n1 <= nums.length <= 105\r\n-109 <= nums[i] <= 109";
        this.leetcodeurl = "https://leetcode.com/problems/contains-duplicate/";
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();

        System.out.println("[1,2,3,4], Expected : False");
        System.out.println("Actual: " + solution.containsDuplicate(new int[] { 1, 2, 3, 4 }));
    }

    public class Solution {
        public boolean containsDuplicate(int[] nums) {
            Set<Integer> set = new HashSet<>();
            for (int num : nums) {
                if (set.contains(num)) {
                    return true;
                } else {
                    set.add(num);
                }
            }
            return false;
        }
    }

}
