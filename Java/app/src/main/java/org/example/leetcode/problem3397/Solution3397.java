package org.example.leetcode.problem3397;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Solution3397 {

    // GREEDY APPROACH
    // https://leetcode.com/problems/maximum-number-of-distinct-elements-after-operations/description/

    public static int maxDistinctElements(int[] nums, int k) {
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

    public static void runProblem() {
        int[] nums = { 1, 2, 2, 3, 3, 4 };
        System.out.println("Expected: 6");
        System.out.println("Actual: " + maxDistinctElements(nums, 2));
    }
}