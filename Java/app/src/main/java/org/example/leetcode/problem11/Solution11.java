package org.example.leetcode.problem11;

import org.example.leetcode.base.BaseSolution;
import org.example.leetcode.base.Utils;

public class Solution11 extends BaseSolution {
    public Solution11() {
        this.name = "11. Container With Most Water";
        this.difficulty = Utils.Difficulty.MEDIUM;
        this.topic = Utils.Topic.ARRAYS;
        this.description = "You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).\r\n\r\nFind two lines that together with the x-axis form a container, such that the container contains the most water.\r\n\r\nReturn the maximum amount of water a container can store.\r\n\r\nNotice that you may not slant the container. \r\n\r\n Example 1:\r\nInput: height = [1,8,6,2,5,4,8,3,7]\r\nOutput: 49\r\nExplanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.";
        this.leetcodeurl = "https://leetcode.com/problems/container-with-most-water/";
    }

    @Override
    public void solve() {
        Utils.getInstance().printProblem(description, difficulty, topic);
        Solution solution = new Solution();
        System.out.println("[1,8,6,2,5,4,8,3,7], Expected : 49");
        System.out.println("Actual: " + solution.maxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
    }

    public class Solution {

        public int maxArea(int[] height) {
            int mostWater = 0;
            int left = 0;
            int right = height.length - 1;

            while (left < right) {
                int rectangleHeight = Math.min(height[left], height[right]);
                int length = right - left;
                int vol = rectangleHeight * length;

                if (vol > mostWater)
                    mostWater = vol;

                if (height[left] < height[right]) {
                    left++;
                } else {
                    right--;
                }
            }

            return mostWater;
        }
    }

}
