package org.example.leetcode.problem3397;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;
import org.example.leetcode.base.Utils.Difficulty;
import org.example.leetcode.base.Utils.Topic;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Solution3397 extends BaseSolution {
    public static String name = "3397. Maximum Number of Distinct Elements After Operations";
    public static Difficulty difficulty = Difficulty.MEDIUM;
    public static Topic topic = Topic.STRINGS;
    public static String description = "You are given an integer array nums and an integer k.\n" + //
            "\n" + //
            "You are allowed to perform the following operation on each element of the array at most once:\n" + //
            "\n" + //
            "Add an integer in the range [-k, k] to the element.\n" + //
            "Return the maximum possible number of distinct elements in nums after performing the operations.\n" + //
            "\n" + //
            " \n" + //
            "\n" + //
            "Example 1:\n" + //
            "\n" + //
            "Input: nums = [1,2,2,3,3,4], k = 2\n" + //
            "\n" + //
            "Output: 6\n" + //
            "\n" + //
            "Explanation:\n" + //
            "\n" + //
            "nums changes to [-1, 0, 1, 2, 3, 4] after performing operations on the first four elements.\n" + //
            "\n" + //
            "Example 2:\n" + //
            "\n" + //
            "Input: nums = [4,4,4,4], k = 1\n" + //
            "\n" + //
            "Output: 3\n" + //
            "\n" + //
            "Explanation:\n" + //
            "\n" + //
            "By adding -1 to nums[0] and 1 to nums[1], nums changes to [3, 5, 4, 4].\n" + //
            "\n" + //
            " \n" + //
            "\n" + //
            "Constraints:\n" + //
            "\n" + //
            "1 <= nums.length <= 105\n" + //
            "1 <= nums[i] <= 109\n" + //
            "0 <= k <= 109";

    public class Solution {
        // GREEDY APPROACH
        // https://leetcode.com/problems/maximum-number-of-distinct-elements-after-operations/description/
        public int maxDistinctElements(int[] nums, int k) {
            List<Integer> numsList = new ArrayList<>();
            for (int num : nums) {
                numsList.add(num);
            }

            int cnt = 0, prev = Integer.MIN_VALUE;
            Collections.sort(numsList);

            for (int num : numsList) {
                int curr = Math.max(num - k, prev + 1);
                if (curr <= num + k) {
                    cnt++;
                    prev = curr;
                }
            }

            return cnt;
        }
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        int[] nums = { 1, 2, 2, 3, 3, 4 };
        System.out.println("Expected: 6");
        System.out.println("Actual: " + solution.maxDistinctElements(nums, 2));
    }
}
