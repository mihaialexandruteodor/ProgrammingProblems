package org.example.leetcode.problem15;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution15 extends BaseSolution {
    public Solution15() {
        this.name = "15. 3Sum";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.ARRAYS;
        this.description = "Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.\r\n\r\nNotice that the solution set must not contain duplicate triplets.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: nums = [-1,0,1,2,-1,-4]\r\nOutput: [[-1,-1,2],[-1,0,1]]\r\nExplanation: \r\nnums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.\r\nnums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.\r\nnums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.\r\nThe distinct triplets are [-1,0,1] and [-1,-1,2].\r\nNotice that the order of the output and the order of the triplets does not matter.\r\nExample 2:\r\n\r\nInput: nums = [0,1,1]\r\nOutput: []\r\nExplanation: The only possible triplet does not sum up to 0.\r\nExample 3:\r\n\r\nInput: nums = [0,0,0]\r\nOutput: [[0,0,0]]\r\nExplanation: The only possible triplet sums up to 0.\r\n \r\n\r\nConstraints:\r\n\r\n3 <= nums.length <= 3000\r\n-105 <= nums[i] <= 105";
        // https://leetcode.com/problems/3sum/
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("[-1,0,1,2,-1,-4], Expected : [[-1,-1,2],[-1,0,1]]");
        System.out.print("Actual: " + Utils.printForConsole(solution.threeSum(new int[] { -1, 0, 1, 2, -1, -4 })));
    }

    public class Solution {

        public static class ListComparer implements java.util.Comparator<java.util.List<Integer>> {
            @Override
            public int compare(java.util.List<Integer> a, java.util.List<Integer> b) {
                if (a == null && b == null)
                    return 0;
                if (a == null)
                    return -1;
                if (b == null)
                    return 1;
                int n = Math.min(a.size(), b.size());
                for (int i = 0; i < n; i++) {
                    int cmp = Integer.compare(a.get(i), b.get(i));
                    if (cmp != 0)
                        return cmp;
                }
                return Integer.compare(a.size(), b.size());
            }
        }

        public java.util.List<java.util.List<Integer>> threeSum(int[] nums) {
            java.util.Set<java.util.List<Integer>> sol = new java.util.TreeSet<>(new ListComparer());
            java.util.Arrays.sort(nums);
            for (int i = 0; i < nums.length - 2; ++i) {
                int j = i + 1, k = nums.length - 1;
                while (j < k) {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum == 0) {
                        sol.add(java.util.Arrays.asList(nums[i], nums[j], nums[k]));
                        j++;
                    } else if (sum > 0) {
                        k--;
                    } else {
                        j++;
                    }
                }
            }
            return new java.util.ArrayList<>(sol);
        }
    }

}
